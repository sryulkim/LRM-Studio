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
        //static public List<GVariable> SList { set; get; } = new List<GVariable>(); // System gVariable List
        static public List<GVariable> MList { set; get; } = new List<GVariable>();//Memory gVariable List
        //static public List<GVariable> DIList { set; get; } = new List<GVariable>();//Digital Input gVariable List
        //static public List<GVariable> AIList { set; get; } = new List<GVariable>();//Analog Input gVariable List
        //static public List<GVariable> NRList { set; get; } = new List<GVariable>();//Network RS485 gVariable List
        //static public List<GVariable> NEList { set; get; } = new List<GVariable>();//Network Ethernet gVariable List
        //static public List<GVariable> NMList { set; get; } = new List<GVariable>();//Network MVB gVariable List
        static public GVariables gVariables = new GVariables();
        static public List<network> Configuration = new List<network>();

        public GViewDlg()
        {
            InitializeComponent();
            
        }
   

        private void ConfigDlg_Load(object sender, EventArgs e)
        {
            try
            {
                //XmlSerializer serializer = new XmlSerializer(typeof(HMIProject.GVariables));

                //TextReader reader = new StreamReader(HMIProject.HMIProjectNode.currentProjectDirectory + @"\GVariable.xml");

                //gVariables = (HMIProject.GVariables)serializer.Deserialize(reader);
                HMIProject.GViewDlg.MList.Clear();

                bool isLogEnableMade = false;
                foreach (HMIProject.GVariable gVariable in gVariables.gVariableGroup)
                {
                    switch (gVariable.type)
                    {
                        /*case "Event Log Enable":
                            if (gVariable.initialValue == "1")
                            {
                                logEnableCheckBox.Checked = true;
                            }
                            else
                                logEnableCheckBox.Checked = false;
                            isLogEnableMade = true;
                            break;*/
                        case "Memory":
                            HMIProject.GViewDlg.MList.Add(gVariable);
                            break;
                    }
                }

                /*if (!isLogEnableMade)
                    gVariables.gVariableGroup.Add(new GVariable("LogEnableFlag", "INT", "0", "Event Log Enable", "", "","", ""));*/

                //reader.Close();

               
            }
            catch (Exception ex)
            {
                HMIProject.GViewDlg.MList.Clear();
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
            Alarm dlg = new Alarm();

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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridView DGV;
            switch (tabControl.SelectedIndex) {
                case 0: DGV = dvMPoint; break;
                case 1: DGV = dvSPoint; break;
                case 2: DGV = dvNEPoint; break;
                case 3: DGV = dvMPoint; break;
                case 4: DGV = dvNRPoint; break;
                case 5: DGV = dvDIPoint; break;
                case 6: DGV = dvAIPoint; break;

                default: DGV = dvMPoint; break;
            }
            try
            {
                for (int i = 0; i < DGV.Rows.Count - 1; i++)
                {
                    int j = 0;
                    if (DGV.Rows[i].Selected == true)
                    {
                        GViewDlg.gVariables.gVariableGroup.Remove(GViewDlg.gVariables.gVariableGroup.Find(x => x.name.Contains(DGV.Rows[i].Cells[0].Value.ToString())));
                        DGV.Rows.Remove(DGV.Rows[i]);
                        j = 1;
                    }
                }
            }catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("삭제할 행을 선택하십시오");
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

        /*private void logEnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (HMIProject.GVariable gVariable in GViewDlg.gVariables.gVariableGroup)
            {
                if(gVariable.type == "Event Log Enable")
                {
                    if (logEnableCheckBox.Checked)
                        gVariable.initialValue = "1";
                    else
                        gVariable.initialValue = "0";

                    break;
                }
            }
        }*/

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dvNEPoint_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Ethernet_Click(object sender, EventArgs e)
        {

        }
    }

}

    

