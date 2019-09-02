namespace puremvc
{
    partial class VoiceSpeaker
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
            this.jButton1 = new JHUI.Controls.JButton();
            this.jTextBox1 = new JHUI.Controls.JTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.jButton2 = new JHUI.Controls.JButton();
            this.jButton3 = new JHUI.Controls.JButton();
            this.jLabel1 = new JHUI.Controls.JLabel();
            this.SuspendLayout();
            // 
            // jButton1
            // 
            this.jButton1.Location = new System.Drawing.Point(390, 63);
            this.jButton1.Name = "jButton1";
            this.jButton1.Size = new System.Drawing.Size(75, 23);
            this.jButton1.Style = JHUI.JColorStyle.White;
            this.jButton1.TabIndex = 3;
            this.jButton1.Text = "Speak";
            this.jButton1.Theme = JHUI.JThemeStyle.Dark;
            this.jButton1.UseSelectable = true;
            this.jButton1.Click += new System.EventHandler(this.jButton1_Click);
            // 
            // jTextBox1
            // 
            this.jTextBox1.BorderBottomLineSize = 5;
            this.jTextBox1.BorderColor = System.Drawing.Color.Black;
            this.jTextBox1.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.jTextBox1.CustomButton.Image = null;
            this.jTextBox1.CustomButton.Location = new System.Drawing.Point(339, 1);
            this.jTextBox1.CustomButton.Name = "";
            this.jTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.jTextBox1.CustomButton.Style = JHUI.JColorStyle.White;
            this.jTextBox1.CustomButton.TabIndex = 1;
            this.jTextBox1.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox1.CustomButton.UseSelectable = true;
            this.jTextBox1.CustomButton.Visible = false;
            this.jTextBox1.DrawBorder = true;
            this.jTextBox1.DrawBorderBottomLine = false;
            this.jTextBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.jTextBox1.Lines = new string[0];
            this.jTextBox1.Location = new System.Drawing.Point(23, 63);
            this.jTextBox1.MaxLength = 32767;
            this.jTextBox1.Name = "jTextBox1";
            this.jTextBox1.PasswordChar = '\0';
            this.jTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.jTextBox1.SelectedText = "";
            this.jTextBox1.SelectionLength = 0;
            this.jTextBox1.SelectionStart = 0;
            this.jTextBox1.ShortcutsEnabled = true;
            this.jTextBox1.Size = new System.Drawing.Size(361, 23);
            this.jTextBox1.Style = JHUI.JColorStyle.White;
            this.jTextBox1.TabIndex = 7;
            this.jTextBox1.TextWaterMark = "Enter Text";
            this.jTextBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox1.UseCustomFont = true;
            this.jTextBox1.UseSelectable = true;
            this.jTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.jTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(577, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // jButton2
            // 
            this.jButton2.Location = new System.Drawing.Point(23, 141);
            this.jButton2.Name = "jButton2";
            this.jButton2.Size = new System.Drawing.Size(361, 23);
            this.jButton2.Style = JHUI.JColorStyle.White;
            this.jButton2.TabIndex = 12;
            this.jButton2.Text = "Save";
            this.jButton2.Theme = JHUI.JThemeStyle.Dark;
            this.jButton2.UseSelectable = true;
            this.jButton2.Click += new System.EventHandler(this.jButton2_Click);
            // 
            // jButton3
            // 
            this.jButton3.Location = new System.Drawing.Point(390, 103);
            this.jButton3.Name = "jButton3";
            this.jButton3.Size = new System.Drawing.Size(75, 23);
            this.jButton3.Style = JHUI.JColorStyle.White;
            this.jButton3.TabIndex = 14;
            this.jButton3.Text = "Browse";
            this.jButton3.Theme = JHUI.JThemeStyle.Dark;
            this.jButton3.UseSelectable = true;
            this.jButton3.Click += new System.EventHandler(this.jButton3_Click);
            // 
            // jLabel1
            // 
            this.jLabel1.DropShadowColor = System.Drawing.Color.Black;
            this.jLabel1.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.jLabel1.FontSize = JHUI.JLabelSize.Small;
            this.jLabel1.Location = new System.Drawing.Point(23, 103);
            this.jLabel1.Name = "jLabel1";
            this.jLabel1.Size = new System.Drawing.Size(361, 23);
            this.jLabel1.Style = JHUI.JColorStyle.White;
            this.jLabel1.TabIndex = 18;
            this.jLabel1.Text = "C:/";
            this.jLabel1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // VoiceSpeaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 177);
            this.Controls.Add(this.jLabel1);
            this.Controls.Add(this.jButton3);
            this.Controls.Add(this.jButton2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.jTextBox1);
            this.Controls.Add(this.jButton1);
            this.Name = "VoiceSpeaker";
            this.Text = "TTS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JHUI.Controls.JButton jButton1;
        private JHUI.Controls.JTextBox jTextBox1;
        private System.Windows.Forms.Label label1;
        private JHUI.Controls.JButton jButton2;
        private JHUI.Controls.JButton jButton3;
        private JHUI.Controls.JLabel jLabel1;
    }
}