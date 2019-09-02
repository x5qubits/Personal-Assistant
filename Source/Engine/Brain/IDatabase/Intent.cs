using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace puremvc.Engine.Brain.IDatabase
{
    /// <summary>
    /// An intent represents actions the user wants to perform. The intent is a purpose or goal expressed in a user's input, such as booking a flight, paying a bill, or finding a news article. You define and name intents that correspond to these actions. A travel app may define an intent named "BookFlight." 
    /// </summary>
    [Serializable]
    public class Intent
    {
        /// <summary>
        /// category
        /// </summary>
        public int Id = -1;
        public string Name { get; set; }
        public bool StartPrgramsFromList = false;

        public bool LearnDialog = false;

        public string PathToFile;
        public IntentType type;
        public Entity entity;
        public bool hasAnswer = true;
        public bool hasConfirmDialog = false;
        public bool OpenSpecificProgramWithParameters = false;
        public bool hasSearchInWeb = false;
        public bool hasSearchInFiles = false;
        public bool isMathQuestion = false;
        public string ConfirmWord = "yes";
        public string CancelWord = "no";
        public string ProgramPath = "";
        public string programParameter = "";
    }
}
