using CSCore;
using CSCore.Codecs.WMA;
using CSCore.SoundOut;
using CSCore.Streams.Effects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace puremvc.Engine
{
    public enum SOUNDSTATE
    {
        NONE,
        READY,
        PLAYING,
        PAUSED,
        STOPPED,
        FORMING,
    }
    public class OrderSound : IDisposable
    {
        public MemoryStream m_AudioStream;
        public MemoryStream m_AudioStream2 = new MemoryStream();
        public ISoundOut soundOut;
        public ManualResetEvent manualReset = new ManualResetEvent(false);
        public FlangerEffect flanger;
        public DmoWavesReverbEffect rev;
        public Action<int> compleated = null;
        public SOUNDSTATE state = SOUNDSTATE.NONE;

        public int Id = 0;
        public int Rate = 0;

        public OrderSound(string message, float Depth, float Frequency, float Feedback, float WetDryMix, float ReverbTime, float HighFrequencyRTRatio)
        {
            Thread theRT = new Thread(delegate ()
              {
                  {
                      m_AudioStream = new MemoryStream();
                      using (SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer())
                      {
                          speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Child);
                          speechSynthesizer.Rate = Rate;
                          speechSynthesizer.SetOutputToWaveStream(m_AudioStream);
                          speechSynthesizer.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>(WriteCompleate);
                          speechSynthesizer.SpeakAsync(message);
                          state = SOUNDSTATE.FORMING;
                          manualReset.WaitOne();
                          state = SOUNDSTATE.READY;
                          m_AudioStream.Seek(0, SeekOrigin.Begin);
                          flanger = new FlangerEffect(GetSoundSource(m_AudioStream))
                          {
                              Depth = Depth,
                              Frequency = Frequency,
                              Feedback = Feedback,
                              WetDryMix = WetDryMix
                          };
                          rev = new DmoWavesReverbEffect(flanger.ToStereo())
                          {
                              ReverbTime = ReverbTime,
                              HighFrequencyRTRatio = HighFrequencyRTRatio
                          };
                          rev.WriteToWaveStream(m_AudioStream2);
                          soundOut = GetSoundOut();
                          soundOut.Initialize(GetSoundSource(m_AudioStream2));
                          soundOut.Volume = 1;
                          soundOut.Stopped += DonePlaying;
                          soundOut.Play();

                          state = SOUNDSTATE.PLAYING;
                          manualReset.WaitOne();
                      }
                  }
              })
            {
                IsBackground = true
            };
            theRT.Start();

        }

        public void Pause()
        {
            if(state != SOUNDSTATE.PAUSED && state != SOUNDSTATE.STOPPED && state != SOUNDSTATE.FORMING && soundOut != null)
            {
                soundOut.Pause();
                state = SOUNDSTATE.PAUSED;
            }
            else if(state == SOUNDSTATE.PAUSED && state != SOUNDSTATE.STOPPED && state != SOUNDSTATE.FORMING && soundOut != null)
            {
                Play();
            }
        }

        public void Play()
        {
            if (state != SOUNDSTATE.STOPPED && state != SOUNDSTATE.FORMING && soundOut != null)
            {
                soundOut.Play();
                state = SOUNDSTATE.PLAYING;
            }
        }

        private void WriteCompleate(object sender, SpeakCompletedEventArgs e)
        {
            manualReset.Set();
        }

        private void DonePlaying(object sender, PlaybackStoppedEventArgs e)
        {
            state = SOUNDSTATE.STOPPED;
            manualReset.Set();
            if (compleated != null)
                compleated.Invoke(Id);
        }

        private ISoundOut GetSoundOut()
        {
            if (WasapiOut.IsSupportedOnCurrentPlatform)
                return new WasapiOut();
            else
                return new DirectSoundOut();
        }

        private IWaveSource GetSoundSource(Stream stream)
        {
            return new WmaDecoder(stream);
        }

        public void Dispose()
        {
            soundOut.Dispose();
            flanger.Dispose();
            rev.Dispose();
            m_AudioStream.Dispose();
            GC.Collect();
        }
    }
}
