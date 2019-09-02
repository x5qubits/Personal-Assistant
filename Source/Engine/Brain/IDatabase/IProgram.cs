using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace puremvc.Engine.Brain.IDatabase
{
    [Serializable]
    public class IProgram
    {
        public string Name { get; internal set; }
        public string Parameters { get; internal set; }
        public string Path { get; internal set; }
    }
}
