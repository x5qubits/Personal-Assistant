using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Net.Mail;

using LIAM.Utils;
using MsgPack.Serialization;
using puremvc.Engine.Brain.IDatabase;
using System.Threading.Tasks;

namespace LIAM
{
    /// <summary>
    /// Encapsulates a bot. If no settings.xml file is found or referenced the bot will try to
    /// default to safe settings.
    /// </summary>
    public class Bot
    {
        #region Attributes

        /// <summary>
        /// A dictionary object that looks after all the settings associated with this bot
        /// </summary>
        public SettingsDictionary GlobalSettings;

        public IRoot root;

        /// <summary>
        /// A dictionary of all the gender based substitutions used by this bot
        /// </summary>
        public SettingsDictionary GenderSubstitutions;

        /// <summary>
        /// A dictionary of all the first person to second person (and back) substitutions
        /// </summary>
        public SettingsDictionary Person2Substitutions;

        /// <summary>
        /// A dictionary of first / third person substitutions
        /// </summary>
        public SettingsDictionary PersonSubstitutions;

        /// <summary>
        /// Generic substitutions that take place during the normalization process
        /// </summary>
        public SettingsDictionary Substitutions;

        /// <summary>
        /// The default predicates to set up for a user
        /// </summary>
        public SettingsDictionary DefaultPredicates;

        /// <summary>
        /// Holds information about the available custom tag handling classes (if loaded)
        /// Key = class name
        /// Value = TagHandler class that provides information about the class
        /// </summary>
        private Dictionary<string, TagHandler> CustomTags;

        /// <summary>
        /// Holds references to the assemblies that hold the custom tag handling code.
        /// </summary>
        private Dictionary<string, Assembly> LateBindingAssemblies = new Dictionary<string, Assembly>();

        /// <summary>
        /// An List<> containing the tokens used to split the input into sentences during the 
        /// normalization process
        /// </summary>
        public List<string> Splitters = new List<string>()
        {
            ".","!","?",";"
        };

        /// <summary>
        /// A buffer to hold log messages to be written out to the log file when a max size is reached
        /// </summary>
        private List<string> LogBuffer = new List<string>();

        /// <summary>
        /// How big to let the log buffer get before writing to disk
        /// </summary>
        private int MaxLogBufferSize
        {
            get
            {
                return 64;
            }
        }

        /// <summary>
        /// Flag to show if the bot is willing to accept user input
        /// </summary>
        public bool isAcceptingUserInput = true;

        /// <summary>
        /// The message to show if a user tries to use the bot whilst it is set to not process user input
        /// </summary>
        private string NotAcceptingUserInputMessage
        {
            get
            {
                return "Please Wait";
            }
        }

        /// <summary>
        /// The maximum amount of time a request should take (in milliseconds)
        /// </summary>
        public double TimeOut
        {
            get
            {
                return Convert.ToDouble(this.GlobalSettings.grabSetting("timeout"));
            }
        }

        /// <summary>
        /// The message to display in the event of a timeout
        /// </summary>
        public string TimeOutMessage
        {
            get
            {
                return this.GlobalSettings.grabSetting("timeoutmessage");
            }
        }

        /// <summary>
        /// The locale of the bot as a CultureInfo object
        /// </summary>
        public CultureInfo Locale
        {
            get
            {
                return new CultureInfo(this.GlobalSettings.grabSetting("culture"));
            }
        }

        /// <summary>
        /// Will match all the illegal characters that might be inputted by the user
        /// </summary>
        public Regex Strippers
        {
            get
            {
                return new Regex(this.GlobalSettings.grabSetting("stripperregex"),RegexOptions.IgnorePatternWhitespace);
            }
        }

