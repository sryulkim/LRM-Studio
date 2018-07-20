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

            System.IO.FileInfo fi = new System.IO.FileInfo(HMIProjectNode.currentProjectDirectory + @"\GVaraible.xml");
            if(fi.Exists)
            { 
                TextReader reader_gval = new StreamReader(HMIProjectNode.currentProjectDirectory + @"\GVariable.xml");
                GViewDlg.gVariables = (GVariables)serializer_gval.Deserialize(reader_gval);
                reader_gval.Close();
            }

            System.IO.FileInfo fi_ = new System.IO.FileInfo(HMIProjectNode.currentProjectDirectory + @"\ConditionEvents.xml");
            if (fi_.Exists)
            {
                TextReader reader_condition = new StreamReader(HMIProjectNode.currentProjectDirectory + @"\ConditionEvents.xml");
                StaticMethods.condtionEventList = (List<ConditionEvent>)serializer_condition.Deserialize(reader_condition);
                reader_condition.Close();
            }

            //bool isLogEnableMade = false;
            foreach (GVariable gVariable in GViewDlg.gVariables.gVariableGroup)
            {
                switch (gVariable.category)
                {
                    case "Memory":
                        GViewDlg.MList.Add(gVariable);
                        break;
                }
            }

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
