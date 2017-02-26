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
    public partial class HMIConditionEventsDialog : Form
    {
        public HMIConditionEventsDialog()
        {
            InitializeComponent();
        }

        private void HMIConditionEventsDialog_Load(object sender, EventArgs e)
        {
            var conditionEventBindingSource = new BindingSource();
            conditionEventBindingSource.DataSource = StaticMethods.condtionEventList;
            conditionEventsDataGridView.DataSource = conditionEventBindingSource;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            HMIMakeConditionEventDialog makeConditionEventDialog = new HMIMakeConditionEventDialog();
            makeConditionEventDialog.ShowDialog();
            if (makeConditionEventDialog.confirmFlag)
            {
                var conditionEventBindingSource = new BindingSource();
                conditionEventBindingSource.DataSource = StaticMethods.condtionEventList;
                conditionEventsDataGridView.DataSource = conditionEventBindingSource;
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
    }
}