        /// <summary>
        /// Flag to denote if the bot is writing messages to its logs
        /// </summary>
        public bool IsLogging
        {
            get
            {
                string islogging = this.GlobalSettings.grabSetting("showlogs");
                if (islogging.ToLower() == "true")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// When the Bot was initialised
        /// </summary>
        public DateTime StartedOn = DateTime.Now;

        /// <summary>
        /// The supposed sex of the bot
        /// </summary>
        public Gender Sex
        {
            get
            {
                int sex = (int)Gender.Female;
                Gender result;
                switch (sex)
                {
                    case -1:
                        result=Gender.Unknown;
                        break;
                    case 0:
                        result = Gender.Female;
                        break;
                    case 1:
                        result = Gender.Male;
                        break;
                    default:
                        result = Gender.Unknown;
                        break;
                }
                return result;
            }
        }

        public void BackupDb()
        {
            AIMLLoader loader = new AIMLLoader(this);
            loader.Backup();
        }

        /// <summary>
        /// The directory to look in for the AIML files
        /// </summary>
        public string PathToXML
        {
            get
            {
                return Path.Combine(Environment.CurrentDirectory, "data" + Path.DirectorySeparatorChar + "brain");
            }
        }

        /// <summary>
        /// The directory to look in for the AIML files
        /// </summary>
        public string PathToBin
        {
            get
            {
                return Path.Combine(Environment.CurrentDirectory, "data" + Path.DirectorySeparatorChar + "brain"+Path.DirectorySeparatorChar+"database.bin");
            }
        }

        /// <summary>
        /// The directory to look in for the various XML configuration files
        /// </summary>
        public string PathToConfigFiles
        {
            get
            {
                return Path.Combine(Environment.CurrentDirectory, "data");
            }
        }

        /// <summary>
        /// The directory into which the various log files will be written
        /// </summary>
        public string PathToLogs
        {
            get
            {
                return Path.Combine(Environment.CurrentDirectory, "logs");
            }
        }

        /// <summary>
        /// The number of categories this bot has in its graphmaster "brain"
        /// </summary>
        public int Size;

        /// <summary>
        /// The "brain" of the bot
        /// </summary>
        public LIAM.Utils.Node Graphmaster;

        /// <summary>
        /// If set to false the input from AIML files will undergo the same normalization process that
        /// user input goes through. If true the bot will assume the AIML is correct. Defaults to true.
        /// </summary>
        public bool Trust=true;

        /// <summary>
        /// The maximum number of characters a "that" element of a path is allowed to be. Anything above
        /// this length will cause "that" to be "*". This is to avoid having the graphmaster process
        /// huge "that" elements in the path that might have been caused by the bot reporting third party
        /// data.
        /// </summary>
        public int MaxThatSize = 256;

        #endregion

        #region Delegates

        public delegate void LogMessageDelegate();

        #endregion

        #region Events

        public event LogMessageDelegate WrittenToLog;

        #endregion

        /// <summary>
        /// Ctor
        /// </summary>
        public Bot()
        {
            this.setup();  
        }

        #region Settings methods

        /// <summary>
        /// Loads AIML from .aiml files into the graphmaster "brain" of the bot
        /// </summary>
        public void loadAIMLFromFiles()
        {
            AIMLLoader loader = new AIMLLoader(this);
            loader.loadAIML();
        }
        public void SaveDb()
        {
            AIMLLoader loader = new AIMLLoader(this);
            loader.SaveDB();
        }
        /// <summary>
        /// Allows the bot to load a new XML version of some AIML
        /// </summary>
        /// <param name="newAIML">The XML document containing the AIML</param>
        /// <param name="filename">The originator of the XML document</param>
        public void loadAIMLFromXML(XmlDocument newAIML, string filename)
        {
            AIMLLoader loader = new AIMLLoader(this);
            loader.loadAIMLFromXML(newAIML, filename);
        }

        /// <summary>
        /// Instantiates the dictionary objects and collections associated with this class
        /// </summary>
        private void setup()
        {
            this.GlobalSettings = new SettingsDictionary(this);
            this.GenderSubstitutions = new SettingsDictionary(this);
            this.Person2Substitutions = new SettingsDictionary(this);
            this.PersonSubstitutions = new SettingsDictionary(this);
            this.Substitutions = new SettingsDictionary(this);
            this.DefaultPredicates = new SettingsDictionary(this);
            this.CustomTags = new Dictionary<string, TagHandler>();
            this.Graphmaster = new LIAM.Utils.Node(); 
        }

        /// <summary>
        /// Loads settings based upon the default location of the Settings.xml file
        /// </summary>
        public void loadSettings()
        {
            // try a safe default setting for the settings xml file
            string path = Path.Combine(Environment.CurrentDirectory, Path.Combine("data", "Settings.xml"));
            this.loadSettings(path);          
        }

        /// <summary>
        /// Loads settings and configuration info from various xml files referenced in the settings file passed in the args. 
        /// Also generates some default values if such values have not been set by the settings file.
        /// </summary>
        /// <param name="pathToSettings">Path to the settings xml file</param>
        public void loadSettings(string pathToSettings)
        {
            if(File.Exists(pathToSettings))
                this.GlobalSettings.loadSettings(File.ReadAllText(pathToSettings));

            // Load the dictionaries for this Bot from the various configuration files
            this.Person2Substitutions.loadSettings(puremvc.Properties.Resources.Person2Substitutions);
            this.PersonSubstitutions.loadSettings(puremvc.Properties.Resources.PersonSubstitutions);
            this.GenderSubstitutions.loadSettings(puremvc.Properties.Resources.GenderSubstitutions);
            this.DefaultPredicates.loadSettings(puremvc.Properties.Resources.DefaultPredicates);
            this.Substitutions.loadSettings(puremvc.Properties.Resources.Substitutions);
        }
        #endregion

        #region Logging methods

        /// <summary>
        /// The last message to be entered into the log (for testing purposes)
        /// </summary>
        public string LastLogMessage=string.Empty;

        /// <summary>
        /// Writes a (timestamped) message to the bot's log.
        /// 
        /// Log files have the form of yyyyMMdd.log.
        /// </summary>
        /// <param name="message">The message to log</param>
        public void writeToLog(string message)
        {
            this.LastLogMessage = message;
            if (this.IsLogging)
            {
                this.LogBuffer.Add(DateTime.Now.ToString() + ": " + message + Environment.NewLine);
                if (this.LogBuffer.Count > this.MaxLogBufferSize-1)
                {
                    // Write out to log file
                    DirectoryInfo logDirectory = new DirectoryInfo(this.PathToLogs);
                    if (!logDirectory.Exists)
                    {
                        logDirectory.Create();
                    }

                    string logFileName = DateTime.Now.ToString("yyyyMMdd")+".log";
                    FileInfo logFile = new FileInfo(Path.Combine(this.PathToLogs,logFileName));
                    StreamWriter writer;
                    if (!logFile.Exists)
                    {
                        writer = logFile.CreateText();
                    }
                    else
                    {
                        writer = logFile.AppendText();
                    }

                    foreach (string msg in this.LogBuffer)
                    {
                        writer.WriteLine(msg);
                    }
                    writer.Close();
                    this.LogBuffer.Clear();
                }
            }
            if (!object.Equals(null, this.WrittenToLog))
            {
                this.WrittenToLog();
            }
        }

        #endregion

        #region Conversation methods
        public Result Querys(Request request)
        {
            Result result = new Result(request.user, this, request);

            if (this.isAcceptingUserInput)
            {
                // Normalize the input
                AIMLLoader loader = new AIMLLoader(this);
                LIAM.Normalize.SplitIntoSentences splitter = new LIAM.Normalize.SplitIntoSentences(this);
                string[] rawSentences = splitter.Transform(request.rawInput);
                foreach (string sentence in rawSentences)
                {
                    result.InputSentences.Add(sentence);
                    string path = loader.generatePath(sentence, request.user.getLastBotOutput(), request.user.Topic, true);
                    result.NormalizedPaths.Add(path);
                }

                // grab the templates for the various sentences from the graphmaster
                foreach (string path in result.NormalizedPaths)
                {
                    Utils.SubQuery query = new SubQuery(path);
                    query.Template = this.Graphmaster.evaluate(path, query, request, MatchState.UserInput, new StringBuilder());
                    result.SubQueries.Add(query);
                }

                // process the templates into appropriate output
                foreach (SubQuery query in result.SubQueries)
                {
                    if (query.Template.Length > 0)
                    {
                        try
                        {
                            XmlNode templateNode = AIMLTagHandler.getNode(query.Template);
                            string outputSentence = this.processNode(templateNode, query, request, result, request.user);
                            if (outputSentence.Length > 0)
                            {
                                result.OutputSentences.Add(outputSentence);
                            }
                        }
                        catch
                        {
                            this.writeToLog("WARNING! A problem was encountered when trying to process the input: " + request.rawInput + " with the template: \"" + query.Template + "\"");
                        }
                    }
                }
            }
            else
            {
                result.OutputSentences.Add(this.NotAcceptingUserInputMessage);
            }

            // populate the Result object
            result.Duration = DateTime.Now - request.StartedOn;
            request.user.addResult(result);

            return result;
        }
        /// <summary>
        /// Given a request containing user input, produces a result from the bot
        /// </summary>
        /// <param name="request">the request from the user</param>
        /// <returns>the result to be output to the user</returns>
        public async Task<Result> Query(Request request)
        {
            return await Task.Run(() =>
            {
                Result result = new Result(request.user, this, request);

                if (this.isAcceptingUserInput)
                {
                    // Normalize the input
                    AIMLLoader loader = new AIMLLoader(this);
                    LIAM.Normalize.SplitIntoSentences splitter = new LIAM.Normalize.SplitIntoSentences(this);
                    string[] rawSentences = splitter.Transform(request.rawInput);
                    foreach (string sentence in rawSentences)
                    {
                        result.InputSentences.Add(sentence);
                        string path = loader.generatePath(sentence, request.user.getLastBotOutput(), request.user.Topic, true);
                        result.NormalizedPaths.Add(path);
                    }

                    // grab the templates for the various sentences from the graphmaster
                    foreach (string path in result.NormalizedPaths)
                    {
                        Utils.SubQuery query = new SubQuery(path);
                        query.Template = this.Graphmaster.evaluate(path, query, request, MatchState.UserInput, new StringBuilder());
                        result.SubQueries.Add(query);
                    }

                    // process the templates into appropriate output
                    foreach (SubQuery query in result.SubQueries)
                    {
                        if (query.Template.Length > 0)
                        {
                            try
                            {
                                XmlNode templateNode = AIMLTagHandler.getNode(query.Template);
                                string outputSentence = this.processNode(templateNode, query, request, result, request.user);
                                if (outputSentence.Length > 0)
                                {
                                    result.OutputSentences.Add(outputSentence);
                                }
                            }
                            catch
                            {
                                this.writeToLog("WARNING! A problem was encountered when trying to process the input: " + request.rawInput + " with the template: \"" + query.Template + "\"");
                            }
                        }
                    }
                }
                else
                {
                    result.OutputSentences.Add(this.NotAcceptingUserInputMessage);
                }

                // populate the Result object
                result.Duration = DateTime.Now - request.StartedOn;
                request.user.addResult(result);

                return result;
            });
        }

        /// <summary>
        /// Recursively evaluates the template nodes returned from the bot
        /// </summary>
        /// <param name="node">the node to evaluate</param>
        /// <param name="query">the query that produced this node</param>
        /// <param name="request">the request from the user</param>
        /// <param name="result">the result to be sent to the user</param>
        /// <param name="user">the user who originated the request</param>
        /// <returns>the output string</returns>
        private string processNode(XmlNode node, SubQuery query, Request request, Result result, User user)
        {
            // check for timeout (to avoid infinite loops)
            if (request.StartedOn.AddMilliseconds(request.bot.TimeOut) < DateTime.Now)
            {
                request.bot.writeToLog("WARNING! Request timeout. User: " + request.user.UserID + " raw input: \"" + request.rawInput + "\" processing template: \""+query.Template+"\"");
                request.hasTimedOut = true;
                return string.Empty;
            }
                        
            // process the node
            string tagName = node.Name.ToLower();
            if (tagName == "utterance")
            {
                StringBuilder templateResult = new StringBuilder();
                if (node.HasChildNodes)
                {
                    // recursively check
                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        templateResult.Append(this.processNode(childNode, query, request, result, user));
                    }
                }
                return templateResult.ToString();
            }
            else
            {
                AIMLTagHandler tagHandler = null;
                tagHandler = this.getBespokeTags(user, query, request, result, node);
                if (object.Equals(null, tagHandler))
                {
                    switch (tagName)
                    {
                        case "command":

                            break;
                        case "bot":
                            tagHandler = new AIMLTagHandlers.bot(this, user, query, request, result, node);
                            break;
                        case "condition":
                            tagHandler = new AIMLTagHandlers.condition(this, user, query, request, result, node);
                            break;
                        case "time":
                        case "date":
                            tagHandler = new AIMLTagHandlers.date(this, user, query, request, result, node);
                            break;
                        case "formal":
                            tagHandler = new AIMLTagHandlers.formal(this, user, query, request, result, node);
                            break;
                        case "gender":
                            tagHandler = new AIMLTagHandlers.gender(this, user, query, request, result, node);
                            break;
                        case "get":
                            tagHandler = new AIMLTagHandlers.get(this, user, query, request, result, node);
                            break;
                        case "gossip":
                            tagHandler = new AIMLTagHandlers.gossip(this, user, query, request, result, node);
                            break;
                        case "id":
                            tagHandler = new AIMLTagHandlers.id(this, user, query, request, result, node);
                            break;
                        case "input":
                            tagHandler = new AIMLTagHandlers.input(this, user, query, request, result, node);
                            break;
                        case "javascript":
                            tagHandler = new AIMLTagHandlers.javascript(this, user, query, request, result, node);
                            break;
                        case "learn":
                            tagHandler = new AIMLTagHandlers.learn(this, user, query, request, result, node);
                            break;
                        case "lowercase":
                            tagHandler = new AIMLTagHandlers.lowercase(this, user, query, request, result, node);
                            break;
                        case "person":
                            tagHandler = new AIMLTagHandlers.person(this, user, query, request, result, node);
                            break;
                        case "person2":
                            tagHandler = new AIMLTagHandlers.person2(this, user, query, request, result, node);
                            break;
                        case "random":
                            tagHandler = new AIMLTagHandlers.random(this, user, query, request, result, node);
                            break;
                        case "sentence":
                            tagHandler = new AIMLTagHandlers.sentence(this, user, query, request, result, node);
                            break;
                        case "set":
                            tagHandler = new AIMLTagHandlers.set(this, user, query, request, result, node);
                            break;
                        case "size":
                            tagHandler = new AIMLTagHandlers.size(this, user, query, request, result, node);
                            break;
                        case "sr":
                            tagHandler = new AIMLTagHandlers.sr(this, user, query, request, result, node);
                            break;
                        case "srai":
                            tagHandler = new AIMLTagHandlers.srai(this, user, query, request, result, node);
                            break;
                        case "star":
                            tagHandler = new AIMLTagHandlers.star(this, user, query, request, result, node);
                            break;
                        case "system":
                            tagHandler = new AIMLTagHandlers.system(this, user, query, request, result, node);
                            break;
                        case "that":
                            tagHandler = new AIMLTagHandlers.that(this, user, query, request, result, node);
                            break;
                        case "thatstar":
                            tagHandler = new AIMLTagHandlers.thatstar(this, user, query, request, result, node);
                            break;
                        case "think":
                            tagHandler = new AIMLTagHandlers.think(this, user, query, request, result, node);
                            break;
                        case "topicstar":
                            tagHandler = new AIMLTagHandlers.topicstar(this, user, query, request, result, node);
                            break;
                        case "uppercase":
                            tagHandler = new AIMLTagHandlers.uppercase(this, user, query, request, result, node);
                            break;
                        case "version":
                            tagHandler = new AIMLTagHandlers.version(this, user, query, request, result, node);
                            break;
                        default:
                            tagHandler = null;
                            break;
                    }
                }
                if (object.Equals(null, tagHandler))
                {
                    return node.InnerText;
                }
                else
                {
                    if (tagHandler.isRecursive)
                    {
                        if (node.HasChildNodes)
                        {
                            // recursively check
                            foreach (XmlNode childNode in node.ChildNodes)
                            {
                                if (childNode.NodeType != XmlNodeType.Text)
                                {
                                    childNode.InnerXml = this.processNode(childNode, query, request, result, user);
                                }
                            }
                        }
                        return tagHandler.Transform();
                    }
                    else
                    {
                        string resultNodeInnerXML = tagHandler.Transform();
                        XmlNode resultNode = AIMLTagHandler.getNode("<node>" + resultNodeInnerXML + "</node>");
                        if (resultNode.HasChildNodes)
                        {
                            StringBuilder recursiveResult = new StringBuilder();
                            // recursively check
                            foreach (XmlNode childNode in resultNode.ChildNodes)
                            {
                                recursiveResult.Append(this.processNode(childNode, query, request, result, user));
                            }
                            return recursiveResult.ToString();
                        }
                        else
                        {
                            return resultNode.InnerXml;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Searches the CustomTag collection and processes the AIML if an appropriate tag handler is found
        /// </summary>
        /// <param name="user">the user who originated the request</param>
        /// <param name="query">the query that produced this node</param>
        /// <param name="request">the request from the user</param>
        /// <param name="result">the result to be sent to the user</param>
        /// <param name="node">the node to evaluate</param>
        /// <returns>the output string</returns>
        public AIMLTagHandler getBespokeTags(User user, SubQuery query, Request request, Result result, XmlNode node)
        {
            if (this.CustomTags.ContainsKey(node.Name.ToLower()))
            {
                TagHandler customTagHandler = (TagHandler)this.CustomTags[node.Name.ToLower()];

                AIMLTagHandler newCustomTag = customTagHandler.Instantiate(this.LateBindingAssemblies);
                if(object.Equals(null,newCustomTag))
                {
                    return null;
                }
                else
                {
                    newCustomTag.user = user;
                    newCustomTag.query = query;
                    newCustomTag.request = request;
                    newCustomTag.result = result;
                    newCustomTag.templateNode = node;
                    newCustomTag.bot = this;
                    return newCustomTag;
                }
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Serialization

        /// <summary>
        /// Saves the graphmaster node (and children) to a binary file to avoid processing the AIML each time the 
        /// bot starts
        /// </summary>
        /// <param name="path">the path to the file for saving</param>
        public void saveToBinaryFile(string path)
        {
            // check to delete an existing version of the file
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                fi.Delete();
            }

            FileStream saveFile = File.Create(path);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(saveFile, this.Graphmaster);
            saveFile.Close();
        }

        /// <summary>
        /// Loads a dump of the graphmaster into memory so avoiding processing the AIML files again
        /// </summary>
        /// <param name="path">the path to the dump file</param>
        public void loadFromBinaryFile(string path)
        {
            FileStream loadFile = File.OpenRead(path);
            BinaryFormatter bf = new BinaryFormatter();
            this.Graphmaster = (Node)bf.Deserialize(loadFile);
            loadFile.Close();
        }

        #endregion
    }
}
