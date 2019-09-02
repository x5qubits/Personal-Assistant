using JHUI.Animation;
using JHUI.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using puremvc.Engine.Brain;
using System.IO;
using JHUI.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using JHUI.Utils;
using puremvc.Engine.Listen.SubClasses;
using puremvc.Properties;
using System.Collections.Generic;
using puremvc.Engine;

namespace puremvc
{
    public enum TaskPanelState
    {
        Smiling,
        Speaking,
        Listening,
        IDK,
        Exiting,
        NotListining,
        Pusseling,
        none
    }
    public partial class TaskPanel : JForm
    {
        static readonly public TaskPanel Instance = new TaskPanel();
        private float hideIn = 10;
        private float timeOut = 0;
        private float lastGeneratedTime = 0;
        private bool isclosing = false;
        private bool isrealyClosing = false;
        private TaskPanelState xstate = TaskPanelState.Smiling;
        private TaskPanelState lastState = TaskPanelState.Listening;
        private TaskPanelState state
        {
            get
            {
                return xstate;
            }
            set
            {
                xstate = value;
                Debug.WriteLine(xstate.ToString());
            }

        }
        private Random random = new Random();
        private List<Bitmap> allIDK;

        private TaskPanel()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Opacity = 1;
            foreach (var scrn in Screen.AllScreens)
            {
                if (scrn.Bounds.Contains(Location))
                {
                    Location = new Point(scrn.Bounds.Right - Width, scrn.Bounds.Top);
                    break;
                }
            }
            TheProcessor.Instance.init();
        }

        private void TaskPanel_Shown(object sender, EventArgs e)
        {
            ThinkingPictureBox.Image = Resources.Thinking;
            MouthManager.Instance.Speak(jLabel1.Text);
            timeOut = Time.time + 5;
            isclosing = true;
            EnableAnimation(false);
            MainListener.Instance.isCanUpdateTaskPanel = true;
        }

