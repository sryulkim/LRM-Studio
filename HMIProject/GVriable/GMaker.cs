using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMIProject
{
    public partial class GMaker : Form //G-Variable 생성자
    {

        public GVariable gVariable = new GVariable();
        public bool AlarmLowChecked = false;
        public bool AlarmHighChecked = false;

        public bool Confirmed { get; set; }

        public GMaker()
        {
            InitializeComponent();
            //Alarm 설정 Disable시키기.
            tbLowAlarm.Enabled = false;
            tbLowPriority.Enabled = false;
            tbLowPage.Enabled = false;

            tbHighAlarm.Enabled = false;
            tbHighPriority.Enabled = false;
            tbHighPage.Enabled = false;

            tbMessage.Enabled = false;
            //cbType.Items.Add("System version");
            //cbType.Items.Add("System clock");
            //cbType.Items.Add("Digital Input");
            //cbType.Items.Add("Analog Input");

        }


    
      

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Confirmed = false;
            this.Close();
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            Confirmed = true;
            
            gVariable.name = tbName.Text;
            gVariable.type = tbDataType.Text;
            gVariable.initialValue = tbInitialValue.Text;
            gVariable.alarm = new Alarm();
            gVariable.alarm.high = new High();
            gVariable.alarm.low = new Low();
            //Alarm기능 추가하였을때
            if(AlarmHighChecked == true)
            {
                gVariable.alarm.high.value = tbHighAlarm.Text;
                gVariable.alarm.high.priority = tbHighPriority.Text;
                gVariable.alarm.high.page = tbHighPage.Text;
            }
            if (AlarmLowChecked == true)
            {
                gVariable.alarm.low.value = tbLowAlarm.Text;
                gVariable.alarm.low.priority = tbLowPriority.Text;
                gVariable.alarm.low.page = tbLowPage.Text;
            }

            switch (tbDataType.Text)
            {
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
            GViewDlg.gVariables.gVariableGroup.Add(gVariable);
            this.Close();
         }

        private void btnDataType_Click(object sender, EventArgs e)
        {
            TypeSetting dlg = new TypeSetting();
            dlg.ShowDialog();
            if(dlg.Confirmed == true)
            {
                if (dlg.SystemClockTypeChecked == true)
                {
                    tbDataType.Text = "System";
                }
                else if (dlg.MemoryTypeChecked == true)
                {
                    tbDataType.Text = "Memory";
                }
                else if (dlg.NetworkEthernetTypeChecked == true)
                {
                    tbDataType.Text = "Network Ethernet";
                    gVariable.ipAddress = dlg.TypeSettingGVariable.ipAddress;
                    gVariable.port = dlg.TypeSettingGVariable.port;
                }
                gVariable.dataType = dlg.TypeSettingGVariable.dataType;
                //else if (dlg.DigitalRelayTypeChecked == true)
                //{
                //    tbDataType.Text = "Digital Input";
                //    gVariable.diAddress = dlg.TypeSettingGVariable.diAddress;
                //    gVariable.diBit = dlg.TypeSettingGVariable.diBit;
                //}
                //else if (dlg.AnalogRelayTypeChecked == true)
                //{
                //    tbDataType.Text = "Analog Input";
                //    gVariable.aiAddress = dlg.TypeSettingGVariable.aiAddress;
                //    gVariable.aiBit = dlg.TypeSettingGVariable.aiBit;
                //}

                //else if (dlg.NetworkMVBTypeChecked == true)
                //{
                //    tbDataType.Text = "Network MVB";
                //    gVariable.nmPort = dlg.TypeSettingGVariable.nmPort;
                //    gVariable.nmFCode = dlg.TypeSettingGVariable.nmFCode;
                //    gVariable.nmBitPosition = dlg.TypeSettingGVariable.nmBitPosition;
                //    gVariable.nmBitLength = dlg.TypeSettingGVariable.nmBitLength;
                //}
                //else if (dlg.NetworkRS485TypeChecked == true)
                //{
                //    tbDataType.Text = "Network RS485";
                //    gVariable.nrAddress = dlg.TypeSettingGVariable.nrAddress;
                //    gVariable.nrBit = dlg.TypeSettingGVariable.nrBit;
                //    gVariable.nrBitLength = dlg.TypeSettingGVariable.nrBitLength;
                //}
                //else if (dlg.NetworkEthernetTypeChecked == true)
                //{
                //    tbDataType.Text = "Network Ehthernet";
                //    gVariable.neAddress = dlg.TypeSettingGVariable.neAddress;
                //    gVariable.nePort = dlg.TypeSettingGVariable.nePort;
                //}
                //gVariable.dataType = dlg.TypeSettingGVariable.dataType;

            }
       
        }

        private void chLow_CheckedChanged(object sender, EventArgs e)
        {
            tbLowAlarm.Enabled = true;
            tbLowPriority.Enabled = true;
            tbLowPage.Enabled = true;
            AlarmLowChecked = true;
        }

        private void chHigh_CheckedChanged(object sender, EventArgs e)
        {
            tbHighAlarm.Enabled = true;
            tbHighPriority.Enabled = true;
            tbHighPage.Enabled = true;
            AlarmHighChecked = true;
        }

        private void chMessage_CheckedChanged(object sender, EventArgs e)
        {
            tbMessage.Enabled = true;
        }

   
    }
}
