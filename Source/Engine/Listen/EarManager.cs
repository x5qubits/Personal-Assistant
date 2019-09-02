using System.Collections.Generic;
using puremvc.Engine.Listen.Interfaces;
using puremvc.Engine.Listen.SubClasses;

namespace puremvc.Engine.Listen
{
    public class EarManager
    {
        static readonly public EarManager Instance = new EarManager();
        private Dictionary<IlistenEnums, IListerner> avalibleListeners = new Dictionary<IlistenEnums, IListerner>
        {
            {IlistenEnums.AzureAST, new AzureAST() }
        };

        private EarManager()
        {

        }

        public void StartListen(IlistenEnums id)
        {
            if(avalibleListeners.ContainsKey(id))
            {
                avalibleListeners[id].Start();
            }
        }

        public void StopListen(IlistenEnums id)
        {
            if (avalibleListeners.ContainsKey(id))
            {
                avalibleListeners[id].Stop();
            }
        }

    }
}
