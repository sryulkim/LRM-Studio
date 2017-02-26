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
    public partial class HMIMakeVertexDialog : Form
    {
        public bool confirmFlag { get; set; }
        public static TextBox vtxXTextBox;
        public static TextBox vtxYTextBox;
        private HMIEditVertexesDialog hmiEditVertexesDialog;
        public HMIMakeVertexDialog()
        {
            InitializeComponent();
            vtxXTextBox = xTextBox;
            vtxYTextBox = yTextBox;
        }

        public HMIMakeVertexDialog(HMIEditVertexesDialog hmiEditVertexesDialog)
        {
            InitializeComponent();
            vtxXTextBox = xTextBox;
            vtxYTextBox = yTextBox;
            this.hmiEditVertexesDialog = hmiEditVertexesDialog;
        }



        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (xTextBox.Text != "" && yTextBox.Text != "")
            {
                vertex vtx = new vertex();
                vtx.x = xTextBox.Text;
                vtx.y = yTextBox.Text;
                vtx.scale = scaleTextBox.Text;
                HMIEditVertexesDialog.rail.vertexes.Add(vtx);
                confirmFlag = true;
                var vertexBindingSource = new BindingSource();
                vertexBindingSource.DataSource = HMIEditVertexesDialog.rail.vertexes;
                hmiEditVertexesDialog.vertexesDataGridView.DataSource = vertexBindingSource;
                hmiEditVertexesDialog.Refresh();
                this.Close();
            }
            else
                MessageBox.Show("값을 입력해 주세요.");
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            confirmFlag = false;
            this.Close();
        }
    }
}
