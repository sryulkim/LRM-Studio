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
    public partial class GViewDlg : Form //G-Variable 관리(생성,삭제)
    {
        //G-Variable 저장해 두는 List들
        //static public List<GVariable> SVList { set; get; } = new List<GVariable>();//System version gVariable List
        //static public List<GVariable> SCList { set; get; } = new List<GVariable>();//System clock gVariable List
        static public List<GVariable> SList { set; get; } = new List<GVariable>(); // System gVariable List
        static public List<GVariable> MList { set; get; } = new List<GVariable>();//Memory gVariable List
        static public List<GVariable> DIList { set; get; } = new List<GVariable>();//Digital Input gVariable List
        static public List<GVariable> AIList { set; get; } = new List<GVariable>();//Analog Input gVariable List
        static public List<GVariable> NRList { set; get; } = new List<GVariable>();//Network RS485 gVariable List
        static public List<GVariable> NEList { set; get; } = new List<GVariable>();//Network Ethernet gVariable List
        static public List<GVariable> NMList { set; get; } = new List<GVariable>();//Network MVB gVariable List
        static public GVariables gVariables = new GVariables();
        

        public GViewDlg()
        {
            InitializeComponent();
            
        }


        private void ConfigDlg_Load(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(HMIProject.GVariables));

                TextReader reader = new StreamReader(HMIProject.HMIProjectNode.currentProjectDirectory + @"\GVariable.xml");

                gVariables = (HMIProject.GVariables)serializer.Deserialize(reader);
                HMIProject.GViewDlg.SList.Clear();
                HMIProject.GViewDlg.MList.Clear();
                HMIProject.GViewDlg.DIList.Clear();
                HMIProject.GViewDlg.AIList.Clear();
                HMIProject.GViewDlg.NEList.Clear();
                HMIProject.GViewDlg.NRList.Clear();
                HMIProject.GViewDlg.NMList.Clear();
                foreach (HMIProject.GVariable gVariable in gVariables.gVariableGroup)
                {
                    switch (gVariable.type)
                    {
                        case "System":
                            HMIProject.GViewDlg.SList.Add(gVariable);
                            break;
                        case "Memory":
                            HMIProject.GViewDlg.MList.Add(gVariable);
                            break;
                        case "Digital Input":
                            HMIProject.GViewDlg.DIList.Add(gVariable);
                            break;
                        case "Analog Input":
                            HMIProject.GViewDlg.AIList.Add(gVariable);
                            break;
                        case "Network Ethernet":
                            HMIProject.GViewDlg.NEList.Add(gVariable);
                            break;
                        case "Network RS485":
                            HMIProject.GViewDlg.NRList.Add(gVariable);
                            break;
                        case "Network MVB":
                            HMIProject.GViewDlg.NMList.Add(gVariable);
                            break;
                    }
                }

                reader.Close();

                XmlSerializer serializer2 = new XmlSerializer(typeof(List<HMIProject.ConditionEvent>));

                TextReader reader2 = new StreamReader(HMIProject.HMIProjectNode.currentProjectDirectory + @"\ConditionEvents.xml");
                HMIProject.StaticMethods.condtionEventList = (List<HMIProject.ConditionEvent>)serializer2.Deserialize(reader2);
                reader2.Close();
            }
            catch (Exception ex)
            {
                HMIProject.GViewDlg.SList.Clear();
                HMIProject.GViewDlg.MList.Clear();
                HMIProject.GViewDlg.DIList.Clear();
                HMIProject.GViewDlg.AIList.Clear();
                HMIProject.GViewDlg.NEList.Clear();
                HMIProject.GViewDlg.NRList.Clear();
                HMIProject.GViewDlg.NMList.Clear();
                HMIProject.StaticMethods.condtionEventList = new List<ConditionEvent>();
            }
            //Binding Source 선언
            var bsS = new BindingSource();
            var bsDI = new BindingSource();
            var bsAI = new BindingSource();
            var bsNE = new BindingSource();
            var bsNR = new BindingSource();
            var bsNM = new BindingSource();
            var bsM = new BindingSource();
            

            //DataSource에 List 할당
            bsS.DataSource = SList;
            bsDI.DataSource = DIList;
            bsAI.DataSource = AIList;
            bsNE.DataSource = NEList;
            bsNR.DataSource = NRList;
            bsNM.DataSource = NMList;
            bsM.DataSource = MList;
            
            //DataGridView에 List DataSource 할당
            dvNEPoint.DataSource = bsNE;
            dvNRPoint.DataSource = bsNR;
            dvSPoint.DataSource = bsS;
            dvNMPoint.DataSource = bsNM;
            dvDIPoint.DataSource = bsDI;
            dvAIPoint.DataSource = bsAI;
            dvMPoint.DataSource = bsM;
            

            //Ethernet만 일단 해놓음..


            //dvNMPoint.DataSource = NMList;
            //dvNRPoint.DataSource = NRList;
            //dvNEPoint.DataSource = NEList;


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GMaker dlg = new GMaker();

            dlg.ShowDialog();
            if (dlg.Confirmed == true)
            {
                var bsM = new BindingSource();
                var bsS = new BindingSource();
                var bsNE = new BindingSource();
                var bsNM = new BindingSource();
                var bsNR = new BindingSource();
                var bsDI = new BindingSource();
                var bsAI = new BindingSource();
                
                //DataSource에 List 할당
                bsS.DataSource = SList;
                bsDI.DataSource = DIList;
                bsAI.DataSource = AIList;
                bsNE.DataSource = NEList;
                bsNR.DataSource = NRList;
                bsNM.DataSource = NMList;
                bsM.DataSource = MList;
                
                //DataGridView에 List DataSource 할당
                dvNEPoint.DataSource = bsNE;
                dvNRPoint.DataSource = bsNR;
                dvSPoint.DataSource = bsS;
                dvNMPoint.DataSource = bsNM;
                dvDIPoint.DataSource = bsDI;
                dvAIPoint.DataSource = bsAI;
                dvMPoint.DataSource = bsM;
                
                this.Refresh();
            }

           
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonConditionEvent_Click(object sender, EventArgs e)
        {
            HMIConditionEventsDialog ceDialog = new HMIConditionEventsDialog();
            ceDialog.Show();
        }

        protected override void OnClosed(EventArgs e)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(GVariables));
            TextWriter writer = new StreamWriter(HMIProjectNode.currentProjectDirectory + @"\GVariable.xml");
            serializer.Serialize(writer, GViewDlg.gVariables);
            writer.Close();


            serializer = new XmlSerializer(typeof(List<ConditionEvent>));
            writer = new StreamWriter(HMIProjectNode.currentProjectDirectory + @"\ConditionEvents.xml");
            serializer.Serialize(writer, StaticMethods.condtionEventList);
            writer.Close();
            base.OnClosed(e);
        }
    }

    [XmlRootAttribute("GVariables", Namespace = "http://www.cpandl.com",IsNullable = false)]
    public class GVariables
    {
        public List<GVariable> gVariableGroup;
        public GVariables()
        {
            this.gVariableGroup = new List<GVariable>();
        }
    }

    public class GVariable
    {
        //Common Part
        [DisplayName("변수명")]
        public string name { get; set; }
        [DisplayName("타입")]
        public string type { get; set; }
        [DisplayName("데이터타입")]
        public string dataType { get; set; }
        [DisplayName("초기값")]
        public string initialValue { get; set; }
        [DisplayName("주소")]
        public string ipAddress { get; set; }
        [DisplayName("포트 번호")]
        public string port { get; set; }
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

        public GVariable(string name, string dataType, string initialValue, string type, 
                string ipAddress, string port
                //string nmPort, string nmFCode, string nmSrcSnk, string nmBitPosition, string nmBitLength,
                //string nrAddress, string nrBit,
                //string diAddress, string diBit, 
                //string aiAddress, string aiBit
                )
        {
            this.name = name;
            this.type = type;
            this.dataType = dataType;
            this.initialValue = initialValue;
            this.ipAddress = ipAddress;
            this.port = port;

            //this.neAddress = neAddress;
            //this.nePort = nePort;
          
            //this.nmPort = nmPort;
            //this.nmFCode = nmFCode;
            //this.nmSrcSnk = nmSrcSnk;
            //this.nmBitPosition = nmBitPosition;
            //this.nmBitLength = nmBitLength;

            //this.nrAddress = nrAddress;
            //this.nrBit = nrBit;
            //this.nrBitLength = nrBitLength;

            //this.diAddress = diAddress;
            //this.diBit = diBit;

            //this.aiAddress = aiAddress;
            //this.aiBit = aiBit;
            
        }

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
