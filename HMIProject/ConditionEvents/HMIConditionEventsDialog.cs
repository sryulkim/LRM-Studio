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

        private void HMIConditionEventsDialog_SizeChanged(object sender, EventArgs e)
        {
            conditionEventsDataGridView.Size = new Size(this.Size.Width - 40, this.Size.Height - 104);
            addButton.Location = new Point(this.conditionEventsDataGridView.Width - 281, this.conditionEventsDataGridView.Height + 30);
            deleteButton.Location = new Point(this.conditionEventsDataGridView.Width - 171, this.conditionEventsDataGridView.Height + 30);
            closeButton.Location = new Point(this.conditionEventsDataGridView.Width - 61, this.conditionEventsDataGridView.Height + 30);
        }
    }
}
