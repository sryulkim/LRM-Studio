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
    public partial class TypeSetting : Form
    {
        public GVariable TypeSettingGVariable = new GVariable();
        public bool Confirmed = false;
        //Type Check 여부 확인하는 변수
        public bool SystemClockTypeChecked = false;
        public bool MemoryTypeChecked = false;
        public bool DigitalRelayTypeChecked = false;
        public bool AnalogRelayTypeChecked = false;
        public bool NetworkMVBTypeChecked = false;
        public bool NetworkRS485TypeChecked = false;
        public bool NetworkEthernetTypeChecked = false;

        public TypeSetting()
        {
            InitializeComponent();
        }

    

        private void TypeSetting_Load(object sender, EventArgs e)
        {
            gbSystem.Enabled = true;
            gbMemory.Enabled = false;
            gbRelay.Enabled = false;
            gbNetwork.Enabled = false;
            
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            Confirmed = true;
            if (rbSystem.Checked == true)
            {
                SystemClockTypeChecked = true;
                if(rbSystemClock.Checked == true)
                {
                    TypeSettingGVariable.type = "Clock";
                }
                else if (rbSystemVersion.Checked == true)
                {
                    TypeSettingGVariable.type = "Version";
                }
                else if (rbSystemPage.Checked == true)
                {
                    TypeSettingGVariable.type = "Page";
                }
            }
            else if (rbMemory.Checked == true)
            {
                TypeSettingGVariable.type = "Memory";
                MemoryTypeChecked = true;
                if (rbMemoryBool.Checked == true)
                {
                    TypeSettingGVariable.dataType = "BOOL";
                }
                else if (rbMemoryInt.Checked == true)
                {
                    TypeSettingGVariable.dataType = "INT";

                }
                else if (rbMemoryReal.Checked == true)
                {
                    TypeSettingGVariable.dataType = "REAL";

                }
                else if (rbMemoryString.Checked == true)
                {
                    TypeSettingGVariable.dataType = "STRING";

                }

            }
            else if (rbRelay.Checked == true)
            {
                if (tcRelay.SelectedTab.Text == "Digital")
                {
                    DigitalRelayTypeChecked = true;

                }
                else if(tcRelay.SelectedTab.Text == "Analog")
                {
                    AnalogRelayTypeChecked = true;

                }
            }
            else if (rbNetwork.Checked == true)
            {
                if (tcNetwork.SelectedTab.Text == "MVB")
                {
                    NetworkMVBTypeChecked = true;
                }
                else if (tcNetwork.SelectedTab.Text == "RS485")
                {
                    NetworkRS485TypeChecked = true;
                }
                else if (tcNetwork.SelectedTab.Text == "Ethernet")
                {
                    NetworkEthernetTypeChecked = true;
                    TypeSettingGVariable.dataType = "Network Ethernet";
                    TypeSettingGVariable.ipAddress = tbIPAddress.Text;
                    TypeSettingGVariable.port = tbPort.Text;
                    if(comboBox11.SelectedIndex == 0)
                    {
                        TypeSettingGVariable.dataType = "BOOL";
                    }
                    else if (comboBox11.SelectedIndex == 1)
                    {
                        TypeSettingGVariable.dataType = "INT";
                    }
                    else if (comboBox11.SelectedIndex == 2)
                    {
                        TypeSettingGVariable.dataType = "REAL";
                    }
                    else if (comboBox11.SelectedIndex == 3)
                    {
                        TypeSettingGVariable.dataType = "STRING";
                    }
                }
            
            }
            this.Close();
        }

        private void rbSystemClock_CheckedChanged(object sender, EventArgs e)
        {
            //System type enabled 
            gbSystem.Enabled = true;
            //Memory type disabled 
            gbMemory.Enabled = false;
            //Relay type disabled 
            gbRelay.Enabled = false;
            //Network type disabled 
            gbNetwork.Enabled = false;

        }

        private void rbMemory_CheckedChanged(object sender, EventArgs e)
        {
            //System type disabled 
            gbSystem.Enabled = false;
            //Memory type enabled 
            gbMemory.Enabled = true;
            //Relay type disabled 
            gbRelay.Enabled = false;
            //Network type disabled 
            gbNetwork.Enabled = false;
        }

        private void rbRelay_CheckedChanged(object sender, EventArgs e)
        {
            //System type disabled 
            gbSystem.Enabled = false;
            //Memory type disabled 
            gbMemory.Enabled = false;
            //Relay type enabled 
            gbRelay.Enabled = true;
            //Network type disabled 
            gbNetwork.Enabled = false;

        }

        private void rbNetwork_CheckedChanged(object sender, EventArgs e)
        {
            //System type disabled 
            gbSystem.Enabled = false;
            //Memory type disabled 
            gbMemory.Enabled = false;
            //Relay type disabled 
            gbRelay.Enabled = false;
            //Network type true 
            gbNetwork.Enabled = true;

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Confirmed = false;
            this.Close();
        }

   
    }
}
