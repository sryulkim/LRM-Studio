using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMIProject
{
    public class GRail : Panel
    {
        private const int WS_EX_TRANSPARENT = 0x20;
        public List<Edge> EdgeList;
        public List<Vertex> VertexList;
        string imageSource;
        int point;
        int totalLength;
        int xMax;
        int yMax;
        public PictureBox pictureBox;
        private int opacity = 10;
        [DefaultValue(10)]
        public int Opacity
        {
            get
            {
                return this.opacity;
            }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("value must be between 0 and 100");
                this.opacity = value;
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT;
                return cp;
            }
        }
        public GRail()
        {
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            EdgeList = new List<Edge>();
            VertexList = new List<Vertex>();
            imageSource = "";
            point = 0;
            totalLength = 0;
            this.Size = new Size(100, 100);
            xMax = 100;
            yMax = 100;
            pictureBox = new PictureBox();
            pictureBox.Image = Resources.GRailBasic;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(100, 100);
            pictureBox.BackColor = Color.Transparent;
            this.BackColor = Color.Transparent;
            this.Controls.Add(pictureBox);
        }
        public void setSize(int width, int height)
        {
            this.Size = new Size(width, height);
            pictureBox.Size = new Size(width, height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (var brush = new SolidBrush(Color.FromArgb(this.opacity * 255 / 100, this.BackColor)))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
            base.OnPaint(e);
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            foreach (Edge edge in EdgeList)
            {
                path.AddLine(edge.StartPoint.X, edge.StartPoint.Y, edge.EndPoint.X, edge.EndPoint.Y);
            }

            e.Graphics.DrawPath(new Pen(Color.FromArgb(155, 0, 0, 255), 1), path);
        }

        public void AddLocation(int x, int y, double scale)
        {
            if (xMax < x)
                xMax = x;
            if (yMax < y)
                yMax = y;
            //this.Size = new Size(xMax, yMax);
            Vertex vertex = new Vertex(x, y, scale);
            if (VertexList.Count != 0)
            {
                Edge edge = new Edge(VertexList.Last(), vertex);
                totalLength += edge.Length;
                EdgeList.Add(edge);
                //pictureBox.Location = new System.Drawing.Point(VertexList.First().X, VertexList.First().Y);
            }
            else
            {
                //pictureBox.Location = new System.Drawing.Point(vertex.X, vertex.Y);
            }
            VertexList.Add(vertex);
            Refresh();
        }

        public Vertex PointToLocation()
        {
            Edge findEdge = EdgeList.Last();
            int findLength = 0;
            int findPoint = totalLength * point / 100;

            foreach (Edge edge in EdgeList)
            {
                if (findLength <= findPoint && findLength + edge.Length >= findPoint)
                {
                    findEdge = edge;
                    break;
                }
                else
                    findLength += edge.Length;
            }

            findLength = findPoint - findLength; // 최종 길이


            int xLocation = findEdge.StartPoint.X + ((findEdge.EndPoint.X - findEdge.StartPoint.X) * findLength / findEdge.Length);
            int yLocation = findEdge.StartPoint.Y + ((findEdge.EndPoint.Y - findEdge.StartPoint.Y) * findLength / findEdge.Length);
            double sLocation = findEdge.StartPoint.Scale + (findEdge.EndPoint.Scale - findEdge.StartPoint.Scale) * findLength / findEdge.Length;

            Vertex location = new Vertex(xLocation, yLocation, sLocation);
            return location;
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
                    pictureBox.Image = Bitmap.FromFile(@"C:\xmlTest\" + imageSource);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Image File이 존재하지 않습니다.");
                    pictureBox.Image = Resources.GRailBasic;
                    imageSource = "";
                }
            }
        }

        public int Point
        {
            get
            {
                return point;
            }

            set
            {
                if (value < 0)
                    value = 0;
                else if (value > 100)
                    value = 100;
                point = value;
                Vertex loc = PointToLocation();
                this.Location = new System.Drawing.Point(loc.X, loc.Y);
            }
        }

        public int TotalLength
        {
            get
            {
                return totalLength;
            }
        }
    }
}
