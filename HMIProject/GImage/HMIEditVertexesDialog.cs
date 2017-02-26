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
    public partial class HMIEditVertexesDialog : Form
    {
        public static GUIO rail;
        
        public HMIEditVertexesDialog()
        {
            rail = HMIEditorPropertyToolWindowControl.selectedGUIO;
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            HMIMakeVertexDialog makeVertexDialog = new HMIMakeVertexDialog(this);
            makeVertexDialog.Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HMIEditVertexesDialog_Load(object sender, EventArgs e)
        {
            var vertexBindingSource = new BindingSource();
            vertexBindingSource.DataSource = rail.vertexes;
            vertexesDataGridView.DataSource = vertexBindingSource;
        }
    }
}
