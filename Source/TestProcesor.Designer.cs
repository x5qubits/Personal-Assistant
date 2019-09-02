namespace puremvc
{
    partial class TestProcesor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestProcesor));
            this.jTextBox1 = new JHUI.Controls.JTextBox();
            this.jButton1 = new JHUI.Controls.JButton();
            this.jTextBox2 = new JHUI.Controls.JTextBox();
            this.SuspendLayout();
            // 
            // jTextBox1
            // 
            // 
            // 
            // 
            this.jTextBox1.CustomButton.Image = null;
            this.jTextBox1.CustomButton.Location = new System.Drawing.Point(306, 1);
            this.jTextBox1.CustomButton.Name = "";
            this.jTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.jTextBox1.CustomButton.Style = JHUI.JColorStyle.Gold;
            this.jTextBox1.CustomButton.TabIndex = 1;
            this.jTextBox1.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox1.CustomButton.UseSelectable = true;
            this.jTextBox1.CustomButton.Visible = false;
            this.jTextBox1.Lines = new string[] {
        "Login fail, Please Try again!"};
            this.jTextBox1.Location = new System.Drawing.Point(24, 28);
            this.jTextBox1.MaxLength = 32767;
            this.jTextBox1.Name = "jTextBox1";
            this.jTextBox1.PasswordChar = '\0';
            this.jTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.jTextBox1.SelectedText = "";
            this.jTextBox1.SelectionLength = 0;
            this.jTextBox1.SelectionStart = 0;
            this.jTextBox1.ShortcutsEnabled = true;
            this.jTextBox1.Size = new System.Drawing.Size(328, 23);
            this.jTextBox1.Style = JHUI.JColorStyle.Gold;
            this.jTextBox1.TabIndex = 0;
            this.jTextBox1.Text = "Login fail, Please Try again!";
            this.jTextBox1.TextWaterMark = "";
            this.jTextBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox1.UseSelectable = true;
            this.jTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.jTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // jButton1
            // 
            this.jButton1.Location = new System.Drawing.Point(24, 138);
            this.jButton1.Name = "jButton1";
            this.jButton1.Size = new System.Drawing.Size(75, 23);
            this.jButton1.Style = JHUI.JColorStyle.Gold;
            this.jButton1.TabIndex = 1;
            this.jButton1.Text = "Process";
            this.jButton1.Theme = JHUI.JThemeStyle.Dark;
            this.jButton1.UseSelectable = true;
            this.jButton1.UseVisualStyleBackColor = true;
            this.jButton1.Click += new System.EventHandler(this.jButton1_Click);
            // 
            // jTextBox2
            // 
            // 
            // 
            // 
            this.jTextBox2.CustomButton.Image = null;
            this.jTextBox2.CustomButton.Location = new System.Drawing.Point(256, 2);
            this.jTextBox2.CustomButton.Name = "";
            this.jTextBox2.CustomButton.Size = new System.Drawing.Size(69, 69);
            this.jTextBox2.CustomButton.Style = JHUI.JColorStyle.Gold;
            this.jTextBox2.CustomButton.TabIndex = 1;
            this.jTextBox2.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox2.CustomButton.UseSelectable = true;
            this.jTextBox2.CustomButton.Visible = false;
            this.jTextBox2.Lines = new string[0];
            this.jTextBox2.Location = new System.Drawing.Point(24, 58);
            this.jTextBox2.MaxLength = 32767;
            this.jTextBox2.Multiline = true;
            this.jTextBox2.Name = "jTextBox2";
            this.jTextBox2.PasswordChar = '\0';
            this.jTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.jTextBox2.SelectedText = "";
            this.jTextBox2.SelectionLength = 0;
            this.jTextBox2.SelectionStart = 0;
            this.jTextBox2.ShortcutsEnabled = true;
            this.jTextBox2.Size = new System.Drawing.Size(328, 74);
            this.jTextBox2.Style = JHUI.JColorStyle.Gold;
            this.jTextBox2.TabIndex = 2;
            this.jTextBox2.TextWaterMark = "Result";
            this.jTextBox2.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox2.UseSelectable = true;
            this.jTextBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.jTextBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TestProcesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 172);
            this.Controls.Add(this.jTextBox2);
            this.Controls.Add(this.jButton1);
            this.Controls.Add(this.jTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestProcesor";
            this.ResumeLayout(false);

        }

        #endregion

        private JHUI.Controls.JTextBox jTextBox1;
        private JHUI.Controls.JButton jButton1;
        private JHUI.Controls.JTextBox jTextBox2;
    }
}