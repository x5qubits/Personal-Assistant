using JHUI.Forms;
using puremvc.Engine.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puremvc.Engine.Brain.IDatabase;
using System.Threading;

namespace puremvc
{
    public partial class Settings : JForm
    {

        private SortedDictionary<int, IProgram> database = new SortedDictionary<int, IProgram>();
        private SortedDictionary<int, IWebSite> sites = new SortedDictionary<int, IWebSite>();
        private bool block = false;

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Shown(object sender, EventArgs e)
        {
            Thread th = new Thread(delegate ()
            {
                DOWORK();
            });
            th.IsBackground = true;
            th.Start();
            
        }

        private void DOWORK()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate
                { DOWORK(); });
                return;
            }
            jProgressSpinner1.Visible = true;
            block = true;
            SortedDictionary<string, IProgram> DB = ConfigManager.Instance.knownPrograms();
            SortedDictionary<string, IWebSite> DB2 = ConfigManager.Instance.knownSearch();
            listBox_items.Rows.Clear();
            jDataGrid1.Rows.Clear();
            int id = 0;
            foreach(KeyValuePair<string, IProgram> ge in DB)
            {
                IProgram program = ge.Value;
                database[id] = program;
                listBox_items.Rows.Add(new object[] { id, program.Name, program.Path, program.Parameters });
                id++;
            }
            id = 0;
            foreach (KeyValuePair<string, IWebSite> ge in DB2)
            {
                IWebSite program = ge.Value;
                sites[id] = program;
                jDataGrid1.Rows.Add(new object[] { id, program.Name, program.Url, program.Parameters });
                id++;
            }
            block = false;
            jProgressSpinner1.Visible = false;
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            SortedDictionary<string, IProgram> DB = new SortedDictionary<string, IProgram>();
            foreach (KeyValuePair<int, IProgram> ge in database)
            {
                IProgram program = ge.Value;
                if (!program.Name.Equals("PLEASE_SET"))
                    DB[program.Name.ToLower().Trim()] = program;
            }
            SortedDictionary<string, IWebSite> DB2 = new SortedDictionary<string, IWebSite>();
            foreach (KeyValuePair<int, IWebSite> ge in sites)
            {
                IWebSite program = ge.Value;
                if (!program.Name.Equals("PLEASE_SET"))
                    DB2[program.Name.ToLower().Trim()] = program;
            }
            ConfigManager.Instance.setKnownWebsites(DB2);
            ConfigManager.Instance.setKnownPrograms(DB);
            ConfigManager.Instance.SaveDb();
        }

        private void listBox_items_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (block) return;
            if (listBox_items.CurrentCell != null && database != null)
            {
                block = true;
                int element = int.Parse(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value.ToString());
                if (database.ContainsKey(element))
                {
                    switch(e.ColumnIndex)
                    {
                        case 1:
                            try
                            {
                                database[element].Name = listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[1].Value.ToString();
                            }
                            catch { }
                            break;

                        case 2:
                            try
                            {
                                database[element].Path = listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[2].Value.ToString();
                            }
                            catch { }
                            break;
                        case 3:
                            try
                            {
                                database[element].Parameters = listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[3].Value.ToString();
                            }
                            catch { database[element].Parameters = ""; }
                            break;
                    }
                }
            }
            block = false;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (block) return;
            if (database != null)
            {
                IProgram program = new IProgram();
                program.Name = "PLEASE_SET";
                int nextK = 0;
                try
                {
                    nextK = database.Keys.Last() + 1;
                }
                catch { }
                database.Add(nextK, program);
                listBox_items.Rows.Add(new object[] { nextK, program.Name, program.Path, program.Parameters });
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (block) return;
            if (listBox_items.CurrentCell != null && database != null)
            {
                int xe = listBox_items.CurrentCell.RowIndex;
                int element = int.Parse(listBox_items.Rows[xe].Cells[0].Value.ToString());
                if(database.ContainsKey(element))
                {
                    database.Remove(element);
                    listBox_items.Rows.RemoveAt(xe);
                }
            }
        }

        private void listBox_items_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (block) return;
            if (listBox_items.CurrentCell != null && database != null)
            {
                int element = int.Parse(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value.ToString());
                if (database.ContainsKey(element) && e.ColumnIndex == 2)
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    openFileDialog1.Filter = "Program To Open (*.exe) | *.exe";
                    openFileDialog1.RestoreDirectory = true;
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[2].Value = openFileDialog1.FileName;
                    }
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (block) return;
            if (sites != null)
            {
                IWebSite program = new IWebSite();
                program.Name = "PLEASE_SET";
                int nextK = 0;
                try
                {
                    nextK = sites.Keys.Last() + 1;
                }
                catch { }

                sites.Add(nextK, program);
                jDataGrid1.Rows.Add(new object[] { nextK, program.Name, program.Url, program.Parameters });
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (block) return;
            if (jDataGrid1.CurrentCell != null && sites != null)
            {
                int xe = jDataGrid1.CurrentCell.RowIndex;
                int element = int.Parse(jDataGrid1.Rows[xe].Cells[0].Value.ToString());
                if (sites.ContainsKey(element))
                {
                    sites.Remove(element);
                    jDataGrid1.Rows.RemoveAt(xe);
                }
            }
        }

        private void jDataGrid1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (block) return;
            if (jDataGrid1.CurrentCell != null && sites != null)
            {
                block = true;
                int element = int.Parse(jDataGrid1.Rows[jDataGrid1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                if (sites.ContainsKey(element))
                {
                    switch (e.ColumnIndex)
                    {
                        case 1:
                            try
                            {
                                sites[element].Name = jDataGrid1.Rows[jDataGrid1.CurrentCell.RowIndex].Cells[1].Value.ToString();
                            }
                            catch { }
                            break;

                        case 2:
                            try
                            {
                                sites[element].Url = jDataGrid1.Rows[jDataGrid1.CurrentCell.RowIndex].Cells[2].Value.ToString();
                            }
                            catch { }
                            break;
                        case 3:
                            try
                            {
                                sites[element].Parameters = jDataGrid1.Rows[jDataGrid1.CurrentCell.RowIndex].Cells[3].Value.ToString();
                            }
                            catch { database[element].Parameters = ""; }
                            break;
                    }
                }
            }
            block = false;
        }
    }
}