        public void TaskPanelUpdate()
        {
            if (EmoticionsPictureBox.InvokeRequired)
            {
                EmoticionsPictureBox.BeginInvoke((MethodInvoker)delegate
                {
                    if (lastState != state)
                    {
                        EmoticionsPictureBox.BackgroundImage = null;
                        EmoticionsPictureBox.Invalidate();
                        switch (state)
                        {
                            case TaskPanelState.Smiling:
                                EmoticionsPictureBox.BackgroundImage = Resources.smile;
                                lastState = TaskPanelState.Smiling;
                                EmoticionsPictureBox.Refresh();
                                break;
                            case TaskPanelState.Speaking:
                                EmoticionsPictureBox.BackgroundImage = Resources.Speaking;
                                lastState = TaskPanelState.Speaking;
                                EmoticionsPictureBox.Refresh();
                                break;
                            case TaskPanelState.IDK:
                                if (lastGeneratedTime < Time.time)
                                {
                                    allIDK = new List<Bitmap>() { Resources.frown, Resources.meh };
                                    int index = random.Next(allIDK.Count);
                                    var name = allIDK[index];
                                    EmoticionsPictureBox.BackgroundImage = name;
                                    lastGeneratedTime = Time.time + 60;
                                    lastState = TaskPanelState.IDK;
                                    EmoticionsPictureBox.Refresh();
                                }
                                break;
                            case TaskPanelState.Exiting:
                                EmoticionsPictureBox.BackgroundImage = Resources.Exiting;
                                lastState = TaskPanelState.Exiting;
                                EmoticionsPictureBox.Refresh();
                                break;
                            case TaskPanelState.NotListining:
                                EmoticionsPictureBox.BackgroundImage = Resources.NotListening;
                                lastState = TaskPanelState.NotListining;
                                EmoticionsPictureBox.Refresh();
                                break;
                            case TaskPanelState.Listening:
                                EmoticionsPictureBox.BackgroundImage = Resources.Listening;
                                lastState = TaskPanelState.Listening;
                                EmoticionsPictureBox.Refresh();
                                break;
                            case TaskPanelState.Pusseling:
                                EmoticionsPictureBox.BackgroundImage = Resources.idu0;
                                lastState = TaskPanelState.Pusseling;
                                EmoticionsPictureBox.Refresh();
                                break;
                        }
                    }

                });
            }
            if (this.InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                if (isclosing)
                {
                    if (timeOut < Time.time)
                    {
                        new JAnimate().FadeOutForm(this, 1, new Action(()=> { isclosing = false; } ));
                        }
                    }
                });
                return;
            }
            try
            {
                new JAnimate().FadeOutForm(this, 1);
            }
            catch { }

        }

        public void ShowNow(TaskPanelState _state)
        {
            if(this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    state = _state;
                    playShowSound();
                    new JAnimate().FadeInForm(this, 1);
                    isclosing = false;
                    Recenter();
                });
                return;
            }
            state = _state;
            playShowSound();
            new JAnimate().FadeInForm(this, 1);
            isclosing = false;
            Recenter();
        }

        private void playShowSound()
        {
            Stream str = Properties.Resources.tng_viewscreen_on;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
        }

        private void Recenter()
        {
            foreach (var scrn in Screen.AllScreens)
            {
                if (scrn.Bounds.Contains(this.Location))
                {
                    this.Location = new Point(scrn.Bounds.Right - this.Width, scrn.Bounds.Top);
                    return;
                }
            }
        }

        public void HidePanel()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    timeOut = Time.time + hideIn;
                    isclosing = true;
                    //lastState = TaskPanelState.Listening;
                    //state = TaskPanelState.NotListining;
                });
                return;
            }
            isclosing = true;
            timeOut = Time.time + hideIn;
            //lastState = TaskPanelState.Listening;
            //state = TaskPanelState.NotListining;
        }

        public void HideNow(int time = -1)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    state = TaskPanelState.Exiting;
                    timeOut = time;
                    isclosing = true;
                });
                return;
            }
            state = TaskPanelState.Exiting;
            isclosing = true;
            timeOut = time;
        }

        public void BotSay(string text)
        {
            if (jLabel1.InvokeRequired)
            {
                jLabel1.BeginInvoke((MethodInvoker)delegate
                {
                    jLabel1.Text = text;
                });
                return;
            }
            jLabel1.Text = text;
        }

        public void UserSay(string text, TaskPanelState _state)
        {
            if (jTextBox1.InvokeRequired)
            {
                jLabel1.BeginInvoke((MethodInvoker)delegate
                {
                    state = _state;
                    jTextBox1.Text = text;
                });
                return;
            }
            state = _state;
            jTextBox1.Text = text;
        }

        public void EnableAnimation(bool isEnable)
        {
            Debug.WriteLine("AnimationChangedStatus:" + isEnable);
            if (ThinkingPictureBox.InvokeRequired)
            {
                ThinkingPictureBox.BeginInvoke((MethodInvoker)delegate
                {
                    EnablePictureBox(isEnable);
                    ThinkingPictureBox.Visible = isEnable;
                    ThinkingPictureBox.Enabled = isEnable;
                    if(isEnable)
                        playShowSound2();
                });
                return;
            }
            if (isEnable)
                playShowSound2();

            EnablePictureBox(isEnable);
            ThinkingPictureBox.Visible = isEnable;
            ThinkingPictureBox.Enabled = isEnable;
        }

        private void playShowSound2()
        {
            EmoticionsPictureBox.BackgroundImage = Resources.NotListening;
            lastState = TaskPanelState.NotListining;
            EmoticionsPictureBox.Refresh();
            Stream str = Properties.Resources.UI_button_2;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
        }

        public void EnablePictureBox(bool isEnable)
        {
            if (ThinkingPictureBox.InvokeRequired)
            {
                ThinkingPictureBox.BeginInvoke((MethodInvoker)delegate
                {
                    if (isEnable)
                        new JAnimate().Start(EmoticionsPictureBox, 10, Effect.FadeOut, jPictureDisable);
                    else
                        new JAnimate().Start(EmoticionsPictureBox, 10, Effect.FadeIn, jPictureBox1enable);
                });
                return;
            }
            if (isEnable)
                new JAnimate().Start(EmoticionsPictureBox, 10, Effect.FadeOut, jPictureDisable);
            else
                new JAnimate().Start(EmoticionsPictureBox, 10, Effect.FadeIn, jPictureBox1enable);
        }

        private void jPictureBox1enable()
        {
            if (EmoticionsPictureBox.InvokeRequired)
            {
                EmoticionsPictureBox.BeginInvoke((MethodInvoker)delegate
                {
                    EmoticionsPictureBox.Visible = true;
                });
                return;
            }
            EmoticionsPictureBox.Visible = true;
        }

        private void jPictureDisable()
        {
            if (EmoticionsPictureBox.InvokeRequired)
            {
                EmoticionsPictureBox.BeginInvoke((MethodInvoker)delegate
                {
                    EmoticionsPictureBox.Visible = false;
                });
                return;
            }
            EmoticionsPictureBox.Visible = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (SolidBrush b = JPaint.GetStyleBrush(Style))
            {
                LinearGradientBrush linearGradientBrush = new LinearGradientBrush(this.ClientRectangle, Color.Red, Color.Yellow, 45);
                ColorBlend cblend = new ColorBlend(3);
                cblend.Colors = new Color[3] { Color.Black, Color.Magenta, Color.Gold};
                cblend.Positions = new float[3] { 0f, 0.1f, 1f };

                linearGradientBrush.InterpolationColors = cblend;
                Rectangle topRect = new Rectangle(0, 0, Width, 5);
                e.Graphics.FillRectangle(linearGradientBrush, topRect);
            }
        }
       
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isrealyClosing = true;
            Application.Exit();
        }

        private void TaskPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainListener.Instance.StopListening();
            HideNow();
            e.Cancel = !isrealyClosing;         
        }

        private void editDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseManager dbm = new DatabaseManager();
            dbm.Show();
        }

        private void testProcesorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestProcesor tp = new TestProcesor();
            tp.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings tp = new Settings();
            tp.Show();
        }

        public void openSettings()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    openSettings();
                });
                return;
            }
            Settings tp = new Settings();
            tp.Show();
            EnableAnimation(false);
            EmoticionsPictureBox.BackgroundImage = Resources.NotListening;
            lastState = TaskPanelState.NotListining;
            EmoticionsPictureBox.Refresh();
        }

        public void openConfigs()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    openConfigs();
                });
                return;
            }
            DatabaseManager tp = new DatabaseManager();
            tp.Show();
            EnableAnimation(false);
            EmoticionsPictureBox.BackgroundImage = Resources.NotListening;
            lastState = TaskPanelState.NotListining;
            EmoticionsPictureBox.Refresh();
        }

        public void openTests()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    openTests();
                });
                return;
            }
            TestProcesor tp = new TestProcesor();
            tp.Show();
            EnableAnimation(false);
            EmoticionsPictureBox.BackgroundImage = Resources.NotListening;
            lastState = TaskPanelState.NotListining;
            EmoticionsPictureBox.Refresh();
        }

        public void setClipBoardText(string data)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    setClipBoardText(data);
                });
                return;
            }
            Clipboard.SetText(data);
        }
    }
}
