using puremvc.Engine.Brain.IDatabase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace puremvc.Engine.Brain.IDatabase
{
    [Serializable]
    public class IRoot
    {
        public SortedDictionary<int, Intent> idents = new SortedDictionary<int, Intent>();
        public Intent getIdent(int element)
        {
            Intent returnx = null;
            if (idents.TryGetValue(element, out returnx))
                return returnx;
            else
                return null;
        }
        public bool removeElement(int id)
        {
            if (idents.ContainsKey(id))
            {
                idents.Remove(id);
                
                return true;
            }

            return false;
        }
        public bool Add(Intent ident)
        {
            int nextK = idents.Keys.Last() + 1;
            ident.Id = nextK;
            idents.Add(nextK, ident);
            return true;
        }
        public SortedDictionary<int, Intent> resortDic()
        {
            SortedDictionary<int, Intent> datanewx = new SortedDictionary<int, Intent>(idents);
            SortedDictionary<int, Intent> datanew = new SortedDictionary<int, Intent>();
            int i = 0;
            foreach (KeyValuePair<int, Intent> entry in datanewx)
            {
                datanew[i] = entry.Value;
                i++;
            }
            return datanew;
        }
    }
}
