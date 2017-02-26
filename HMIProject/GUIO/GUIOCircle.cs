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
    public partial class GUIOCircle : UserControl
    {
        Pen pen;
        SolidBrush brush;
        private int fillColorNumber = 0x000000;
        private int lineColorNumber = 0xFFFFFF;
        Color fillColor;
        Color lineColor;
        private int lineThickness;

        public void setLineThickness(int lt)
        {
            this.lineThickness = lt;
            pen.Width = lt;
            this.Refresh();
        }

        public void setFillColor(int cn)
        {
            this.fillColorNumber = cn;
            fillColor = Color.FromArgb(fillColorNumber);
            fillColor = Color.FromArgb(0xFF, fillColor.R, fillColor.G, fillColor.B);
            this.Refresh();
        }

        public void setBorderColor(int cn)
        {
            this.lineColorNumber = cn;
            lineColor = Color.FromArgb(lineColorNumber);
            lineColor = Color.FromArgb(0xFF, lineColor.R, lineColor.G, lineColor.B);
            this.Refresh();
        }


        public GUIOCircle()
        {
            this.fillColorNumber = 0xFFFFFF;
            this.lineColorNumber = 0x000000;
            fillColor = Color.FromArgb(fillColorNumber);
            fillColor = Color.FromArgb(0xFF, fillColor.R, fillColor.G, fillColor.B);
            lineColor = Color.FromArgb(lineColorNumber);
            lineColor = Color.FromArgb(0xFF, lineColor.R, lineColor.G, lineColor.B);
            pen = new Pen(lineColor);
            brush = new SolidBrush(fillColor);

            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            pen.Color = lineColor;
            brush.Color = fillColor;
            e.Graphics.FillEllipse(brush, 0, 0, this.Width, this.Height);
            e.Graphics.DrawEllipse(pen, pen.Width / 2, pen.Width / 2, this.Width - pen.Width, this.Height - pen.Width);
        }
    }
}
