using JHUI.Forms;
using LIAM;
using LIAM.Utils;
using puremvc.Engine;
using puremvc.Engine.Brain;
using System;

namespace puremvc
{
    public partial class TestProcesor : JForm
    {
        public TestProcesor()
        {
            InitializeComponent();
        }

        private void jButton1_Click(object sender, EventArgs e)
        {
            jTextBox2.Text = "";
            Result result = TheProcessor.Instance.TestProcess(jTextBox1.Text);
           // MouthManager.Instance.Speak(jTextBox1.Text);
            //return;
            DecisionMaking.Instance.process(result);
            string build = "";
            foreach(SubQuery query in result.SubQueries)
            {
                build += query.InputStar;
            }
            build += result.Output;
            jTextBox2.Text = build;
            
        }
    }
}
