namespace puremvc
{
    partial class TaskPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskPanel));
            this.ThinkingPictureBox = new System.Windows.Forms.PictureBox();
            this.Source = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.testProcesorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jTextBox1 = new JHUI.Controls.JTextBox();
            this.jLabel1 = new JHUI.Controls.JLabel();
            this.EmoticionsPictureBox = new JHUI.Controls.JPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ThinkingPictureBox)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmoticionsPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ThinkingPictureBox
            // 
            this.ThinkingPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ThinkingPictureBox.Image = global::puremvc.Properties.Resources.Thinking;
            this.ThinkingPictureBox.Location = new System.Drawing.Point(7, 12);
            this.ThinkingPictureBox.Name = "ThinkingPictureBox";
            this.ThinkingPictureBox.Size = new System.Drawing.Size(100, 100);
            this.ThinkingPictureBox.TabIndex = 0;
            this.ThinkingPictureBox.TabStop = false;
            // 
            // Source
            // 
            this.Source.ContextMenuStrip = this.contextMenuStrip1;
            this.Source.Icon = ((System.Drawing.Icon)(resources.GetObject("Source.Icon")));
            this.Source.Text = "Source";
            this.Source.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testProcesorToolStripMenuItem,
            this.editDatabaseToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(146, 98);
            // 
            // testProcesorToolStripMenuItem
            // 
            this.testProcesorToolStripMenuItem.Name = "testProcesorToolStripMenuItem";
            this.testProcesorToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.testProcesorToolStripMenuItem.Text = "Test Procesor";
            this.testProcesorToolStripMenuItem.Click += new System.EventHandler(this.testProcesorToolStripMenuItem_Click);
            // 
            // editDatabaseToolStripMenuItem
            // 
            this.editDatabaseToolStripMenuItem.Name = "editDatabaseToolStripMenuItem";
            this.editDatabaseToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.editDatabaseToolStripMenuItem.Text = "Edit Database";
            this.editDatabaseToolStripMenuItem.Click += new System.EventHandler(this.editDatabaseToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(142, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // jTextBox1
            // 
            // 
            // 
            // 
            this.jTextBox1.CustomButton.Image = null;
            this.jTextBox1.CustomButton.Location = new System.Drawing.Point(187, 2);
            this.jTextBox1.CustomButton.Name = "";
            this.jTextBox1.CustomButton.Size = new System.Drawing.Size(63, 63);
            this.jTextBox1.CustomButton.Style = JHUI.JColorStyle.Gold;
            this.jTextBox1.CustomButton.TabIndex = 1;
            this.jTextBox1.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox1.CustomButton.UseSelectable = true;
            this.jTextBox1.CustomButton.Visible = false;
            this.jTextBox1.Enabled = false;
            this.jTextBox1.Lines = new string[0];
            this.jTextBox1.Location = new System.Drawing.Point(114, 44);
            this.jTextBox1.MaxLength = 32767;
            this.jTextBox1.Multiline = true;
            this.jTextBox1.Name = "jTextBox1";
            this.jTextBox1.PasswordChar = '\0';
            this.jTextBox1.ReadOnly = true;
            this.jTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.jTextBox1.SelectedText = "";
            this.jTextBox1.SelectionLength = 0;
            this.jTextBox1.SelectionStart = 0;
            this.jTextBox1.ShortcutsEnabled = true;
            this.jTextBox1.Size = new System.Drawing.Size(253, 68);
            this.jTextBox1.Style = JHUI.JColorStyle.Gold;
            this.jTextBox1.TabIndex = 3;
            this.jTextBox1.TextWaterMark = "";
            this.jTextBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox1.UseCustomBackColor = true;
            this.jTextBox1.UseSelectable = true;
            this.jTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.jTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // jLabel1
            // 
            this.jLabel1.AutoSize = true;
            this.jLabel1.Location = new System.Drawing.Point(114, 12);
            this.jLabel1.Name = "jLabel1";
            this.jLabel1.Size = new System.Drawing.Size(119, 19);
            this.jLabel1.Style = JHUI.JColorStyle.Gold;
            this.jLabel1.TabIndex = 4;
            this.jLabel1.Text = "Hello, I am Source.";
            this.jLabel1.Theme = JHUI.JThemeStyle.Dark;
            this.jLabel1.UseCustomBackColor = true;
            // 
            // EmoticionsPictureBox
            // 
            this.EmoticionsPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.EmoticionsPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EmoticionsPictureBox.Location = new System.Drawing.Point(7, 12);
            this.EmoticionsPictureBox.Name = "EmoticionsPictureBox";
            this.EmoticionsPictureBox.Size = new System.Drawing.Size(100, 100);
            this.EmoticionsPictureBox.Style = JHUI.JColorStyle.Gold;
            this.EmoticionsPictureBox.TabIndex = 5;
            this.EmoticionsPictureBox.TabStop = false;
            this.EmoticionsPictureBox.Theme = JHUI.JThemeStyle.Dark;
            // 
            // TaskPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(370, 122);
            this.Controls.Add(this.EmoticionsPictureBox);
            this.Controls.Add(this.jLabel1);
            this.Controls.Add(this.jTextBox1);
            this.Controls.Add(this.ThinkingPictureBox);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskPanel";
            this.Resizable = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.UseCustomBackColor = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskPanel_FormClosing);
            this.Shown += new System.EventHandler(this.TaskPanel_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ThinkingPictureBox)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EmoticionsPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ThinkingPictureBox;
        private System.Windows.Forms.NotifyIcon Source;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private JHUI.Controls.JTextBox jTextBox1;
        private JHUI.Controls.JLabel jLabel1;
        private JHUI.Controls.JPictureBox EmoticionsPictureBox;
        private System.Windows.Forms.ToolStripMenuItem testProcesorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}