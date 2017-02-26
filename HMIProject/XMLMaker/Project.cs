using System;
using System.Collections.Generic;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace HMIProject
{
    [XmlRootAttribute("Project", Namespace = "http://www.cpandl.com",
    IsNullable = false)]
    public class Project
    {
        [XmlAttribute]
        public string name;
        public List<GVariable> gVariableGroup;
        public List<ConditionEvent> conditionEvents;
        public List<Page> pageGroup;

        public Project() { }
        public Project(string nameValue)
        {
            this.name = nameValue;
        }
    }
}
