using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace HMIProject
{
    public partial class HMIEditorForm : Form
    {
        public HMIEditorForm()
        {
            InitializeComponent();
            XmlSerializer serializer_gval = new XmlSerializer(typeof(GVariables));
            XmlSerializer serializer_condition = new XmlSerializer(typeof(List<ConditionEvent>));

            TextReader reader_gval = new StreamReader(HMIProjectNode.currentProjectDirectory + @"\GVariable.xml");
            TextReader reader_condition = new StreamReader(HMIProjectNode.currentProjectDirectory + @"\ConditionEvents.xml");

            StaticMethods.condtionEventList = (List<ConditionEvent>)serializer_condition.Deserialize(reader_condition);
            GViewDlg.gVariables = (GVariables)serializer_gval.Deserialize(reader_gval);

            bool isLogEnableMade = false;
            foreach (GVariable gVariable in GViewDlg.gVariables.gVariableGroup)
            {
                switch (gVariable.type)
                {
                    case "Event Log Enable":
                        isLogEnableMade = true;
                        break;
                    case "System":
                        GViewDlg.SList.Add(gVariable);
                        break;
                    case "Memory":
                        GViewDlg.MList.Add(gVariable);
                        break;
                    case "Digital Input":
                        GViewDlg.DIList.Add(gVariable);
                        break;
                    case "Analog Input":
                        GViewDlg.AIList.Add(gVariable);
                        break;
                    case "Network Ethernet":
                        GViewDlg.NEList.Add(gVariable);
                        break;
                    case "Network RS485":
                        GViewDlg.NRList.Add(gVariable);
                        break;
                    case "Network MVB":
                        GViewDlg.NMList.Add(gVariable);
                        break;
                }
            }
            if (!isLogEnableMade)
                GViewDlg.gVariables.gVariableGroup.Add(new GVariable("LogEnableFlag", "INT", "0", "Event Log Enable", "", ""));

            reader_gval.Close();
            reader_condition.Close();
        }

        private void HMIEditorForm_SizeChanged(object sender, EventArgs e)
        {

        }

        private void HMIEditorForm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void HMIEditorForm_Load(object sender, EventArgs e)
        {
      
        }
    }
}
