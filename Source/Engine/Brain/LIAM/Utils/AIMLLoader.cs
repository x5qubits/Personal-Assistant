using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;
using puremvc.Engine.Brain.IDatabase;
using System.Collections;
using MsgPack.Serialization;
using System.Linq;

namespace LIAM.Utils
{
    /// <summary>
    /// A utility class for loading AIML files from disk into the graphmaster structure that 
    /// forms an AIML bot's "brain"
    /// </summary>
    public class AIMLLoader
    {
        #region Attributes
        /// <summary>
        /// The bot whose brain is being processed
        /// </summary>
        private LIAM.Bot bot;
      
        #endregion

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="bot">The bot whose brain is being processed</param>
        public AIMLLoader(LIAM.Bot bot)
        {
            this.bot = bot;
        }

        #region Methods

        /// <summary>
        /// Loads the AIML from files found in the bot's AIMLpath into the bot's brain
        /// </summary>
        public void loadAIML()
        {
            this.loadAIML(this.bot.PathToXML);
        }

        /// <summary>
        /// Loads the AIML from files found in the path
        /// </summary>
        /// <param name="path"></param>
        public void loadAIML(string path)
        {
            if(File.Exists(this.bot.PathToBin))
            {
                using (var memStream = new MemoryStream())
                {
                    var serializer = SerializationContext.Default.GetSerializer<Intent[]>();
                    byte[] x = File.ReadAllBytes(this.bot.PathToBin);
                    memStream.Write(x, 0, x.Length);
                    memStream.Seek(0, SeekOrigin.Begin);
                    Intent[] obj = serializer.Unpack(memStream);
                    this.bot.root = new IRoot();
                    this.bot.root.idents = new SortedDictionary<int, Intent>();
                    for (int i = 0; i < obj.Length; i++)
                    {
                        Intent intent = obj[i];
                        //intent.type = IntentType.Ident;
                        this.bot.root.idents[i] = intent;
                        this.bot.root.idents[i].Id = i;
                        switch (intent.type)
                        {
                            case IntentType.Utterance:
                                this.processUtterance(intent);
                                break;
                            case IntentType.Ident:
                                this.processCategory(intent);
                                break;
                        }
                    }
                }
                return;
            }
            if (Directory.Exists(path))
            {
                this.bot.root = new IRoot();
                this.bot.root.idents = new SortedDictionary<int, Intent>();
                // process the AIML
                this.bot.writeToLog("Starting to process AIML files found in the directory " + path);

                string[] fileEntries = Directory.GetFiles(path, "*.aiml");
                if (fileEntries.Length > 0)
                {
                    foreach (string filename in fileEntries)
                    {
                        this.loadAIMLFile(filename);
                    }
                    this.bot.writeToLog("Finished processing the AIML files. " + Convert.ToString(this.bot.Size) + " categories processed.");
                }
                else
                {
                    throw new FileNotFoundException("Could not find any .aiml files in the specified directory (" + path + "). Please make sure that your aiml file end in a lowercase aiml extension, for example - myFile.aiml is valid but myFile.AIML is not.");
                }
            }
            else
            {
                throw new FileNotFoundException("The directory specified as the path to the AIML files (" + path + ") cannot be found by the AIMLLoader object. Please make sure the directory where you think the AIML files are to be found is the same as the directory specified in the settings file.");
            }
        }

        /// <summary>
        /// Given the name of a file in the AIML path directory, attempts to load it into the 
        /// graphmaster
        /// </summary>
        /// <param name="filename">The name of the file to process</param>
        public void loadAIMLFile(string filename)
        {
            this.bot.writeToLog("Processing AIML file: " + filename);
            // load the document
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            this.loadAIMLFromXML(doc, filename);
        }

