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
    public partial class Alarm : Form //G-Variable 생성자
    {

        public GVariable gVariable = new GVariable();
        public bool AlarmLowChecked = false;
        public bool AlarmHighChecked = false;

        public bool Confirmed { get; set; }

        public Alarm()
        {
            //git push test
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

            GViewDlg.gVariables.gVariableGroup.Add(gVariable);
            this.Close();
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
