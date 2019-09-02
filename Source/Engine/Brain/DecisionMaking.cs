using JHUI.Utils;
using LIAM;
using LIAM.Utils;
using puremvc.Classes;
using puremvc.Engine.Brain.IDatabase;
using puremvc.Engine.Listen.SubClasses;
using puremvc.Engine.Managers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace puremvc.Engine.Brain
{
    public enum LearnType
    {
        search,
        program
    }
    public sealed class DecisionMaking : JBehavor
    {
        static public readonly DecisionMaking Instance = new DecisionMaking();
        private SortedDictionary<string, IProgram> database
        {
            get
            {
                return ConfigManager.Instance.knownPrograms();
            }
        }
        private SortedDictionary<string, IWebSite> sites {

            get
            {
                return ConfigManager.Instance.knownSearch();
            }
        }
        private IProgram lastProgramFound = new IProgram();
        private float lastActivatedTime = 0;
        private float listenTime = 10f;
        private bool isConfirmActivated = false;
        private Random random = new Random();

        private DecisionMaking() {
            InvokeRepeating(startMainListener, 0.1f);
        }

        private void startMainListener()
        {
            if (isConfirmActivated)
            {
                if (lastActivatedTime < Time.time)
                {
                    MainListener.Instance.StopListening(true);
                    isConfirmActivated = false;
                }
            }
        }

        public async Task<bool> process(Result result)
        {
            return await Task.Run(() =>
            {
                MainListener.Instance.StopListening();
                for (int i = 0; i < result.SubQueries.Count; i++)
                {
                    SubQuery query = result.SubQueries[i];
                    Intent intent = query.IdentId;
                    if (intent.StartPrgramsFromList)
                    {
                        bool found = false;
                        foreach (string star in query.InputStar)
                        {
                            string keyName = star.ToLower().Trim();
                            if (database.ContainsKey(keyName))
                            {
                                lastProgramFound = database[keyName];
                                if (intent.hasConfirmDialog)
                                {
                                    MainListener.Instance.StartConfirm(new string[] { intent.ConfirmWord, intent.ConfirmWord });
                                    if (!intent.hasAnswer)
                                        MouthManager.Instance.Speak("Are you sure you want to open " + keyName + " ?");
                                    lastActivatedTime = Time.time + listenTime;
                                    isConfirmActivated = true;
                                }
                                else
                                {
                                    processConfirmOpenProgram(intent.ConfirmWord);
                                }
                                found = true;
                                break;
                            }
                            else
                            {

                                if(keyName.Equals("settings") || keyName.Equals("setting"))
                                {
                                    TaskPanel.Instance.openSettings();
                                    return false;
                                }
                                if (keyName.Equals("config") || keyName.Equals("configs"))
                                {
                                    TaskPanel.Instance.openConfigs();
                                    return false;
                                }
                                if (keyName.Equals("test processor"))
                                {
                                    TaskPanel.Instance.openTests();
                                    return false;
                                }
                            }
                        }
                        if (!found && intent.LearnDialog)
                            openLearningSystem(LearnType.program);
                    }
                    if (intent.hasSearchInWeb)
                    {
                        bool found = false;
                        if (query.InputStar.Count == 2)
                        {
                            string keyName = query.InputStar[1].ToLower().Trim();
                            string value = query.InputStar[0].ToLower().Trim();
                            if (sites.ContainsKey(keyName))
                            {
                                IProgram dummy = new IProgram();
                                dummy.Name = sites[keyName].Name;
                                dummy.Path = sites[keyName].Url;
                                dummy.Path += sites[keyName].Parameters + value;
                                lastProgramFound = dummy;
                                if (intent.hasConfirmDialog)
                                {
                                    MainListener.Instance.StartConfirm(new string[] { intent.ConfirmWord, intent.ConfirmWord });
                                    if (!intent.hasAnswer)
                                        MouthManager.Instance.Speak("Are you sure you want to open " + keyName + " ?");
                                    lastActivatedTime = Time.time + listenTime;
                                    isConfirmActivated = true;
                                }
                                else
                                {
                                     processConfirmOpenProgram(intent.ConfirmWord);
                                }
                            }
                        }
                        
                        if (!found && intent.LearnDialog)
                            openLearningSystem(LearnType.search);
                    }
                    if (intent.isMathQuestion)
                    {
                        string formula = FixResult(query.FullPath.ToUpper()); //or get it from DB
                        int index = formula.IndexOf("<THAT>");
                        if (index > 0)
                            formula = formula.Substring(0, index);

                        formula = RemoveUnwantedCharacters(formula, "0123456789+-*/.".ToCharArray());

                        StringToFormula stf = new StringToFormula();
                        double resultx = stf.Eval(formula);
                        TaskPanel.Instance.setClipBoardText(resultx.ToString());
                        MouthManager.Instance.Speak(resultx.ToString()+ "! For your convenience result was copy to clipboard.");
                    }
                    if (intent.hasAnswer)
                    {
                        MouthManager.Instance.Speak(result.Output);
                    }
                }
                return true;
            });
        }

        private string RemoveUnwantedCharacters(string input, char[] allowedCharacters)
        {
            var filtered = input.ToCharArray()
                .Where(c => allowedCharacters.Contains(c))
                .ToArray();

            return new String(filtered);
        }

        private string FixResult(string data)
        {
            return data.Replace("DIVIDED", "/").Replace("PLUS", "+").Replace("MINUS", "-").Replace("TIMES", "*");
        }

        private void openLearningSystem(LearnType search)
        {
            //TODO OPEN LEARN NEW PROGRAM DIALOG
        }

        public void processConfirmOpenProgram(string result)
        {
            MainListener.Instance.StopListening(true);
            Debug.WriteLine(result);

            if (lastProgramFound != null && result.ToLower().Equals("yes"))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = lastProgramFound.Path;
                if(lastProgramFound.Parameters != null && lastProgramFound.Parameters.Length > 0)
                    startInfo.Arguments = lastProgramFound.Parameters;

                Process.Start(startInfo);

                var names = new List<string> { "No problem. Here is " + lastProgramFound.Name + "", "Sure!", "Okay!", "Opening " + lastProgramFound.Name + "" };
                int index = random.Next(names.Count);
                var name = names[index];
                MouthManager.Instance.Speak(name);
            }
            else
            {

            }
            lastProgramFound = null;
        }
    }
}
