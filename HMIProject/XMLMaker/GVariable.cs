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
        public string name { get; set; }
        [DisplayName("타입")]
        public string type { get; set; }
        [DisplayName("그룹")]
        public string group { get; set; }
        [DisplayName("데이터타입")]
        public string dataType { get; set; }
        [DisplayName("초기값")]
        public string initialValue { get; set; }
        //Network 변수
        [DisplayName("주소")]
        public string ipAddress { get; set; }
        [DisplayName("포트 번호")]
        public string port { get; set; }
        [DisplayName("바이트 번호")]
        public string byteNumber { get; set; }
        [DisplayName("비트 번호")]
        public string bitNumber { get; set; }
        [DisplayName("알람")]
        public Alarm alarm { get; set; }
        ////Network Ethernet
        //public string neAddress { get; set; }
        //public string nePort { get; set; }
        ////Network MVB
        //public string nmPort { get; set; }
        //public string nmFCode { get; set; }
        //public string nmSrcSnk { get; set; }
        //public string nmBitPosition { get; set; }
        //public string nmBitLength { get; set; }
        ////Network RS-485
        //public string nrAddress { get; set; } //RS-485 Address
        //public string nrBit { get; set; }
        //public string nrBitLength { get; set; }
        ////Digital Input
        //public string diAddress { get; set; } // Digital Input Address
        //public string diBit { get; set; } // Digital Input Bit positon 
        ////Analog Input
        //public string aiAddress { get; set; } // Analog Input Address
        //public string aiBit { get; set; } // Analog Input Bit positon 


        public GVariable()
        { }

        public GVariable(string name, string group, string dataType, string initialValue, string type,
                string byteNumber, string bitNumber
                )
        {
            this.name = name;
            this.group = group;
            this.type = type;
            this.dataType = dataType;
            this.initialValue = initialValue;
            this.byteNumber = byteNumber;
            this.bitNumber = bitNumber;

        }

    }

    [XmlRootAttribute("GVariables", Namespace = "http://www.cpandl.com", IsNullable = false)]
    public class GVariables
    {
        public List<Group> Groups;
        public List<GVariable> gVariableGroup;
        public GVariables()
        {
            this.Groups = new List<Group>();
            this.gVariableGroup = new List<GVariable>();
        }
    }


    public class Group
    {
        public string protocol;
        public string name;
        public string header;
        public string ipAddress;
        public string port;
    }
    public partial class Alarm
    {
        public High high;
        public Low low;
        public string message;
    }

    public partial class High
    {
        public string enable;
        public string value;
        public string priority;
        public string page;

    }
    public partial class Low
    {
        public string enable;
        public string value;
        public string priority;
        public string page;
    }

}
