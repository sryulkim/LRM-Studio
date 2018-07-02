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
    public partial class HMIMakeFlickeringImageDialog : Form
    {
        private HMIEditFlickeringImagesDialog hmiEditFlickeringImagesDialog;
        public HMIMakeFlickeringImageDialog()
        {
            InitializeComponent();
        }

        public HMIMakeFlickeringImageDialog(HMIEditFlickeringImagesDialog hmiEditFlickeringImagesDialog)
        {
            InitializeComponent();
            this.hmiEditFlickeringImagesDialog = hmiEditFlickeringImagesDialog;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (imageNameTextBox.Text != "")
            {
                flickeringImage img = new flickeringImage();
                img.imageName = imageNameTextBox.Text;
                HMIEditFlickeringImagesDialog.image.flickeringImages.Add(img);
                var flickeringImageBindingSource = new BindingSource();
                flickeringImageBindingSource.DataSource = HMIEditFlickeringImagesDialog.image.flickeringImages;
                hmiEditFlickeringImagesDialog.flickeringImagesDataGridView.DataSource = flickeringImageBindingSource;
                hmiEditFlickeringImagesDialog.Refresh();
                this.Close();
            }
            else
                MessageBox.Show("Image Name을 입력해주세요.");
        }

        private void cancleButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
