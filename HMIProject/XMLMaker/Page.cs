using System;
using System.Collections.Generic;

using System.Xml;
using System.Xml.Serialization; 
using System.IO;

namespace HMIProject
{
    public class Page
    {
        public string name;
        [XmlAttribute]
        public string number;
        public PageSize size;
        public string backgroundColor;
        public string backgroundImage;
        public string enable;
        public List<GUIO> guioGroup;
        public Page()
        {
            this.size = new PageSize();
            this.guioGroup = new List<GUIO>();
        }
    }

    public class PageSize
    {
        [XmlAttribute]
        public string width;
        [XmlAttribute]
        public string height;
    }
}
