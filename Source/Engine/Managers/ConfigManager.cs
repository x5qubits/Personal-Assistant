using System;
using System.Collections.Generic;
using puremvc.Engine.Brain.IDatabase;
using MsgPack.Serialization;
using System.IO;

namespace puremvc.Engine.Managers
{
    public sealed class ConfigManager
    {
        static readonly public ConfigManager Instance = new ConfigManager();
        public string PathToBin
        {
            get
            {
                return Path.Combine(Environment.CurrentDirectory, "data" + Path.DirectorySeparatorChar + "brain" + Path.DirectorySeparatorChar + "configs.bin");
            }
        }
        private IConfig configs;

        private ConfigManager()
        {
            configs = LoadDb();
        }

        public void init()
        {

        }

        public SortedDictionary<string, IProgram> knownPrograms()
        {
            return configs.database;
        }

        public SortedDictionary<string, IWebSite> knownSearch()
        {
            return configs.websites;
        }
        public void AddWebsite(string key, IWebSite program)
        {
            configs.websites[key] = program;
        }
        public void RemoveWebsite(string key)
        {
            if (configs.websites.ContainsKey(key))
                configs.websites.Remove(key);
        }

        public void AddProgram(string key, IProgram program)
        {
            configs.database[key] = program;
        }

        public void RemoveProgram(string key)
        {
            if (configs.database.ContainsKey(key))
                configs.database.Remove(key);
        }

        public void SaveDb()
        {
            using (var memStream = new MemoryStream())
            {
                var serializer = SerializationContext.Default.GetSerializer<IConfig>();
                serializer.Pack(memStream, configs);
                File.WriteAllBytes(this.PathToBin, memStream.ToArray());
            }
        }

        public IConfig LoadDb()
        {
            if (File.Exists(this.PathToBin))
            {
                using (var memStream = new MemoryStream())
                {
                    var serializer = SerializationContext.Default.GetSerializer<IConfig>();
                    byte[] x = File.ReadAllBytes(this.PathToBin);
                    memStream.Write(x, 0, x.Length);
                    memStream.Seek(0, SeekOrigin.Begin);
                    return serializer.Unpack(memStream);
                }
            }
            return new IConfig();
        }

        public void setKnownPrograms(SortedDictionary<string, IProgram> dB)
        {
            configs.database = new SortedDictionary<string, IProgram>(dB);
        }
        public void setKnownWebsites(SortedDictionary<string, IWebSite> dB)
        {
            configs.websites = new SortedDictionary<string, IWebSite>(dB);
        }
    }
}
