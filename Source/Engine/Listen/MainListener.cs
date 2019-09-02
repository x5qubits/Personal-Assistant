using System;
using System.Collections.Generic;
using System.Globalization;
using System.Speech.Recognition;
using JHUI.Utils;
using puremvc.Engine.Brain;
using System.Diagnostics;

namespace puremvc.Engine.Listen.SubClasses
{
    public enum MAINSTATE
    {
        STARTED,
        STOPPED,
    }
    public class MainListener : JBehavor
    {
        private SpeechRecognitionEngine recognizer;
        static readonly public MainListener Instance = new MainListener();
        private readonly float listenTime = 30f; //3 seconds
        private float lastActivatedTime;
        private EarManager manager;
        private IlistenEnums listenerId = IlistenEnums.none;
        private Random random = new Random();
        private MAINSTATE state = MAINSTATE.STOPPED;
        private float lastStopTime = 0;
        private float Reactivateafter = 50f;

        private bool isDefaultGrama = true;
        public bool isCanUpdateTaskPanel = false;

        private MainListener()
        {
            manager = EarManager.Instance;
            lastActivatedTime = Time.time + 10;
            lastStopTime = Time.time + 3;
            InvokeRepeating(CheckForListeners, 0.1f);
        }

        private void CheckForListeners()
        {
            if(listenerId != IlistenEnums.none)
            {
                if (lastActivatedTime < Time.time)
                    StopListening();
            }
            if (state == MAINSTATE.STOPPED)
            {
                if (lastStopTime < Time.time)
                    StartDefault();
            }
            if (isCanUpdateTaskPanel)
                TaskPanel.Instance.TaskPanelUpdate();
        }

        public void StopListening(bool OtherStop = false)
        {
            TaskPanel.Instance.HidePanel();
            if (listenerId != IlistenEnums.none)
            {
                Debug.WriteLine("Sub Listener Stoped!");
                manager.StopListen(listenerId);
                listenerId = IlistenEnums.none;
                
                StartDefault(true);
            }
            else
            {
                if (OtherStop)
                {
                    Stop();
                    StartDefault(true);
                }
            }
        }

        public void StartDefault(bool isListenForThankYou = false)
        {
            
            state = MAINSTATE.STARTED;
            isDefaultGrama = true;
            CultureInfo ci = new CultureInfo("en-US");
            recognizer = new SpeechRecognitionEngine(ci);
            string[] ch = null;
            if(isListenForThankYou)
            {
                ch = new string[] {
                "Source",
                "hey Source",
                "hello Source",
                "are you there Source",
                "Source are you there",
                "Source wake up",
                "stop",
                "cancel",
                "silence",
                "mute",
                "Thank You",
                "Thanks",
                "okay Thanks",
                "okay thank you",
                };
            }
            else
            {
                ch = new string[] {
                "Source",
                "hey Source",
                "hello Source",
                "are you there Source",
                "Source are you there",
                "Source wake up",
                "cancel",
                "stop",
                "silence",
                "mute",
                };
            }
            GrammarBuilder gb = new GrammarBuilder(new Choices(ch))
            {
                Culture = new System.Globalization.CultureInfo("en-US")
            };
            Grammar gr = new Grammar(gb);        
            recognizer.LoadGrammar(gr);
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(SpeechRecognizedHandler);
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
            Debug.WriteLine("Main Listener Started!");
        }

        public void StartConfirm(string[] ch)
        {
            isDefaultGrama = false;
            CultureInfo ci = new CultureInfo("en-US");
            recognizer = new SpeechRecognitionEngine(ci);
            GrammarBuilder gb = new GrammarBuilder(new Choices(ch));
            gb.Culture = new System.Globalization.CultureInfo("en-US");
            Grammar gr = new Grammar(gb);
            recognizer.LoadGrammar(gr);
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(SpeechRecognizedHandlerConfirm);
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
            Debug.WriteLine("Main Listener Confirm Started!");
        }

        public void StartListening(IlistenEnums azureAST)
        {
            listenerId = azureAST;
            lastActivatedTime = Time.time + listenTime;
            manager.StartListen(listenerId);
            Stop();
            Debug.WriteLine("Sub Listener Started!");
        }

        private void SpeechRecognizedHandlerConfirm(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result != null && e.Result.Confidence > 0.9F && !isDefaultGrama)
                {
                    string result = e.Result.Text.ToString().ToLower();
                    DecisionMaking.Instance.processConfirmOpenProgram(result);
                }
                else
                {
                    if (e.Result != null)
                        MouthManager.Instance.Speak("Say that again?");
                }
            }
        }

        private void SpeechRecognizedHandler(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result != null && e.Result.Confidence > 0.9F)
                {
                    string result = e.Result.Text.ToString().ToLower();
                    if (result.Contains("thank"))
                    {
                        yourWelcome();
                    }
                    if (result.Equals("silence") || result.Equals("mute") || result.Equals("cancel") || result.Equals("stop"))
                    {
                        StopListening();
                        TaskPanel.Instance.HideNow();
                        MouthManager.Instance.StopAll();
                    }
                    else if (result.Contains("source") || result.Equals("source"))
                    {
                        TaskPanel.Instance.ShowNow(TaskPanelState.Listening);
                        TheProcessor.Instance.Process(e.Result.ToString(), true);
                    }
                }
                else
                {
                    if (e.Result != null)
                        MouthManager.Instance.Speak("Say that again?");
                }
            }
        }

        private void yourWelcome()
        {
            MouthManager.Instance.Speak("No problem!");
            TaskPanel.Instance.HideNow((int)Time.time + 3);
        }

        public void Stop()
        {
            state = MAINSTATE.STOPPED;
            lastStopTime = Time.time + Reactivateafter;
            isDefaultGrama = false;
            try
            {
                recognizer.UnloadAllGrammars();
            }
            catch { }
            try
            {
                recognizer.RecognizeAsyncStop();
            }
            catch { }
            Debug.WriteLine("Main Listener Stopped!");
        }

        public void SubListenereError()
        {

        }

        public void SubListenereInternetError()
        {

        }

        public void PartialTextRecived(string data)
        {
            TaskPanel.Instance.UserSay(data, TaskPanelState.Pusseling);
            Console.WriteLine(data);
        }

        public void FinalResultTextRecived(string data)
        {           
            Console.WriteLine(data);
            TheProcessor.Instance.Process(data);
            TaskPanel.Instance.UserSay(data, TaskPanelState.Pusseling);
        }

        public string getRandomGreating()
        {
            var names = new List<string> {"How can I help?", "Hello!", "Yes!", "How can I be of service?"};

            int index = random.Next(names.Count);
            var name = names[index];
            names.RemoveAt(index);
            return name;
        }


    }
}
