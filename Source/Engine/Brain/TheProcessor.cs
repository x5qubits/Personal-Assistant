using LIAM;
using MsgPack.Serialization;
using puremvc.Engine.Brain.IDatabase;
using puremvc.Engine.Listen.SubClasses;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace puremvc.Engine.Brain
{
    public class TheProcessor
    {
        static readonly public TheProcessor Instance = new TheProcessor();
        private Bot process = new Bot();
        private readonly User user;
        private readonly MainListener mainListener;
        private bool isprocessing = false;

        #region FUNCTIONS AND DATABASE
        public void backupDB()
        {
            process.BackupDb();
        }
        public string Normalize(string input, bool isUserInput)
        {
            StringBuilder result = new StringBuilder();

            // objects for normalization of the input
            LIAM.Normalize.ApplySubstitutions substitutor = new LIAM.Normalize.ApplySubstitutions(this.process);
            LIAM.Normalize.StripIllegalCharacters stripper = new LIAM.Normalize.StripIllegalCharacters(this.process);

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

            return result.ToString().Replace("  ", " "); // make sure the whitespace is neat
            
        }

        public string[] SplitNormalize(string input)
        {
            StringBuilder result = new StringBuilder();

            // objects for normalization of the input
            LIAM.Normalize.ApplySubstitutions substitutor = new LIAM.Normalize.ApplySubstitutions(this.process);
            LIAM.Normalize.StripIllegalCharacters stripper = new LIAM.Normalize.StripIllegalCharacters(this.process);

            string substitutedInput = substitutor.Transform(input);
            // split the pattern into it's component words
            return substitutedInput.Split(" \r\n\t".ToCharArray());

        }
        public IRoot getDb()
        {
            return process.root;
        }

        public void setDB(IRoot db)
        {
            process.root = db;
        }

        public void AddIntent(Intent data)
        {
           // process.root.idents.Add(data);
        }

        public void SaveDatabase(bool isReload = false)
        {
            using (var memStream = new MemoryStream())
            {
                var serializer = SerializationContext.Default.GetSerializer<Intent[]>();
                serializer.Pack(memStream, this.process.root.idents.Values.ToArray());
                File.WriteAllBytes(this.process.PathToBin, memStream.ToArray());
            }

            if(isReload)
            {
                process.isAcceptingUserInput = false;
                process.loadAIMLFromFiles();
                process.isAcceptingUserInput = true;
            }
        }
        #endregion
        #region CONSTRUCTOR
        private TheProcessor()
        {
            process.loadSettings();
            user = new User("TheProcessor", process);
            mainListener = MainListener.Instance;
            process.isAcceptingUserInput = false;
            process.loadAIMLFromFiles();
            process.isAcceptingUserInput = true;
            mainListener.StartDefault();
        }

        public void init()
        {

        }
        #endregion

        public void Reload()
        {
            process.isAcceptingUserInput = false;
            process.loadAIMLFromFiles();
            process.isAcceptingUserInput = true;
        }

        public void Process(string speach, bool isMainListener = false)
        {
            if (isprocessing) return;
            Task.Factory.StartNew(async () =>
            {
                isprocessing = true;
                try
                {               
                    await Processs(speach, isMainListener);
                }
                catch { }
                isprocessing = false;
            });
        }

        public Result TestProcess(string speach)
        {
            Request request = new Request(speach, user, process);
            return process.Querys(request);
        }

        private async Task<bool> Processs(string speach, bool isMainListener)
        {
            if (!isMainListener)
            {
                TaskPanel.Instance.EnableAnimation(true);
                speach = Normalize(speach, true);
                Request request = new Request(speach, user, process);
                Result result = await process.Query(request);
                await DecisionMaking.Instance.process(result);
            }
            else
            {
                string random = MainListener.Instance.getRandomGreating();
                TaskPanel.Instance.BotSay(random);
                MouthManager.Instance.Speak(random);
                MainListener.Instance.StartListening(IlistenEnums.AzureAST);
                return true;
            }
            return false;
        }

    }
}
