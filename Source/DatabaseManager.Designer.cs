using JHUI.Controls;

namespace puremvc
{
    partial class DatabaseManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseManager));
            this.jTabControl1 = new JHUI.Controls.JTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.jLabel5 = new JHUI.Controls.JLabel();
            this.jLabel4 = new JHUI.Controls.JLabel();
            this.jTextBox1 = new JHUI.Controls.JTextBox();
            this.jLabel3 = new JHUI.Controls.JLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.jLabel2 = new JHUI.Controls.JLabel();
            this.StartPrgramsFromList = new JHUI.Controls.JToggle();
            this.jLabel13 = new JHUI.Controls.JLabel();
            this.LearnDialog = new JHUI.Controls.JToggle();
            this.jLabel12 = new JHUI.Controls.JLabel();
            this.jLabel11 = new JHUI.Controls.JLabel();
            this.isMathQuestion = new JHUI.Controls.JToggle();
            this.jLabel10 = new JHUI.Controls.JLabel();
            this.hasSearchInFiles = new JHUI.Controls.JToggle();
            this.jLabel8 = new JHUI.Controls.JLabel();
            this.hasSearchInWeb = new JHUI.Controls.JToggle();
            this.cancelTextBox = new JHUI.Controls.JTextBox();
            this.confirmTextBox = new JHUI.Controls.JTextBox();
            this.jLabel9 = new JHUI.Controls.JLabel();
            this.hasAnswer = new JHUI.Controls.JToggle();
            this.AnswerGrid = new JHUI.Controls.JDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnswerContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.jLabel7 = new JHUI.Controls.JLabel();
            this.hasConfirmDialog = new JHUI.Controls.JToggle();
            this.jLabel6 = new JHUI.Controls.JLabel();
            this.OpenSpecificProgramWithParameters = new JHUI.Controls.JToggle();
            this.jLabel1 = new JHUI.Controls.JLabel();
            this.jProgressSpinner1 = new JHUI.Controls.JProgressSpinner();
            this.IntentContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.regenerateDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox_items = new JHUI.Controls.JDataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectedCategory = new JHUI.Controls.JComboBox();
            this.jContextMenu1 = new JHUI.Controls.JContextMenu(this.components);
            this.saveDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerGrid)).BeginInit();
            this.AnswerContextMenu.SuspendLayout();
            this.IntentContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBox_items)).BeginInit();
            this.jContextMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // jTabControl1
            // 
            this.jTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jTabControl1.Controls.Add(this.tabPage1);
            this.jTabControl1.Controls.Add(this.tabPage2);
            this.jTabControl1.Location = new System.Drawing.Point(290, 27);
            this.jTabControl1.Name = "jTabControl1";
            this.jTabControl1.Padding = new System.Drawing.Point(6, 8);
            this.jTabControl1.SelectedIndex = 0;
            this.jTabControl1.Size = new System.Drawing.Size(650, 559);
            this.jTabControl1.Style = JHUI.JColorStyle.Blue;
            this.jTabControl1.TabIndex = 0;
            this.jTabControl1.Theme = JHUI.JThemeStyle.Dark;
            this.jTabControl1.UseSelectable = true;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.tabPage1.Controls.Add(this.jLabel5);
            this.tabPage1.Controls.Add(this.jLabel4);
            this.tabPage1.Controls.Add(this.jTextBox1);
            this.tabPage1.Controls.Add(this.jLabel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(642, 517);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Utterance";
            // 
            // jLabel5
            // 
            this.jLabel5.AutoSize = true;
            this.jLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jLabel5.Location = new System.Drawing.Point(6, 111);
            this.jLabel5.Name = "jLabel5";
            this.jLabel5.Size = new System.Drawing.Size(138, 19);
            this.jLabel5.Style = JHUI.JColorStyle.Gold;
            this.jLabel5.TabIndex = 38;
            this.jLabel5.Text = "Use _ for any sentince.";
            this.jLabel5.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jLabel4
            // 
            this.jLabel4.AutoSize = true;
            this.jLabel4.Location = new System.Drawing.Point(6, 78);
            this.jLabel4.Name = "jLabel4";
            this.jLabel4.Size = new System.Drawing.Size(313, 19);
            this.jLabel4.Style = JHUI.JColorStyle.Gold;
            this.jLabel4.TabIndex = 37;
            this.jLabel4.Text = "Use * for any word that can be used as a parameter.";
            this.jLabel4.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jTextBox1
            // 
            this.jTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.jTextBox1.CustomButton.Image = null;
            this.jTextBox1.CustomButton.Location = new System.Drawing.Point(605, 1);
            this.jTextBox1.CustomButton.Name = "";
            this.jTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.jTextBox1.CustomButton.Style = JHUI.JColorStyle.Gold;
            this.jTextBox1.CustomButton.TabIndex = 1;
            this.jTextBox1.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox1.CustomButton.UseSelectable = true;
            this.jTextBox1.CustomButton.Visible = false;
            this.jTextBox1.Lines = new string[0];
            this.jTextBox1.Location = new System.Drawing.Point(9, 33);
            this.jTextBox1.MaxLength = 32767;
            this.jTextBox1.Name = "jTextBox1";
            this.jTextBox1.PasswordChar = '\0';
            this.jTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.jTextBox1.SelectedText = "";
            this.jTextBox1.SelectionLength = 0;
            this.jTextBox1.SelectionStart = 0;
            this.jTextBox1.ShortcutsEnabled = true;
            this.jTextBox1.Size = new System.Drawing.Size(627, 23);
            this.jTextBox1.Style = JHUI.JColorStyle.Gold;
            this.jTextBox1.TabIndex = 36;
            this.jTextBox1.TextWaterMark = "";
            this.jTextBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox1.UseSelectable = true;
            this.jTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.jTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.jTextBox1.Leave += new System.EventHandler(this.jTextBox1_Leave);
            // 
            // jLabel3
            // 
            this.jLabel3.AutoSize = true;
            this.jLabel3.Location = new System.Drawing.Point(6, 10);
            this.jLabel3.Name = "jLabel3";
            this.jLabel3.Size = new System.Drawing.Size(312, 19);
            this.jLabel3.Style = JHUI.JColorStyle.Gold;
            this.jLabel3.TabIndex = 34;
            this.jLabel3.Text = "The action of saying or expressing something aloud.";
            this.jLabel3.Theme = JHUI.JThemeStyle.Dark;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.tabPage2.Controls.Add(this.jLabel2);
            this.tabPage2.Controls.Add(this.StartPrgramsFromList);
            this.tabPage2.Controls.Add(this.jLabel13);
            this.tabPage2.Controls.Add(this.LearnDialog);
            this.tabPage2.Controls.Add(this.jLabel12);
            this.tabPage2.Controls.Add(this.jLabel11);
            this.tabPage2.Controls.Add(this.isMathQuestion);
            this.tabPage2.Controls.Add(this.jLabel10);
            this.tabPage2.Controls.Add(this.hasSearchInFiles);
            this.tabPage2.Controls.Add(this.jLabel8);
            this.tabPage2.Controls.Add(this.hasSearchInWeb);
            this.tabPage2.Controls.Add(this.cancelTextBox);
            this.tabPage2.Controls.Add(this.confirmTextBox);
            this.tabPage2.Controls.Add(this.jLabel9);
            this.tabPage2.Controls.Add(this.hasAnswer);
            this.tabPage2.Controls.Add(this.AnswerGrid);
            this.tabPage2.Controls.Add(this.jLabel7);
            this.tabPage2.Controls.Add(this.hasConfirmDialog);
            this.tabPage2.Controls.Add(this.jLabel6);
            this.tabPage2.Controls.Add(this.OpenSpecificProgramWithParameters);
            this.tabPage2.Controls.Add(this.jLabel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(642, 517);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Execution";
            // 
            // jLabel2
            // 
            this.jLabel2.AutoSize = true;
            this.jLabel2.Location = new System.Drawing.Point(6, 118);
            this.jLabel2.Name = "jLabel2";
            this.jLabel2.Size = new System.Drawing.Size(202, 19);
            this.jLabel2.Style = JHUI.JColorStyle.Gold;
            this.jLabel2.TabIndex = 59;
            this.jLabel2.Text = "Convert Star to Program Name?";
            this.jLabel2.Theme = JHUI.JThemeStyle.Dark;
            // 
            // StartPrgramsFromList
            // 
            this.StartPrgramsFromList.AutoSize = true;
            this.StartPrgramsFromList.Location = new System.Drawing.Point(270, 120);
            this.StartPrgramsFromList.Name = "StartPrgramsFromList";
            this.StartPrgramsFromList.Size = new System.Drawing.Size(80, 17);
            this.StartPrgramsFromList.Style = JHUI.JColorStyle.Blue;
            this.StartPrgramsFromList.TabIndex = 58;
            this.StartPrgramsFromList.Text = "&Off";
            this.StartPrgramsFromList.Theme = JHUI.JThemeStyle.Dark;
            this.StartPrgramsFromList.UseSelectable = true;
            this.StartPrgramsFromList.UseVisualStyleBackColor = true;
            this.StartPrgramsFromList.CheckedChanged += new System.EventHandler(this.jToggle1_CheckedChanged);
            // 
            // jLabel13
            // 
            this.jLabel13.AutoSize = true;
            this.jLabel13.Location = new System.Drawing.Point(7, 38);
            this.jLabel13.Name = "jLabel13";
            this.jLabel13.Size = new System.Drawing.Size(117, 19);
            this.jLabel13.Style = JHUI.JColorStyle.Gold;
            this.jLabel13.TabIndex = 57;
            this.jLabel13.Text = "Start Learn Guide?";
            this.jLabel13.Theme = JHUI.JThemeStyle.Dark;
            // 
            // LearnDialog
            // 
            this.LearnDialog.AutoSize = true;
            this.LearnDialog.Location = new System.Drawing.Point(270, 40);
            this.LearnDialog.Name = "LearnDialog";
            this.LearnDialog.Size = new System.Drawing.Size(80, 17);
            this.LearnDialog.Style = JHUI.JColorStyle.Blue;
            this.LearnDialog.TabIndex = 56;
            this.LearnDialog.Text = "&Off";
            this.LearnDialog.Theme = JHUI.JThemeStyle.Dark;
            this.LearnDialog.UseSelectable = true;
            this.LearnDialog.UseVisualStyleBackColor = true;
            this.LearnDialog.CheckedChanged += new System.EventHandler(this.LearnDialog_CheckedChanged);
            // 
            // jLabel12
            // 
            this.jLabel12.AutoSize = true;
            this.jLabel12.Location = new System.Drawing.Point(362, 94);
            this.jLabel12.Name = "jLabel12";
            this.jLabel12.Size = new System.Drawing.Size(13, 19);
            this.jLabel12.Style = JHUI.JColorStyle.Gold;
            this.jLabel12.TabIndex = 55;
            this.jLabel12.Text = " ";
            this.jLabel12.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jLabel11
            // 
            this.jLabel11.AutoSize = true;
            this.jLabel11.Location = new System.Drawing.Point(7, 198);
            this.jLabel11.Name = "jLabel11";
            this.jLabel11.Size = new System.Drawing.Size(113, 19);
            this.jLabel11.Style = JHUI.JColorStyle.Gold;
            this.jLabel11.TabIndex = 54;
            this.jLabel11.Text = "Is Math Question?";
            this.jLabel11.Theme = JHUI.JThemeStyle.Dark;
            // 
            // isMathQuestion
            // 
            this.isMathQuestion.AutoSize = true;
            this.isMathQuestion.Location = new System.Drawing.Point(270, 200);
            this.isMathQuestion.Name = "isMathQuestion";
            this.isMathQuestion.Size = new System.Drawing.Size(80, 17);
            this.isMathQuestion.Style = JHUI.JColorStyle.Blue;
            this.isMathQuestion.TabIndex = 53;
            this.isMathQuestion.Text = "&Off";
            this.isMathQuestion.Theme = JHUI.JThemeStyle.Dark;
            this.isMathQuestion.UseSelectable = true;
            this.isMathQuestion.UseVisualStyleBackColor = true;
            this.isMathQuestion.CheckedChanged += new System.EventHandler(this.IsMathQuestion_CheckedChanged);
            // 
            // jLabel10
            // 
            this.jLabel10.AutoSize = true;
            this.jLabel10.Location = new System.Drawing.Point(6, 173);
            this.jLabel10.Name = "jLabel10";
            this.jLabel10.Size = new System.Drawing.Size(143, 19);
            this.jLabel10.Style = JHUI.JColorStyle.Gold;
            this.jLabel10.TabIndex = 52;
            this.jLabel10.Text = "Is Search in Local Files?";
            this.jLabel10.Theme = JHUI.JThemeStyle.Dark;
            // 
            // hasSearchInFiles
            // 
            this.hasSearchInFiles.AutoSize = true;
            this.hasSearchInFiles.Location = new System.Drawing.Point(270, 175);
            this.hasSearchInFiles.Name = "hasSearchInFiles";
            this.hasSearchInFiles.Size = new System.Drawing.Size(80, 17);
            this.hasSearchInFiles.Style = JHUI.JColorStyle.Blue;
            this.hasSearchInFiles.TabIndex = 51;
            this.hasSearchInFiles.Text = "&Off";
            this.hasSearchInFiles.Theme = JHUI.JThemeStyle.Dark;
            this.hasSearchInFiles.UseSelectable = true;
            this.hasSearchInFiles.UseVisualStyleBackColor = true;
            this.hasSearchInFiles.CheckedChanged += new System.EventHandler(this.hasSearchInFiles_CheckedChanged);
            // 
            // jLabel8
            // 
            this.jLabel8.AutoSize = true;
            this.jLabel8.Location = new System.Drawing.Point(6, 147);
            this.jLabel8.Name = "jLabel8";
            this.jLabel8.Size = new System.Drawing.Size(108, 19);
            this.jLabel8.Style = JHUI.JColorStyle.Gold;
            this.jLabel8.TabIndex = 50;
            this.jLabel8.Text = "Is Serach in web?";
            this.jLabel8.Theme = JHUI.JThemeStyle.Dark;
            // 
            // hasSearchInWeb
            // 
            this.hasSearchInWeb.AutoSize = true;
            this.hasSearchInWeb.Location = new System.Drawing.Point(270, 149);
            this.hasSearchInWeb.Name = "hasSearchInWeb";
            this.hasSearchInWeb.Size = new System.Drawing.Size(80, 17);
            this.hasSearchInWeb.Style = JHUI.JColorStyle.Blue;
            this.hasSearchInWeb.TabIndex = 49;
            this.hasSearchInWeb.Text = "&Off";
            this.hasSearchInWeb.Theme = JHUI.JThemeStyle.Dark;
            this.hasSearchInWeb.UseSelectable = true;
            this.hasSearchInWeb.UseVisualStyleBackColor = true;
            this.hasSearchInWeb.CheckedChanged += new System.EventHandler(this.hasSearchInWeb_CheckedChanged);
            // 
            // cancelTextBox
            // 
            // 
            // 
            // 
            this.cancelTextBox.CustomButton.Image = null;
            this.cancelTextBox.CustomButton.Location = new System.Drawing.Point(112, 1);
            this.cancelTextBox.CustomButton.Name = "";
            this.cancelTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.cancelTextBox.CustomButton.Style = JHUI.JColorStyle.Gold;
            this.cancelTextBox.CustomButton.TabIndex = 1;
            this.cancelTextBox.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.cancelTextBox.CustomButton.UseSelectable = true;
            this.cancelTextBox.CustomButton.Visible = false;
            this.cancelTextBox.Lines = new string[0];
            this.cancelTextBox.Location = new System.Drawing.Point(502, 64);
            this.cancelTextBox.MaxLength = 32767;
            this.cancelTextBox.Name = "cancelTextBox";
            this.cancelTextBox.PasswordChar = '\0';
            this.cancelTextBox.Text = "Cancel (EG NO)";
            this.cancelTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.cancelTextBox.SelectedText = "";
            this.cancelTextBox.SelectionLength = 0;
            this.cancelTextBox.SelectionStart = 0;
            this.cancelTextBox.ShortcutsEnabled = true;
            this.cancelTextBox.Size = new System.Drawing.Size(134, 23);
            this.cancelTextBox.Style = JHUI.JColorStyle.Blue;
            this.cancelTextBox.TabIndex = 46;
            this.cancelTextBox.TextWaterMark = "Cancel (EG NO)";
            this.cancelTextBox.Theme = JHUI.JThemeStyle.Dark;
            this.cancelTextBox.UseSelectable = true;
            this.cancelTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cancelTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.cancelTextBox.Leave += new System.EventHandler(this.cancelTextBox_Leave);
            // 
            // confirmTextBox
            // 
            // 
            // 
            // 
            this.confirmTextBox.CustomButton.Image = null;
            this.confirmTextBox.CustomButton.Location = new System.Drawing.Point(109, 1);
            this.confirmTextBox.CustomButton.Name = "";
            this.confirmTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.confirmTextBox.CustomButton.Style = JHUI.JColorStyle.Gold;
            this.confirmTextBox.CustomButton.TabIndex = 1;
            this.confirmTextBox.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.confirmTextBox.CustomButton.UseSelectable = true;
            this.confirmTextBox.CustomButton.Visible = false;
            this.confirmTextBox.Lines = new string[0];
            this.confirmTextBox.Location = new System.Drawing.Point(365, 64);
            this.confirmTextBox.MaxLength = 32767;
            this.confirmTextBox.Name = "confirmTextBox";
            this.confirmTextBox.PasswordChar = '\0';
            this.confirmTextBox.Text = "Continue (EG YES)";
            this.confirmTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.confirmTextBox.SelectedText = "";
            this.confirmTextBox.SelectionLength = 0;
            this.confirmTextBox.SelectionStart = 0;
            this.confirmTextBox.ShortcutsEnabled = true;
            this.confirmTextBox.Size = new System.Drawing.Size(131, 23);
            this.confirmTextBox.Style = JHUI.JColorStyle.Blue;
            this.confirmTextBox.TabIndex = 45;
            this.confirmTextBox.TextWaterMark = "Continue (EG YES)";
            this.confirmTextBox.Theme = JHUI.JThemeStyle.Dark;
            this.confirmTextBox.UseSelectable = true;
            this.confirmTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.confirmTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.confirmTextBox.Leave += new System.EventHandler(this.confirmTextBox_Leave);
            // 
            // jLabel9
            // 
            this.jLabel9.AutoSize = true;
            this.jLabel9.Location = new System.Drawing.Point(6, 278);
            this.jLabel9.Name = "jLabel9";
            this.jLabel9.Size = new System.Drawing.Size(78, 19);
            this.jLabel9.Style = JHUI.JColorStyle.Gold;
            this.jLabel9.TabIndex = 44;
            this.jLabel9.Text = "Has Replay?";
            this.jLabel9.Theme = JHUI.JThemeStyle.Dark;
            // 
            // hasAnswer
            // 
            this.hasAnswer.AutoSize = true;
            this.hasAnswer.Location = new System.Drawing.Point(270, 280);
            this.hasAnswer.Name = "hasAnswer";
            this.hasAnswer.Size = new System.Drawing.Size(80, 17);
            this.hasAnswer.Style = JHUI.JColorStyle.Blue;
            this.hasAnswer.TabIndex = 43;
            this.hasAnswer.Text = "&Off";
            this.hasAnswer.Theme = JHUI.JThemeStyle.Dark;
            this.hasAnswer.UseSelectable = true;
            this.hasAnswer.UseVisualStyleBackColor = true;
            this.hasAnswer.CheckedChanged += new System.EventHandler(this.hasAnswer_CheckedChanged);
            // 
            // AnswerGrid
            // 
            this.AnswerGrid.AllowUserToAddRows = false;
            this.AnswerGrid.AllowUserToDeleteRows = false;
            this.AnswerGrid.AllowUserToResizeColumns = false;
            this.AnswerGrid.AllowUserToResizeRows = false;
            this.AnswerGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnswerGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.AnswerGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AnswerGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.AnswerGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.AnswerGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AnswerGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.AnswerGrid.ColumnHeadersHeight = 30;
            this.AnswerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.AnswerGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.AnswerGrid.ContextMenuStrip = this.AnswerContextMenu;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AnswerGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.AnswerGrid.EnableHeadersVisualStyles = false;
            this.AnswerGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.AnswerGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.AnswerGrid.Location = new System.Drawing.Point(6, 303);
            this.AnswerGrid.Name = "AnswerGrid";
            this.AnswerGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AnswerGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.AnswerGrid.RowHeadersVisible = false;
            this.AnswerGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.AnswerGrid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.AnswerGrid.RowTemplate.Height = 30;
            this.AnswerGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AnswerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AnswerGrid.Size = new System.Drawing.Size(630, 209);
            this.AnswerGrid.Style = JHUI.JColorStyle.Blue;
            this.AnswerGrid.TabIndex = 41;
            this.AnswerGrid.Theme = JHUI.JThemeStyle.Dark;
            this.AnswerGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.AnswerGrid_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "What would you like program to respond?";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AnswerContextMenu
            // 
            this.AnswerContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.AnswerContextMenu.Name = "contextMenuStrip1";
            this.AnswerContextMenu.Size = new System.Drawing.Size(108, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem1.Text = "Add";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.AddAnswer);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem2.Text = "Delete";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // jLabel7
            // 
            this.jLabel7.AutoSize = true;
            this.jLabel7.Location = new System.Drawing.Point(6, 64);
            this.jLabel7.Name = "jLabel7";
            this.jLabel7.Size = new System.Drawing.Size(134, 19);
            this.jLabel7.Style = JHUI.JColorStyle.Gold;
            this.jLabel7.TabIndex = 38;
            this.jLabel7.Text = "Confirmation Dialog?";
            this.jLabel7.Theme = JHUI.JThemeStyle.Dark;
            // 
            // hasConfirmDialog
            // 
            this.hasConfirmDialog.AutoSize = true;
            this.hasConfirmDialog.Location = new System.Drawing.Point(270, 66);
            this.hasConfirmDialog.Name = "hasConfirmDialog";
            this.hasConfirmDialog.Size = new System.Drawing.Size(80, 17);
            this.hasConfirmDialog.Style = JHUI.JColorStyle.Blue;
            this.hasConfirmDialog.TabIndex = 37;
            this.hasConfirmDialog.Text = "&Off";
            this.hasConfirmDialog.Theme = JHUI.JThemeStyle.Dark;
            this.hasConfirmDialog.UseSelectable = true;
            this.hasConfirmDialog.UseVisualStyleBackColor = true;
            this.hasConfirmDialog.CheckedChanged += new System.EventHandler(this.hasConfirmDialog_CheckedChanged);
            // 
            // jLabel6
            // 
            this.jLabel6.AutoSize = true;
            this.jLabel6.Location = new System.Drawing.Point(6, 91);
            this.jLabel6.Name = "jLabel6";
            this.jLabel6.Size = new System.Drawing.Size(245, 19);
            this.jLabel6.Style = JHUI.JColorStyle.Gold;
            this.jLabel6.TabIndex = 36;
            this.jLabel6.Text = "Start Specific Program with Parameters?";
            this.jLabel6.Theme = JHUI.JThemeStyle.Dark;
            // 
            // OpenSpecificProgramWithParameters
            // 
            this.OpenSpecificProgramWithParameters.AutoSize = true;
            this.OpenSpecificProgramWithParameters.Location = new System.Drawing.Point(270, 93);
            this.OpenSpecificProgramWithParameters.Name = "OpenSpecificProgramWithParameters";
            this.OpenSpecificProgramWithParameters.Size = new System.Drawing.Size(80, 17);
            this.OpenSpecificProgramWithParameters.Style = JHUI.JColorStyle.Blue;
            this.OpenSpecificProgramWithParameters.TabIndex = 35;
            this.OpenSpecificProgramWithParameters.Text = "&Off";
            this.OpenSpecificProgramWithParameters.Theme = JHUI.JThemeStyle.Dark;
            this.OpenSpecificProgramWithParameters.UseSelectable = true;
            this.OpenSpecificProgramWithParameters.UseVisualStyleBackColor = true;
            this.OpenSpecificProgramWithParameters.CheckedChanged += new System.EventHandler(this.hasOpenProgram_CheckedChanged);
            // 
            // jLabel1
            // 
            this.jLabel1.AutoSize = true;
            this.jLabel1.Location = new System.Drawing.Point(6, 10);
            this.jLabel1.Name = "jLabel1";
            this.jLabel1.Size = new System.Drawing.Size(349, 19);
            this.jLabel1.Style = JHUI.JColorStyle.Gold;
            this.jLabel1.TabIndex = 33;
            this.jLabel1.Text = "What would program do when it recognize this utterance?";
            this.jLabel1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jProgressSpinner1
            // 
            this.jProgressSpinner1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jProgressSpinner1.Location = new System.Drawing.Point(88, 286);
            this.jProgressSpinner1.Maximum = 100;
            this.jProgressSpinner1.Name = "jProgressSpinner1";
            this.jProgressSpinner1.Size = new System.Drawing.Size(116, 116);
            this.jProgressSpinner1.Style = JHUI.JColorStyle.Red;
            this.jProgressSpinner1.TabIndex = 29;
//            this.jProgressSpinner1.Text = "jProgressSpinner1";
            this.jProgressSpinner1.Theme = JHUI.JThemeStyle.Dark;
            this.jProgressSpinner1.UseSelectable = true;
            // 
            // IntentContextMenu
            // 
            this.IntentContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToToolStripMenuItem,
            this.toolStripSeparator1,
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator2,
            this.regenerateDBToolStripMenuItem});
            this.IntentContextMenu.Name = "contextMenuStrip1";
            this.IntentContextMenu.Size = new System.Drawing.Size(152, 104);
            // 
            // moveToToolStripMenuItem
            // 
            this.moveToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1,
            this.moveToolStripMenuItem});
            this.moveToToolStripMenuItem.Name = "moveToToolStripMenuItem";
            this.moveToToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.moveToToolStripMenuItem.Text = "MoveTo";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.moveToolStripMenuItem.Text = "Move";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(148, 6);
            // 
            // regenerateDBToolStripMenuItem
            // 
            this.regenerateDBToolStripMenuItem.Name = "regenerateDBToolStripMenuItem";
            this.regenerateDBToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.regenerateDBToolStripMenuItem.Text = "Regenerate DB";
            this.regenerateDBToolStripMenuItem.Click += new System.EventHandler(this.regenerateDBToolStripMenuItem_Click);
            // 
            // listBox_items
            // 
            this.listBox_items.AllowUserToAddRows = false;
            this.listBox_items.AllowUserToDeleteRows = false;
            this.listBox_items.AllowUserToResizeColumns = false;
            this.listBox_items.AllowUserToResizeRows = false;
            this.listBox_items.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox_items.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.listBox_items.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_items.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.listBox_items.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.listBox_items.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listBox_items.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.listBox_items.ColumnHeadersHeight = 30;
            this.listBox_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.listBox_items.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnName});
            this.listBox_items.ContextMenuStrip = this.IntentContextMenu;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listBox_items.DefaultCellStyle = dataGridViewCellStyle6;
            this.listBox_items.EnableHeadersVisualStyles = false;
            this.listBox_items.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.listBox_items.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.listBox_items.Location = new System.Drawing.Point(3, 62);
            this.listBox_items.Name = "listBox_items";
            this.listBox_items.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listBox_items.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.listBox_items.RowHeadersVisible = false;
            this.listBox_items.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.listBox_items.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.listBox_items.RowTemplate.Height = 30;
            this.listBox_items.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listBox_items.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listBox_items.Size = new System.Drawing.Size(285, 520);
            this.listBox_items.Style = JHUI.JColorStyle.Blue;
            this.listBox_items.TabIndex = 28;
            this.listBox_items.Theme = JHUI.JThemeStyle.Dark;
            this.listBox_items.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.listBox_items_CellValueChanged);
            this.listBox_items.SelectionChanged += new System.EventHandler(this.listBox_items_SelectionChanged);
            // 
            // ColumnId
            // 
            this.ColumnId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnId.FillWeight = 50F;
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.MinimumWidth = 50;
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            this.ColumnId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnId.Width = 50;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // selectedCategory
            // 
            this.selectedCategory.FormattingEnabled = true;
            this.selectedCategory.ItemHeight = 23;
            this.selectedCategory.Location = new System.Drawing.Point(3, 27);
            this.selectedCategory.Name = "selectedCategory";
            this.selectedCategory.Size = new System.Drawing.Size(285, 29);
            this.selectedCategory.Style = JHUI.JColorStyle.Blue;
            this.selectedCategory.TabIndex = 0;
            this.selectedCategory.Theme = JHUI.JThemeStyle.Dark;
            this.selectedCategory.UseSelectable = true;
            this.selectedCategory.SelectedIndexChanged += new System.EventHandler(this.selectedCategory_SelectedIndexChanged);
            // 
            // jContextMenu1
            // 
            this.jContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveDatabaseToolStripMenuItem,
            this.backupDatabaseToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.loadFromXMLToolStripMenuItem});
            this.jContextMenu1.Name = "jContextMenu1";
            this.jContextMenu1.Size = new System.Drawing.Size(165, 114);
            this.jContextMenu1.Style = JHUI.JColorStyle.Gold;
            this.jContextMenu1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // saveDatabaseToolStripMenuItem
            // 
            this.saveDatabaseToolStripMenuItem.Name = "saveDatabaseToolStripMenuItem";
            this.saveDatabaseToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.saveDatabaseToolStripMenuItem.Text = "Save Database";
            this.saveDatabaseToolStripMenuItem.Click += new System.EventHandler(this.SaveDb_CLICK);
            // 
            // backupDatabaseToolStripMenuItem
            // 
            this.backupDatabaseToolStripMenuItem.Name = "backupDatabaseToolStripMenuItem";
            this.backupDatabaseToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.backupDatabaseToolStripMenuItem.Text = "Backup Database";
            this.backupDatabaseToolStripMenuItem.Click += new System.EventHandler(this.backupDatabaseToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // loadFromXMLToolStripMenuItem
            // 
            this.loadFromXMLToolStripMenuItem.Name = "loadFromXMLToolStripMenuItem";
            this.loadFromXMLToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.loadFromXMLToolStripMenuItem.Text = "Load From XML";
            this.loadFromXMLToolStripMenuItem.Click += new System.EventHandler(this.loadFromXMLToolStripMenuItem_Click);
            // 
            // DatabaseManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(942, 600);
            this.ContextMenuStrip = this.jContextMenu1;
            this.Controls.Add(this.jProgressSpinner1);
            this.Controls.Add(this.listBox_items);
            this.Controls.Add(this.jTabControl1);
            this.Controls.Add(this.selectedCategory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DatabaseManager";
            this.Style = JHUI.JColorStyle.Blue;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DatabaseManager_FormClosing);
            this.Shown += new System.EventHandler(this.DatabaseManager_Shown);
            this.jTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerGrid)).EndInit();
            this.AnswerContextMenu.ResumeLayout(false);
            this.IntentContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBox_items)).EndInit();
            this.jContextMenu1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private JHUI.Controls.JTabControl jTabControl1;
        private JHUI.Controls.JComboBox selectedCategory;
        private JDataGridView listBox_items;
        private JContextMenu jContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem saveDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip IntentContextMenu;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip AnswerContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private JProgressSpinner jProgressSpinner1;
        private System.Windows.Forms.TabPage tabPage2;
        private JLabel jLabel1;
        private System.Windows.Forms.TabPage tabPage1;
        private JLabel jLabel3;
        private JTextBox jTextBox1;
        private JLabel jLabel5;
        private JLabel jLabel4;
        private JLabel jLabel7;
        private JToggle hasConfirmDialog;
        private JLabel jLabel6;
        private JToggle OpenSpecificProgramWithParameters;
        private JDataGridView AnswerGrid;
        private JLabel jLabel9;
        private JToggle hasAnswer;
        private JTextBox cancelTextBox;
        private JTextBox confirmTextBox;
        private JLabel jLabel10;
        private JToggle hasSearchInFiles;
        private JLabel jLabel8;
        private JToggle hasSearchInWeb;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private JLabel jLabel11;
        private JToggle isMathQuestion;
        private JLabel jLabel12;
        private JLabel jLabel13;
        private JToggle LearnDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.ToolStripMenuItem moveToToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem regenerateDBToolStripMenuItem;
        private JLabel jLabel2;
        private JToggle StartPrgramsFromList;
        private System.Windows.Forms.ToolStripMenuItem loadFromXMLToolStripMenuItem;
    }
}