        /// <summary>
        /// Given an XML document containing valid AIML, attempts to load it into the graphmaster
        /// </summary>
        /// <param name="doc">The XML document containing the AIML</param>
        /// <param name="filename">Where the XML document originated</param>
        public void loadAIMLFromXML(XmlDocument doc, string filename)
        {
            // Get a list of the nodes that are children of the <aiml> tag
            // these nodes should only be either <topic> or <category>
            // the <topic> nodes will contain more <category> nodes
            XmlNodeList rootChildren = doc.DocumentElement.ChildNodes;
            // process each of these child nodes
            int i = 0;
            foreach (XmlNode currentNode in rootChildren)
            {
                if (currentNode.Name == "topic")
                {
                    string category = "hidden";
                    if (currentNode.Attributes.Count > 0)
                    {
                        category = currentNode.Attributes[0].Value;
                    }
                    Intent ident = new Intent();
                    ident.Name = category;
                    ident.type = IntentType.Utterance;
                    ident.entity = new Entity();
                    ident.entity.ParseUtterance(currentNode);
                    ident.PathToFile = filename;
                    this.bot.root.idents[i] = ident;
                    this.bot.root.idents[i].Id = i;
                }
                else if (currentNode.Name == "ident")
                {
                    string category = "hidden";
                    if(currentNode.Attributes.Count > 0)
                    {
                        category = currentNode.Attributes[0].Value;
                    }
                    Intent ident = new Intent();
                    ident.type = IntentType.Ident;
                    ident.Name = category;
                    ident.entity = new Entity();
                    ident.entity.ParsePatterns(currentNode);
                    ident.entity.ParseUtterance(currentNode);
                    ident.PathToFile = filename;
                    this.bot.root.idents[i] = ident;
                    this.bot.root.idents[i].Id = i;

                }
                i++;
            }
            foreach (Intent intent in this.bot.root.idents.Values)
            {
                switch(intent.type)
                {
                    case IntentType.Utterance:
                        this.processUtterance(intent);
                        break;
                    case IntentType.Ident:
                        this.processCategory(intent);
                        break;
                }
            }
        }

        private void processUtterance(Intent intent)
        {

        }

        private void processCategory(Intent intent)
        {
            string pattern = intent.entity.patern;
            
            if (object.Equals(null, pattern))
            {
                throw new XmlException("Missing pattern tag in a node found in " + intent.PathToFile);
            }
            if (object.Equals(null, intent.entity.answer))
            {
                throw new XmlException("Missing template tag in the node with pattern: " + pattern + " found in " + intent.PathToFile);
            }

            string patternText;
            string thatText = "*";
            if (object.Equals(null, pattern))
            {
                patternText = string.Empty;
            }
            else
            {
                patternText = pattern;
            }
            if (!object.Equals(null, intent.entity.thatText))
            {
                thatText = intent.entity.thatText;
            }

            string categoryPath = this.generatePath(patternText, thatText, "*", false);

            // o.k., add the processed AIML to the GraphMaster structure
            if (categoryPath.Length > 0)
            {
                try
                {
                    this.bot.Graphmaster.addCategory(categoryPath, intent.entity.answer, intent);
                    // keep count of the number of categories that have been processed
                    this.bot.Size++;
                }
                catch
                {
                    this.bot.writeToLog("ERROR! Failed to load a new category into the graphmaster where the path = " + categoryPath + " and template = " + intent.entity.answer + " produced by a category in the file: " + intent.PathToFile);
                }
            }
            else
            {
                this.bot.writeToLog("WARNING! Attempted to load a new category with an empty pattern where the path = " + categoryPath + " and template = " + intent.entity.answer + " produced by a category in the file: " + intent.PathToFile);
            }
        }

        public void SaveDB()
        {
            using (var memStream = new MemoryStream())
            {
                var serializer = SerializationContext.Default.GetSerializer<Intent[]>();
                serializer.Pack(memStream, this.bot.root.idents.ToArray());
                File.WriteAllBytes(this.bot.PathToBin, memStream.ToArray());
            }
        }

        public void Backup()
        {
            using (var memStream = new MemoryStream())
            {
                var serializer = SerializationContext.Default.GetSerializer<Intent[]>();
                serializer.Pack(memStream, this.bot.root.idents.ToArray());
                File.WriteAllBytes(this.bot.PathToBin + "_backup", memStream.ToArray());
            }
        }
        /// <summary>
        /// Generates a path from a category XML node and topic name
        /// </summary>
        /// <param name="node">the category XML node</param>
        /// <param name="topicName">the topic</param>
        /// <param name="isUserInput">marks the path to be created as originating from user input - so
        /// normalize out the * and _ wildcards used by AIML</param>
        /// <returns>The appropriately processed path</returns>
        public string generatePath(XmlNode node, string topicName, bool isUserInput)
        {
            // get the nodes that we need
            XmlNode pattern = this.FindNode("entity", node);
            XmlNode that = this.FindNode("that", node);

            string patternText;
            string thatText = "*";
            if (object.Equals(null, pattern))
            {
                patternText = string.Empty;
            }
            else
            {
                patternText = pattern.InnerText;
            }
            if (!object.Equals(null, that))
            {
                thatText = that.InnerText;
            }

            return this.generatePath(patternText, thatText, topicName, isUserInput);
        }

