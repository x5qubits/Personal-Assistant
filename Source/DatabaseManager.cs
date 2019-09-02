using JHUI.Animation;
using JHUI.Forms;
using puremvc.Engine.Brain;
using puremvc.Engine.Brain.IDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace puremvc
{
    public partial class DatabaseManager : JForm
    {
        private IRoot database = null;
        private bool block = false;

        public DatabaseManager()
        {
            InitializeComponent();
        }

        private void DatabaseManager_Shown(object sender, EventArgs e)
        {
            Thread th = new Thread(delegate ()
            {
                PopulateCategoryes();
            });
            th.IsBackground = true;
            th.Start();
        }

        private void PopulateCategoryes()
        {
            
            if(this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate
                { PopulateCategoryes(); });
                return;
            }
            jProgressSpinner1.Visible = true;
            database = TheProcessor.Instance.getDb();
            block = true;
            selectedCategory.Items.Clear();
            var unique_items = new HashSet<string>(database.idents.Values.ToList().Select(x => x.Name).ToList());
            foreach (string str in unique_items)
            {
                selectedCategory.Items.Add(str);
                toolStripComboBox1.Items.Add(str);
            }
            block = false;
            try
            {
                selectedCategory.SelectedIndex = 0;
                toolStripComboBox1.SelectedIndex = 0;

                jProgressSpinner1.Visible = false;
            }
            catch { }

        }

        private void SaveDb_CLICK(object sender, EventArgs e)
        {
            TheProcessor.Instance.SaveDatabase();
        }

        private void selectedCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (block) return;
            if (selectedCategory.SelectedIndex != -1)
            {
                listBox_items.Rows.Clear();
                string intent = selectedCategory.Items[selectedCategory.SelectedIndex].ToString();
                List<Intent> selected_intents = database.idents.Values.ToList().Where(x => x.Name == intent).ToList();
                for(int i = 0; i < selected_intents.Count; i++)
                {
                    Intent Intent = selected_intents[i];
                    listBox_items.Rows.Add(new object[] { Intent.Id, Intent.entity.patern });
                }
            }

        }

        private void listBox_items_SelectionChanged(object sender, EventArgs e)
        {
            if (block) return;
            if (listBox_items.CurrentCell != null && database != null)
            {
                block = true;
                int element = int.Parse(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value.ToString());
                Intent intent = database.getIdent(element);
                if(intent != null)
                {        
                    AnswerGrid.Rows.Clear();
                    if (intent.entity != null)
                    {
                        jLabel12.Visible = false;
                        jTextBox1.Text = TheProcessor.Instance.Normalize(intent.entity.patern, false).ToUpper();
                        hasAnswer.Checked = intent.hasAnswer;
                        hasConfirmDialog.Checked = intent.hasConfirmDialog;
                        OpenSpecificProgramWithParameters.Checked = intent.OpenSpecificProgramWithParameters;
                        StartPrgramsFromList.Checked = intent.StartPrgramsFromList;
                        hasSearchInWeb.Checked = intent.hasSearchInWeb;
                        hasSearchInFiles.Checked = intent.hasSearchInFiles;
                        isMathQuestion.Checked = intent.isMathQuestion;
                        confirmTextBox.Text = intent.ConfirmWord;
                        cancelTextBox.Text = intent.CancelWord;
                        LearnDialog.Checked = intent.LearnDialog;
                        if (intent.ProgramPath.Length > 0)
                        {
                            jLabel12.Visible = true;
                            jLabel12.Text = Path.GetFileNameWithoutExtension(intent.ProgramPath);


                        }


                        if (intent.hasConfirmDialog)
                        {
                            confirmTextBox.Visible = true;
                            cancelTextBox.Visible = true;
                        }
                        else
                        {
                            confirmTextBox.Visible = false;
                            cancelTextBox.Visible = false;
                        }

                        List<string> answers = intent.entity.GetAnswers();
                        AnswerGrid.Visible = hasAnswer.Checked;
                        if (answers.Count > 0 && hasAnswer.Checked)
                        {
                            for (int i = 0; i < answers.Count; i++)
                            {
                                string Intent = answers[i];
                                AnswerGrid.Rows.Add(new object[] { Intent });
                            }
                        }
                    }
                }
                block = false;
            }
        }

        private void jTextBox1_Leave(object sender, EventArgs e)
        {
            if (block) return;
            if (listBox_items.CurrentCell != null && database != null)
            {
                int element = int.Parse(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value.ToString());
                Intent intent = database.getIdent(element);
                if (intent != null)
                {
                    string test = TheProcessor.Instance.Normalize(jTextBox1.Text, false).ToUpper();
                    intent.entity.patern = test;
                    listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[1].Value = test;
                }
            }
        }

        private void listBox_items_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (block) return;
            if (listBox_items.CurrentCell != null && database != null)
            {
                int element = int.Parse(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value.ToString());
                Intent intent = database.getIdent(element);
                if (intent != null)
                {
                    string test = TheProcessor.Instance.Normalize(Convert.ToString(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[1].Value), false).ToUpper();                   
                    jTextBox1.Text = test;
                    intent.entity.patern = test;
                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (block) return;
            if (listBox_items.CurrentCell != null && database != null)
            {
                Intent intent = new Intent();
                intent.type = IntentType.Ident;
                intent.entity = new Entity();
                intent.entity.patern = "PLEASE EDIT";
                intent.entity.answer = "<utterance></utterance>";
                string intentx = selectedCategory.Items[selectedCategory.SelectedIndex].ToString();
                intent.Name = intentx;
                database.Add(intent);
                this.selectedCategory_SelectedIndexChanged(null, null);
                try
                {
                    listBox_items.Rows[listBox_items.Rows.Count - 1].Selected = true;
                    listBox_items.CurrentCell = listBox_items.Rows[listBox_items.Rows.Count - 1].Cells[0];
                }
                catch { }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (block) return;
            if (listBox_items.CurrentCell != null && database != null)
            {
                int xe = listBox_items.CurrentCell.RowIndex;
                int element = int.Parse(listBox_items.Rows[xe].Cells[0].Value.ToString());
                database.removeElement(element);
                this.selectedCategory_SelectedIndexChanged(null, null);
                try
                {
                    listBox_items.Rows[xe].Selected = true;
                    listBox_items.CurrentCell = listBox_items.Rows[xe].Cells[0];
                }
                catch {
                    try
                    {
                        listBox_items.Rows[listBox_items.Rows.Count - 1].Selected = true;
                        listBox_items.CurrentCell = listBox_items.Rows[listBox_items.Rows.Count - 1].Cells[0];
                    }
                    catch { }
                }
            }
        }

        private void AddAnswer(object sender, EventArgs e)
        {
            if (block) return;
            if (listBox_items.CurrentCell != null && database != null)
            {
                int element = int.Parse(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value.ToString());
                Intent intent = database.getIdent(element);
                if (intent != null)
                {
                    if(intent.hasAnswer)
                    {
                        AnswerGrid.Rows.Add("New Answer");
                    }
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (block) return;
            if (listBox_items.CurrentCell != null && database != null && AnswerGrid.CurrentCell != null)
            {
                int element = int.Parse(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value.ToString());
                Intent intent = database.getIdent(element);
                if (intent != null)
                {
                    if (intent.hasAnswer)
                    {
                        int row = AnswerGrid.CurrentCell.RowIndex;
                        AnswerGrid.Rows.RemoveAt(row);
                        RemakeProcedure();
                    }
                }
            }
        }

        private void RemakeProcedure()
        {
            if (block) return;
            if (listBox_items.CurrentCell != null && database != null)
            {
                int element = int.Parse(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value.ToString());
                Intent intent = database.getIdent(element);
                if (intent != null)
                {
                    string answer = "<utterance>";
                    int answersCount = AnswerGrid.Rows.Count;
                    if (answersCount > 0)
                    {
                        answer += "<random>";
                        for (int i = 0; i < AnswerGrid.Rows.Count; i++)
                        {
                            answer += "<li>" + AnswerGrid.Rows[i].Cells[0].Value.ToString() + "</li>";
                        }
                        answer += "</random>";
                    }
                    else
                    {
                        intent.hasAnswer = false;
                        hasAnswer.Checked = intent.hasAnswer;
                    }
                    string[] data = TheProcessor.Instance.SplitNormalize(intent.entity.patern);
                    int starsCount = 0;
                    for(int i = 0; i< data.Length; i++)
                    {
                        if(data[i].Equals("*"))
                        {
                            starsCount++;
                        }
                    }
                    if(starsCount > 0)
                    {
                        answer += "<think>";

                        for(int i = 0; i < starsCount; i++)
                            answer += "<set name=\"x"+ i +"\"><star/></set>";

                        answer += "</think>";
                    }

                    answer += "</utterance>";
                    intent.entity.answer = answer;
                }
            }
        }

        private void AnswerGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            RemakeProcedure();
        }

        private void hasAnswer_CheckedChanged(object sender, EventArgs e)
        {
            if (block) return;
            if (listBox_items.CurrentCell != null && database != null)
            {
                int element = int.Parse(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value.ToString());
                Intent intent = database.getIdent(element);
                if (intent != null)
                {
                    intent.hasAnswer = hasAnswer.Checked;
                    if (intent.hasAnswer)
                    {
                        AnswerGrid.Visible = true;
                    }else
                    {
                        AnswerGrid.Visible = false;
                    }
                }
            }
        }

        private void IsMathQuestion_CheckedChanged(object sender, EventArgs e)
        {
            if (block) return;
            if (listBox_items.CurrentCell != null && database != null)
            {
                int element = int.Parse(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value.ToString());
                Intent intent = database.getIdent(element);
                if (intent != null)
                {
                    intent.isMathQuestion = isMathQuestion.Checked;
                }
            }
        }

        private void hasSearchInFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (block) return;
            if (listBox_items.CurrentCell != null && database != null)
            {
                int element = int.Parse(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value.ToString());
                Intent intent = database.getIdent(element);
                if (intent != null)
                {
                    intent.hasSearchInFiles = hasSearchInFiles.Checked;
                }
            }
        }

        private void hasSearchInWeb_CheckedChanged(object sender, EventArgs e)
        {
            if (block) return;
            if (listBox_items.CurrentCell != null && database != null)
            {
                int element = int.Parse(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value.ToString());
                Intent intent = database.getIdent(element);
                if (intent != null)
                {
                    intent.hasSearchInWeb = hasSearchInWeb.Checked;
                }
            }
        }

        private void hasOpenProgram_CheckedChanged(object sender, EventArgs e)
        {
            if (block) return;
            if (listBox_items.CurrentCell != null && database != null)
            {
                int element = int.Parse(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value.ToString());
                Intent intent = database.getIdent(element);
                if (intent != null)
                {
                    intent.OpenSpecificProgramWithParameters = OpenSpecificProgramWithParameters.Checked;
                    if (intent.OpenSpecificProgramWithParameters)
                    {
                        OpenFileDialog openFileDialog1 = new OpenFileDialog();
                        openFileDialog1.Filter = "Program To Open (*.exe) | *.exe";
                        //openFileDialog1.FilterIndex = 1;
                        //openFileDialog1.Multiselect = true;
                        openFileDialog1.RestoreDirectory = true;
                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            intent.ProgramPath = openFileDialog1.FileName;
                            jLabel12.Visible = true;
                            FileParameterDialog testDialog = new FileParameterDialog("Enter Parameters", "Parmeters", intent);
                            testDialog.ShowDialog(this);
                            jLabel12.Text = Path.GetFileNameWithoutExtension(intent.ProgramPath); 
                        }
                        else
                        {
                            jLabel12.Visible = false;
                            intent.OpenSpecificProgramWithParameters = OpenSpecificProgramWithParameters.Checked = false;
                        }
                    }
                }
            }
        }

        private void hasConfirmDialog_CheckedChanged(object sender, EventArgs e)
        {
            if (block) return;
            if (listBox_items.CurrentCell != null && database != null)
            {
                int element = int.Parse(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value.ToString());
                Intent intent = database.getIdent(element);
                if (intent != null)
                {
                    intent.hasConfirmDialog = hasConfirmDialog.Checked;
                    if(intent.hasConfirmDialog)
                    {
                        confirmTextBox.Visible = true;
                        cancelTextBox.Visible = true;
                    }
                    else
                    {
                        confirmTextBox.Visible = false;
                        cancelTextBox.Visible = false;
                    }
                }
            }
        }

        private void confirmTextBox_Leave(object sender, EventArgs e)
        {
            if (block) return;
            if (listBox_items.CurrentCell != null && database != null)
            {
                int element = int.Parse(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value.ToString());
                Intent intent = database.getIdent(element);
                if (intent != null)
                {
                    intent.ConfirmWord = confirmTextBox.Text;
                }
            }
        }

        private void cancelTextBox_Leave(object sender, EventArgs e)
        {     
            if (block) return;
            if (listBox_items.CurrentCell != null && database != null)
            {
                int element = int.Parse(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value.ToString());
                Intent intent = database.getIdent(element);
                if (intent != null)
                {
                    intent.CancelWord = cancelTextBox.Text;
                }
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemakeProcedure();
            TheProcessor.Instance.SaveDatabase(true);
        }

        private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TheProcessor.Instance.backupDB();
        }



        private void LearnDialog_CheckedChanged(object sender, EventArgs e)
        {
            
            if (block) return;
            if (listBox_items.CurrentCell != null && database != null)
            {
                int element = int.Parse(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value.ToString());
                Intent intent = database.getIdent(element);
                if (intent != null)
                {
                    intent.LearnDialog = LearnDialog.Checked;
                }
            }
        }

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (block) return;
            if (listBox_items.CurrentCell != null && database != null && toolStripComboBox1.SelectedIndex != -1)
            {
                int element = int.Parse(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value.ToString());
                Intent intent = database.getIdent(element);
                if (intent != null)
                {
                    int xe = listBox_items.CurrentCell.RowIndex;
                    intent.Name = toolStripComboBox1.Items[toolStripComboBox1.SelectedIndex].ToString().ToLower();
                    selectedCategory_SelectedIndexChanged(null, null);
                    try
                    {
                        listBox_items.Rows[xe].Selected = true;
                        listBox_items.CurrentCell = listBox_items.Rows[xe].Cells[0];
                    }
                    catch
                    {
                        try
                        {
                            listBox_items.Rows[listBox_items.Rows.Count - 1].Selected = true;
                            listBox_items.CurrentCell = listBox_items.Rows[listBox_items.Rows.Count - 1].Cells[0];
                        }
                        catch { }
                    }
                }
            }
        }

        private void regenerateDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(database != null)
            {
                database.idents = database.resortDic();
                TheProcessor.Instance.SaveDatabase(true);
                selectedCategory_SelectedIndexChanged(null, null);
            }
        }

        private void DatabaseManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            TheProcessor.Instance.SaveDatabase(true);
        }

        private void jToggle1_CheckedChanged(object sender, EventArgs e)
        {
            if (block) return;
            if (listBox_items.CurrentCell != null && database != null)
            {
                int element = int.Parse(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value.ToString());
                Intent intent = database.getIdent(element);
                if (intent != null)
                {
                    intent.StartPrgramsFromList = StartPrgramsFromList.Checked;
                }
            }
        }

        private void loadFromXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented!");
        }
    }
}
