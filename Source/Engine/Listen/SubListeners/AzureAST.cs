using System;
using System.Speech.Recognition;
using puremvc.Engine.Listen.Interfaces;
using Microsoft.CognitiveServices.SpeechRecognition;

namespace puremvc.Engine.Listen.SubClasses
{
    public class AzureAST : IListerner
    {
        private static readonly Uri ShortPhraseUrl = new Uri(@"wss://speech.platform.bing.com/api/service/recognition");
        private static readonly Uri LongDictationUrl = new Uri(@"wss://speech.platform.bing.com/api/service/recognition/continuous");
        private DataRecognitionClient dataClient;
        private MicrophoneRecognitionClient micClient;

        public SpeechRecognitionMode Mode = SpeechRecognitionMode.LongDictation;
        public string DefaultLocale = "en-us";
        public string SubscriptionKey = "f504dd2c3583439eb93f71a69db01aea";
        private bool isMicrophoneActive = false;

        IlistenEnums IListerner.type
        {
            get
            {
                return IlistenEnums.AzureAST;
            }
        }

        public void LoadGramer(Grammar gramar, bool isUnload = false)
        {
        }

        public void Start(bool isShortParse = true)
        {
            if(isShortParse)
            {
                this.Mode = SpeechRecognitionMode.ShortPhrase;
            }else
            {
                this.Mode = SpeechRecognitionMode.LongDictation;
            }

            if (this.micClient == null)
            {
                this.CreateMicrophoneRecoClient();
            }

            this.micClient.StartMicAndRecognition();
         
            CreateDataRecoClient();
        }

        private void CreateDataRecoClient()
        {
            this.dataClient = SpeechRecognitionServiceFactory.CreateDataClient(
                this.Mode,
                this.DefaultLocale,
                this.SubscriptionKey);

            if (this.Mode == SpeechRecognitionMode.ShortPhrase)
            {
                this.dataClient.OnResponseReceived += this.OnDataShortPhraseResponseReceivedHandler;
            }
            else
            {
                this.dataClient.OnResponseReceived += this.OnDataDictationResponseReceivedHandler;
            }

            this.dataClient.OnPartialResponseReceived += this.OnPartialResponseReceivedHandler;
            this.dataClient.OnConversationError += this.OnConversationErrorHandler;
        }

        private void CreateMicrophoneRecoClient()
        {
            this.micClient = SpeechRecognitionServiceFactory.CreateMicrophoneClient(
                this.Mode,
                this.DefaultLocale,
                this.SubscriptionKey);

            this.micClient.OnMicrophoneStatus += this.OnMicrophoneStatus;
            this.micClient.OnPartialResponseReceived += this.OnPartialResponseReceivedHandler;
            if (this.Mode == SpeechRecognitionMode.ShortPhrase)
            {
                this.micClient.OnResponseReceived += this.OnMicShortPhraseResponseReceivedHandler;
            }
            else if (this.Mode == SpeechRecognitionMode.LongDictation)
            {
                this.micClient.OnResponseReceived += this.OnMicDictationResponseReceivedHandler;
            }

            this.micClient.OnConversationError += this.OnConversationErrorHandler;
        }

        private void OnMicDictationResponseReceivedHandler(object sender, SpeechResponseEventArgs e)
        {
            if (e.PhraseResponse.RecognitionStatus == RecognitionStatus.EndOfDictation ||
                e.PhraseResponse.RecognitionStatus == RecognitionStatus.DictationEndSilenceTimeout)
            {

                // we got the final result, so it we can end the mic reco.  No need to do this
                // for dataReco, since we already called endAudio() on it as soon as we were done
                // sending all the data.
                this.micClient.EndMicAndRecognition();

            }

            this.WriteResponseResult(e);
        }

        private void OnMicShortPhraseResponseReceivedHandler(object sender, SpeechResponseEventArgs e)
        {
            // we got the final result, so it we can end the mic reco.  No need to do this
            // for dataReco, since we already called endAudio() on it as soon as we were done
            // sending all the data.
            this.micClient.EndMicAndRecognition();

            this.WriteResponseResult(e);
        }

        private void OnMicrophoneStatus(object sender, MicrophoneEventArgs e)
        {
            isMicrophoneActive = e.Recording;
        }

        private void OnConversationErrorHandler(object sender, SpeechErrorEventArgs e)
        {
            switch(e.SpeechErrorCode)
            {
                case SpeechClientStatus.Timeout:
                case SpeechClientStatus.ConnectionFailed:
                case SpeechClientStatus.NameNotFound:
                    MainListener.Instance.SubListenereInternetError();
                    break;
                default:
                    MainListener.Instance.SubListenereError();
                    break;
            }

        }

        private void OnPartialResponseReceivedHandler(object sender, PartialSpeechResponseEventArgs e)
        {
            MainListener.Instance.PartialTextRecived(e.PartialResult);
        }

        private void OnDataDictationResponseReceivedHandler(object sender, SpeechResponseEventArgs e)
        {
            if (e.PhraseResponse.RecognitionStatus == RecognitionStatus.EndOfDictation ||
                e.PhraseResponse.RecognitionStatus == RecognitionStatus.DictationEndSilenceTimeout)
            {
                // we got the final result, so it we can end the mic reco.  No need to do this
                // for dataReco, since we already called endAudio() on it as soon as we were done
                // sending all the data.
            }

            this.WriteResponseResult(e);
        }

        private void WriteResponseResult(SpeechResponseEventArgs e)
        {
            if (e.PhraseResponse.Results.Length == 0)
            {
                MainListener.Instance.FinalResultTextRecived("");
            }
            else
            {
                MainListener.Instance.FinalResultTextRecived(FixResult(e.PhraseResponse.Results[0].DisplayText));
             
            }
        }

        private string FixResult(string data)
        {
            return data.Replace("/", "DIVIDED").Replace("+", "PLUS").Replace("-", "MINUS").Replace("*", "TIMES");
        }

        private void OnDataShortPhraseResponseReceivedHandler(object sender, SpeechResponseEventArgs e)
        {
            this.WriteResponseResult(e);
        }
    
        public void Stop()
        {
            try
            {
                micClient.AudioStop();
                micClient.Dispose();
                dataClient.AudioStop();
                dataClient.Dispose();
            }
            catch { }
        }
    }
}
