using System;
using System.Collections.Generic;
using System.Xml;

namespace puremvc.Engine.Brain.IDatabase
{
    /// <summary>
    /// An entity represents detailed information that is relevant in the utterance. For example, in the utterance "Book a ticket to Paris", "Paris" is a location. By recognizing and labeling the entities that are mentioned in the user’s utterance, LUIS helps you choose the specific action to take to answer a user's request. 
    /// </summary>
    [Serializable]
    public class Entity
    {
        public string name;
        public string patern;
        public string thatText;
        public string answer;
        public Strategies strategy = Strategies.Conversation;

        public void ParsePatterns(XmlNode entity)
        {
            if (entity.FirstChild.Name == "entity")
                patern = entity.FirstChild.InnerText;
        }

        public List<string> GetAnswers()
        {
            List<string> response = new List<string>();
            XmlDocument result = new XmlDocument();
            try
            {
                result.LoadXml(answer);
            }
            catch { }
            foreach (XmlNode node in result.ChildNodes)
            {
                if (node.Name.ToLower() == "utterance")
                {
                    if (node.HasChildNodes)
                    {
                        foreach (XmlNode nnode in node.ChildNodes)
                        {
                            if (nnode.Name.ToLower() == "random")
                            {
                                if (nnode.HasChildNodes)
                                {
                                    // only grab <li> nodes
                                    foreach (XmlNode childNode in nnode.ChildNodes)
                                    {
                                        if (childNode.Name == "li")
                                        {
                                            response.Add(childNode.InnerXml);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
            return response;
        }

        public void ParseUtterance(XmlNode utterance)
        {
            XmlNode that = this.FindNode("that", utterance);
            if (!object.Equals(null, that))
            {
                thatText = that.InnerText;
            }
            XmlNode utterancex = this.FindNode("utterance", utterance);
            if (!object.Equals(null, utterancex))
            {
                answer = utterancex.OuterXml;
            }          
        }

        private XmlNode FindNode(string name, XmlNode node)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name == name)
                {
                    return child;
                }
            }
            return null;
        }
    }
}
