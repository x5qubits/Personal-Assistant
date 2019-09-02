using puremvc.Engine;
using puremvc.Engine.Brain;
using puremvc.Engine.Managers;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace puremvc
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");

            Application.EnableVisualStyles();

            //Application.Run(TaskPanel.Instance);
           
            Application.Run(new VoiceSpeaker());

        }
    }
}
