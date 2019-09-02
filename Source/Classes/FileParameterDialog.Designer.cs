namespace puremvc
{
    partial class FileParameterDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileParameterDialog));
            this.jTextBox1 = new JHUI.Controls.JTextBox();
            this.SuspendLayout();
            // 
            // jTextBox1
            // 
            // 
            // 
            // 
            this.jTextBox1.CustomButton.Image = null;
            this.jTextBox1.CustomButton.Location = new System.Drawing.Point(294, 1);
            this.jTextBox1.CustomButton.Name = "";
            this.jTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.jTextBox1.CustomButton.Style = JHUI.JColorStyle.Gold;
            this.jTextBox1.CustomButton.TabIndex = 1;
            this.jTextBox1.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox1.CustomButton.UseSelectable = true;
            this.jTextBox1.CustomButton.Visible = false;
            this.jTextBox1.Lines = new string[0];
            this.jTextBox1.Location = new System.Drawing.Point(23, 64);
            this.jTextBox1.MaxLength = 32767;
            this.jTextBox1.Name = "jTextBox1";
            this.jTextBox1.PasswordChar = '\0';
            this.jTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.jTextBox1.SelectedText = "";
            this.jTextBox1.SelectionLength = 0;
            this.jTextBox1.SelectionStart = 0;
            this.jTextBox1.ShortcutsEnabled = true;
            this.jTextBox1.Size = new System.Drawing.Size(316, 23);
            this.jTextBox1.Style = JHUI.JColorStyle.Gold;
            this.jTextBox1.TabIndex = 0;
            this.jTextBox1.TextWaterMark = "Enter Parameters";
            this.jTextBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox1.UseSelectable = true;
            this.jTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.jTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 133);
            this.Controls.Add(this.jTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dialog";
            this.Text = "Dialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dialog_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        public JHUI.Controls.JTextBox jTextBox1;
    }
}