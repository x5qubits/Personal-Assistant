using JHUI.Forms;
using puremvc.Engine.Brain.IDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace puremvc
{
    public partial class FileParameterDialog : JForm
    {
        private Intent data = null;
        public FileParameterDialog(string question, string tip, Intent data)
        {
            this.data = data;
            InitializeComponent();
            this.Text = question;
            this.jTextBox1.TextWaterMark = tip;
        }

        private void Dialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            data.programParameter = this.jTextBox1.Text;
        }
    }
}
