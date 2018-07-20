using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace HMIProject
{
    public class GVariable
    {
        //Common Part
        [DisplayName("변수명")]
        [XmlAttribute]
        public string name { get; set; }
        [DisplayName("카테고리")]
        [XmlAttribute]
        public string category { get; set; }
        [DisplayName("데이터타입")]
        [XmlAttribute]
        public string type { get; set; }
        [DisplayName("초기값")]
        [XmlAttribute]
        public string value { get; set; }
        //Network 변수
        [DisplayName("알람하이")]
        [XmlAttribute]
        public string alarmHigh { get; set; }
        [DisplayName("알람로우")]
        [XmlAttribute]
        public string alarmLow { get; set; }

        public GVariable()
        {
            this.name = "";
            this.type= "";
            this.category = "";
            this.value= "";
            this.alarmHigh= "";
            this.alarmLow= "";
        }

        public GVariable(string name, string type, string category, string value, string alarmHigh, string alarmLow)
        {
            this.name = name;
            this.type= type;
            this.category = category;
            this.value= value;
            this.alarmHigh= alarmHigh;
            this.alarmLow= alarmLow;
        }
    }

    [XmlRootAttribute("GVariables", Namespace = "http://www.cpandl.com", IsNullable = false)]
    public class GVariables
    {
        public List<network> Configuration;
        public List<GVariable> gVariableGroup;
        public GVariables()
        {
            this.Configuration = new List<network>();
            this.gVariableGroup = new List<GVariable>();
        }
    }


    public class network
    {
        public string protocol;
        public string name;
        public string header;
        public string ipAddress;
        public string port;
    }
}
