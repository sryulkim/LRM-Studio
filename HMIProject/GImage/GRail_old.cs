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
    public partial class GRail_old : UserControl
    {
        public List<Edge> EdgeList;
        public List<Vertex> VertexList;
        string imageSource;
        int point;
        int totalLength;
        int xMax;
        int yMax;
        public PictureBox pictureBox;
        public GRail_old()
        {
            EdgeList = new List<Edge>();
            VertexList = new List<Vertex>();
            imageSource = "";
            point = 0;
            totalLength = 0;
            InitializeComponent();
            this.Size = new Size(100, 100);
            xMax = 100;
            yMax = 100;
            pictureBox = new PictureBox();
            pictureBox.Image = Resources.GRailBasic;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(100, 100);
            this.Controls.Add(pictureBox);
        }
        public void setSize(int width, int height)
        {
            this.Size = new Size(width, height);
            pictureBox.Size = new Size(width, height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
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
            this.Size = new Size(xMax, yMax);
            Vertex vertex = new Vertex(x, y, scale);
            if (VertexList.Count != 0)
            {
                Edge edge = new Edge(VertexList.Last(), vertex);
                totalLength += edge.Length;
                EdgeList.Add(edge);
                pictureBox.Location = new System.Drawing.Point(VertexList.First().X, VertexList.First().Y);
            }
            else
            {
                pictureBox.Location = new System.Drawing.Point(vertex.X, vertex.Y);
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

            Vertex location = new Vertex(xLocation, yLocation,sLocation);
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
                try {
                    pictureBox.Image = Bitmap.FromFile(@"C:\xmlTest\" + imageSource);
                } catch(Exception e)
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
                pictureBox.Location = new System.Drawing.Point(loc.X, loc.Y);
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

    public class Edge
    {
        Vertex startPoint;
        Vertex endPoint;
        int length;

        internal Vertex StartPoint
        {
            get
            {
                return startPoint;
            }

            set
            {
                startPoint = value;
                length = (int)(Math.Sqrt(Math.Pow((double)startPoint.X - (double)endPoint.X, 2) + Math.Pow((double)startPoint.Y - (double)endPoint.Y, 2)));
            }
        }

        internal Vertex EndPoint
        {
            get
            {
                return endPoint;
            }

            set
            {
                endPoint = value;
                length = (int)(Math.Sqrt(Math.Pow((double)startPoint.X - (double)endPoint.X, 2) + Math.Pow((double)startPoint.Y - (double)endPoint.Y, 2)));
            }
        }

        public int Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
            }
        }

        public Edge(Vertex startPoint, Vertex endPoint)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            length = (int)(Math.Sqrt(Math.Pow((double)startPoint.X - (double)endPoint.X, 2) + Math.Pow((double)startPoint.Y - (double)endPoint.Y, 2)));
        }

    }

    public class Vertex
    {
        int x, y;
        double scale;

        public Vertex(int x, int y, double scale)
        {
            this.x = x;
            this.y = y;
            this.scale = scale;
        }

        public double Scale
        {
            get
            {
                return scale;
            }
            set
            {
                scale = value;
            }
        }

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }
    }


}
