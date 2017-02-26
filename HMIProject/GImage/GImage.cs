using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMIProject
{
    public partial class GImage : UserControl
    {
        string imageSource;
        public PictureBox pictureBox;
        public GImage()
        {
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            imageSource = "";
            InitializeComponent();
            this.Size = new Size(100, 100);
            pictureBox = new PictureBox();
            pictureBox.Image = Resources.GImageBasic;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.BackColor = Color.Transparent;
            pictureBox.Size = new Size(100, 100);
            this.BackColor = Color.Transparent;
            this.Controls.Add(pictureBox);
        }

        public void setSize(int width, int height)
        {
            this.Size = new Size(width, height);
            pictureBox.Size = new Size(width, height);
        }

        public string ImageSource
        {
            get
            {
                return imageSource;
            }

            set
            {
                imageSource = value;
                try
                {
                    pictureBox.Image = Bitmap.FromFile(HMIProjectNode.currentProjectDirectory + @"\"+imageSource);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Image File이 존재하지 않습니다.");
                    pictureBox.Image = Resources.GImageBasic;
                    imageSource = "";
                }
            }
        }
    }
}
