using CSCore;
using CSCore.Codecs.WMA;
using CSCore.SoundOut;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace puremvc.Engine
{
    public sealed class MouthManager
    {
        static readonly public MouthManager Instance = new MouthManager();
        public float Depth = 1;
        public float Frequency = 1;
        public float Feedback = 80;
        public float WetDryMix = 55;
        public float ReverbTime = 200;
        public float HighFrequencyRTRatio = 0.999f;

        //OLD CONFIGS
        public float Depth2 = 1;
        public float Frequency2 = 1;
        public float Feedback2 = 80;
        public float WetDryMix2 = 55;
        public float ReverbTime2 = 200;
        public float HighFrequencyRTRatio2 = 0.999f;


        private int COUNTER;
        public SortedList<int, OrderSound> speaches = new SortedList<int, OrderSound>();
        private OrderSound paused = null;
        private MouthManager(){}

        public int Speak(string message)
        {
            Debug.WriteLine("Speaking:" + message);
            OrderSound sound = new OrderSound(message, Depth2, Frequency2, Feedback2, WetDryMix2, ReverbTime2, HighFrequencyRTRatio2);
            Interlocked.Increment(ref COUNTER);
            sound.Id = COUNTER;
            sound.compleated = OnCompleate;
            speaches[sound.Id] = sound;
            return sound.Id;
        }

        public int CustomSpeak(string message, Action<int> compleated)
        {
            Debug.WriteLine("Speaking:" + message);
            OrderSound sound = new OrderSound(message, Depth, Frequency, Feedback, WetDryMix, ReverbTime, HighFrequencyRTRatio);
            sound.Rate = 1;
            Interlocked.Increment(ref COUNTER);
            sound.Id = COUNTER;
            sound.compleated = compleated;
            speaches[sound.Id] = sound;
            return sound.Id;
        }
        public void OnCompleate2(int id)
        {
            if (speaches.ContainsKey(id))
            {
                if (paused != null && paused.Id == id)
                {
                    paused = null;
                }

                speaches[id].Dispose();
                speaches.Remove(id);

            }
        }
        public void OnCompleate(int id)
        {
            if (speaches.ContainsKey(id))
            {
                if (paused != null && paused.Id == id)
                {
                    paused = null;
                }
                
                speaches[id].Dispose();
                speaches.Remove(id);
                TaskPanel.Instance.EnableAnimation(false);
            }
        }

        public OrderSound GetSound(int id)
        {
            if (speaches.TryGetValue(id, out OrderSound sound))
                return sound;
            else
                return null;
        }

        public void StopAll()
        {
            foreach (OrderSound snd in speaches.Values)
                snd.Pause();
        }

        public void Pause(int id)
        {
            if(paused != null && paused.state == SOUNDSTATE.PAUSED)
            {
                return;
            }
            if (speaches.ContainsKey(id))
            {
                speaches[id].Pause();
            }
        }
    }
}