        /// <summary>
        /// Given a name will try to find a node named "name" in the childnodes or return null
        /// </summary>
        /// <param name="name">The name of the node</param>
        /// <param name="node">The node whose children need searching</param>
        /// <returns>The node (or null)</returns>
        private XmlNode FindNode(string name, XmlNode node)
        {
            foreach(XmlNode child in node.ChildNodes)
            {
                if (child.Name == name)
                {
                    return child;
                }
            }
            return null;
        }
        /// <summary>
        /// Given a name will try to find a node named "name" in the childnodes or return null
        /// </summary>
        /// <param name="name">The name of the node</param>
        /// <param name="node">The node whose children need searching</param>
        /// <returns>The node (or null)</returns>
        private XmlNode[] FindNodes(string name, XmlNode node)
        {
            List<XmlNode> data = new List<XmlNode>();
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name == name)
                {
                    data.Add(child);
                }
            }
            return data.ToArray() ;
        }
        /// <summary>
        /// Generates a path from the passed arguments
        /// </summary>
        /// <param name="entity">the pattern</param>
        /// <param name="that">the that</param>
        /// <param name="topicName">the topic</param>
        /// <param name="isUserInput">marks the path to be created as originating from user input - so
        /// normalize out the * and _ wildcards used by AIML</param>
        /// <returns>The appropriately processed path</returns>
        public string generatePath(string pattern, string that, string topicName, bool isUserInput)
        {
            // to hold the normalized path to be entered into the graphmaster
            StringBuilder normalizedPath = new StringBuilder();
            string normalizedPattern = string.Empty;
            string normalizedThat = "*";
            string normalizedTopic = "*";

            if ((this.bot.Trust)&(!isUserInput))
            {
                normalizedPattern = pattern.Trim();
                normalizedThat = that.Trim();
                normalizedTopic = topicName.Trim();
            }
            else
            {
                normalizedPattern = this.Normalize(pattern, isUserInput).Trim();
                normalizedThat = this.Normalize(that, isUserInput).Trim();
                normalizedTopic = this.Normalize(topicName, isUserInput).Trim();
            }

            // check sizes
            if (normalizedPattern.Length > 0)
            {
                if (normalizedThat.Length == 0)
                {
                    normalizedThat = "*";
                }
                if (normalizedTopic.Length == 0)
                {
                    normalizedTopic = "*";
                }

                // This check is in place to avoid huge "that" elements having to be processed by the 
                // graphmaster. 
                if (normalizedThat.Length > this.bot.MaxThatSize)
                {
                    normalizedThat = "*";
                }

                // o.k. build the path
                normalizedPath.Append(normalizedPattern);
                normalizedPath.Append(" <that> ");
                normalizedPath.Append(normalizedThat);
                normalizedPath.Append(" <topic> ");
                normalizedPath.Append(normalizedTopic);

                return normalizedPath.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Given an input, provide a normalized output
        /// </summary>
        /// <param name="input">The string to be normalized</param>
        /// <param name="isUserInput">True if the string being normalized is part of the user input path - 
        /// flags that we need to normalize out * and _ chars</param>
        /// <returns>The normalized string</returns>
        public string Normalize(string input, bool isUserInput)
        {
            StringBuilder result = new StringBuilder();

            // objects for normalization of the input
            Normalize.ApplySubstitutions substitutor = new LIAM.Normalize.ApplySubstitutions(this.bot);
            Normalize.StripIllegalCharacters stripper = new LIAM.Normalize.StripIllegalCharacters(this.bot);

            string substitutedInput = substitutor.Transform(input);
            // split the pattern into it's component words
            string[] substitutedWords = substitutedInput.Split(" \r\n\t".ToCharArray());

            // Normalize all words unless they're the AIML wildcards "*" and "_" during AIML loading
            foreach (string word in substitutedWords)
            {
                string normalizedWord;
                if (isUserInput)
                {
                    normalizedWord = stripper.Transform(word);
                }
                else
                {
                    if ((word == "*") || (word == "_"))
                    {
                        normalizedWord = word;
                    }
                    else
                    {
                        normalizedWord = stripper.Transform(word);
                    }
                }
                result.Append(normalizedWord.Trim() + " ");
            }

            return result.ToString().Replace("  "," "); // make sure the whitespace is neat
        }
        #endregion
    }
}
