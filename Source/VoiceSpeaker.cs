using JHUI;
using JHUI.Forms;
using puremvc.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace puremvc
{
    public partial class VoiceSpeaker : JForm
    {
        private MouthManager SoundManager;
        private OrderSound speaches;
        private string path = @"C:\";
        public VoiceSpeaker()
        {
            SoundManager = MouthManager.Instance;
            InitializeComponent();
        }

        private void jButton2_Click(object sender, EventArgs e)
        {
            if (speaches != null)
            {
                path = Path.Combine(jLabel1.Text, "sound_" + speaches.Id + ".mp3");

                File.WriteAllBytes(path, speaches.m_AudioStream2.ToArray());
                JMessageBox.Show(this, "Done!");
            }
        }

        private void jButton1_Click(object sender, EventArgs e)
        {
            SoundManager.CustomSpeak(jTextBox1.Text, OnSoundCompleate);
        }

        private void OnSoundCompleate(int obj)
        {
            speaches = SoundManager.GetSound(obj);
            SoundManager.OnCompleate2(obj);
        }

        private void jButton3_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    jLabel1.Text = fbd.SelectedPath;
                    
                }
            }
        }
    }
}
