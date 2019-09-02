using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace puremvc.Engine.Brain.IDatabase
{
    [Serializable]
    public class IWebSite
    {
        public string Name { get; internal set; }
        public string Url { get; internal set; }
        public string Parameters { get; internal set; }
    }
}
