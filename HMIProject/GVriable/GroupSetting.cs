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
    public partial class GroupSetting : Form
    {
        public GVariable GroupSettingGVariable = new GVariable();

        public GroupSetting()
        {
            InitializeComponent();
        }

    

        private void GroupSetting_Load(object sender, EventArgs e)
        {
            string [] protocol = { "Hyundai-rotem" };
            string[] header = { "CMD01", "CMD02", "CMD80", "CMD81", "CMD82" };
            cbProtocol.Items.Add(protocol);
            cbHeader.Items.Add(header);
            cbProtocol.SelectedIndex = 0;
            cbHeader.SelectedIndex = 0;
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            Group newGroup = new Group();
            if (tcNetwork.SelectedIndex == 0)
            {
                newGroup.protocol = cbProtocol.SelectedText;
                newGroup.header = cbHeader.SelectedText;
                newGroup.name = tbGroupName.Text;
                newGroup.ipAddress = tbIPAddress.Text;
                newGroup.port = tbPort.Text;
            }
            else if (tcNetwork.SelectedIndex == 1)
            {

            }
            else if (tcNetwork.SelectedIndex == 2)
            {
            
            }
            GViewDlg.Groups.Add(newGroup);
            this.Close();
        }


        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
