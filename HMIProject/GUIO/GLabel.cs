using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace HMIProject
{
    public class GLabel : Label
    {


        public GLabel()
        {
            //Setting the initial condition.
            Angle = 0d;
            FontSize = 9;
            FontBold = 0;
            FontUnderline = 0;
            Text = "Label";

            Transparent = 0;

            FontColor = 0;
            BorderColor = Color.Black;
            BackColor = Color.LightGray;

            this.Size = new Size(105, 12);
        }

        private double Angle;
        public int angle
        {
            get
            {
                return (int)Angle;
            }
            set
            {
                Angle = value;
                this.Invalidate();
            }
        }

        int FontSize;
        public int font_size
        {
            get
            {
                return FontSize;
            }
            set
            {
                FontSize = value;
                Invalidate();
            }
        }

        FontStyle FontBold;
        public bool font_bold
        {
            get
            {
                if (FontBold == 0)
                    return false;
                else
                    return true; ;
            }
            set
            {
                if (!value)
                {
                    FontBold = 0;
                }
                else
                    FontBold = FontStyle.Bold;
                Invalidate();
            }
        }

        FontStyle FontUnderline;
        public bool font_underline
        {
            get
            {
                if (FontUnderline == 0)
                    return false;
                else
                    return true;
            }
            set
            {
                if (!value)
                {
                    FontUnderline = 0;
                }
                else
                    FontUnderline = FontStyle.Underline;
                Invalidate();
            }
        }

        int LabelColor;
        public int label_color
        {
            get
            {
                return LabelColor;
            }
            set
            {
                LabelColor = value;
                this.BackColor = Color.FromArgb((int)((uint)LabelColor & (uint)0xFFFFFF | (uint)Transparent));
                Invalidate();
            }
        }

        int FontColor;
        public int font_color
        {
            get
            {
                return FontColor;
            }
            set
            {
                FontColor = value;
                this.ForeColor = Color.FromArgb((int)((uint)FontColor & (uint)0xFFFFFF | (uint)0xFF000000));
                Invalidate();
            }
        }

        public uint Transparent;
        public bool transparent
        {
            get
            {
                if (Transparent != 0)
                    return false;
                else
                    return true;
            }
            set
            {
                if (value)
                {
                    this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                    Transparent = 0;
                }
                else
                {
                    this.SetStyle(ControlStyles.SupportsTransparentBackColor, false);
                    Transparent = 0xFF000000;
                }
                this.BackColor = Color.FromArgb((int)((uint)LabelColor & (uint)0xFFFFFF | (uint)Transparent));
                this.BorderColor = Color.FromArgb((int)((uint)BorderColor.ToArgb() & (uint)0xFFFFFF | (uint)Transparent));
                Invalidate();
            }
        }
        Color BorderColor;
        public int border_color
        {
            get
            {
                return (int)((uint)BorderColor.ToArgb() & (uint)0xFFFFFF);
            }
            set
            {
                BorderColor = Color.FromArgb((int)((uint)value & (uint)0xFFFFFF | (uint)Transparent));
                Invalidate();
            }
        }

        int Thickness;
        public int thickness
        {
            get
            {
                return Thickness;
            }
            set
            {
                Thickness = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            this.Font = new Font("Arial", font_size, FontBold | FontUnderline);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.Trimming = StringTrimming.None;

            Brush textBrush = new SolidBrush(this.ForeColor);

            //Getting the width and height of the text, which we are going to write
            float width = graphics.MeasureString(this.Text, this.Font).Width;
            float height = graphics.MeasureString(this.Text, this.Font).Height;

            //The radius is set to 0.9 of the width or height, b'cos not to
            //hide and part of the text at any stage
            float radius = 0f;
            if (ClientRectangle.Width < ClientRectangle.Height)
            {
                radius = ClientRectangle.Width * 0.9f / 2;
            }
            else
            {
                radius = ClientRectangle.Height * 0.9f / 2;
            }

            //Setting the text according to the selection

            //For rotation, who about rotation?
            double tangle = (Angle / 180) * Math.PI;
            graphics.TranslateTransform(
                            (ClientRectangle.Width + (float)(height * Math.Sin(tangle)) - (float)(width * Math.Cos(tangle))) / 2,
                            (ClientRectangle.Height - (float)(height * Math.Cos(tangle)) - (float)(width * Math.Sin(tangle))) / 2);
            graphics.RotateTransform((float)Angle);
            graphics.DrawString(this.Text, this.Font, textBrush, 0, 0);
            graphics.ResetTransform();

            int xy = 0;
            width = this.Size.Width;
            height = this.Size.Height;
            Pen pen = new Pen(BorderColor);
            for (int i = 0; i < Thickness; i++)
                graphics.DrawRectangle(pen, xy + i, xy + i, width - (i << 1) - 1, height - (i << 1) - 1);
        }
    }
}
