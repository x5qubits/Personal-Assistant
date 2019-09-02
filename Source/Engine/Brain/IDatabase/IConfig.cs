using System;
using System.Collections.Generic;

namespace puremvc.Engine.Brain.IDatabase
{
    [Serializable]
    public class IConfig
    {
        public SortedDictionary<string, IProgram> database = new SortedDictionary<string, IProgram>();
        public SortedDictionary<string, IWebSite> websites = new SortedDictionary<string, IWebSite>();
    }
}
