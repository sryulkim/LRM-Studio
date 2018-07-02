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
    public partial class HMIClickEventsDialog : Form
    {
        public static GUIO button;
        public HMIClickEventsDialog()
        {
            button = HMIEditorPropertyToolWindowControl.selectedGUIO;
            InitializeComponent();
        }

        private void HMIClickEventsDialog_Load(object sender, EventArgs e)
        {
            var clickEventBindingSource = new BindingSource();
            clickEventBindingSource.DataSource = button.clickEvents;
            clickEventDataGridView.DataSource = clickEventBindingSource;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            HMIMakeClickEventDialog makeClickEventDialog = new HMIMakeClickEventDialog();
            makeClickEventDialog.ShowDialog();
            if (makeClickEventDialog.confirmFlag)
            {
                var clickEventBindingSource = new BindingSource();
                clickEventBindingSource.DataSource = button.clickEvents;
                clickEventDataGridView.DataSource = clickEventBindingSource;
                this.Refresh();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HMIClickEventsDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
