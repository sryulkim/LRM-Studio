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
    public partial class HMIEditFlickeringImagesDialog : Form
    {
        public static GUIO image;

        public HMIEditFlickeringImagesDialog()
        {
            image = HMIEditorPropertyToolWindowControl.selectedGUIO;
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            HMIMakeFlickeringImageDialog makeVertexDialog = new HMIMakeFlickeringImageDialog(this);
            makeVertexDialog.Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HMIEditFlickeringImagesDialog_Load(object sender, EventArgs e)
        {
            var flickeringImagesBindingSource = new BindingSource();
            flickeringImagesBindingSource.DataSource = image.flickeringImages;
            flickeringImagesDataGridView.DataSource = flickeringImagesBindingSource;
        }
    }
}
