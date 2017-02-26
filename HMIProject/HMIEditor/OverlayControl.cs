using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMIProject
{
    public class OverlayControl : Control
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams CP = base.CreateParams;
                CP.ExStyle |= 0x20;
                return CP;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen pen = new Pen(Color.Red, 4f);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Rectangle rect = this.ClientRectangle;
            rect.Width -= 5;
            rect.Height -= 5;
            e.Graphics.DrawRectangle(pen, this.ClientRectangle);
        }
    }
}