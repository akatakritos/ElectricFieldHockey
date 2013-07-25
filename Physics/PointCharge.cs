using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Physics
{
    public class PointCharge : Control
    {
        ChargeSign mSign;
        bool mouseDown = false;
        int xOffset, yOffset;
        Rectangle toolBox;
        public PointCharge()
        {
            mSign = ChargeSign.Positive;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            this.BackColor = Color.Transparent;
            this.MouseEnter += new EventHandler(Puck_MouseEnter);
            this.MouseLeave += new EventHandler(Puck_MouseLeave);
            this.MouseDown += new MouseEventHandler(Puck_MouseDown);
            this.MouseMove += new MouseEventHandler(Puck_MouseMove);
            this.MouseUp += new MouseEventHandler(Puck_MouseUp);
        }

        void Puck_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            RecalcCenter();
        }

        public Rectangle ToolBox
        {
            set { toolBox = value; }
        }

        public void RecalcCenter()
        {
            if (this.Parent == null)
                return;
            Rectangle rect = this.ClientRectangle;
            rect.Width = rect.Width > rect.Height ? rect.Height : rect.Width;
            rect.Height = rect.Width;

            center.X = Left + rect.Width / 2;
            center.Y = Parent.Height - (Top + rect.Height / 2);
        }

        void Puck_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point currLoc = this.Location;
                this.Location = new Point(currLoc.X + e.X - xOffset, currLoc.Y + e.Y - yOffset);
            }
        }

        void Puck_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //if (mSign == ChargeSign.Negative)
                //    Sign = ChargeSign.Positive;
                //else
                //    Sign = ChargeSign.Negative;
                Parent.Controls.Remove(this);
            }
            else
            {
                mouseDown = true;
                xOffset = e.X;
                yOffset = e.Y;
            }
        }

        void Puck_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        void Puck_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.SizeAll;
        }

        public ChargeSign Sign
        {
            get { return mSign; }
            set { mSign = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.Transparent, this.ClientRectangle);
            
            Rectangle rect = this.ClientRectangle;
            rect.Width = rect.Height > rect.Width ? rect.Width : rect.Height;
            rect.Height = rect.Width;

            GraphicsPath pth = new GraphicsPath();
            pth.AddEllipse(rect);
            System.Drawing.Drawing2D.PathGradientBrush br = new PathGradientBrush(pth);
            br.CenterColor = Color.WhiteSmoke;            
            br.CenterPoint = new PointF(rect.Width / 4, rect.Width / 4);
            

            if (mSign == ChargeSign.Negative)
                br.SurroundColors = new Color[] { Color.Blue };
            else
                br.SurroundColors = new Color[] { Color.Red };

            g.FillEllipse(br, rect);
            br.Dispose();
           
            int length = rect.Height / 2;
            int width = rect.Width / 8;

            //g.FillEllipse(Brushes.WhiteSmoke, rect.Width / 6, rect.Height / 6, rect.Width / 6, rect.Height / 6);

            if (mSign == ChargeSign.Positive)
            {
                using (Pen p = new Pen(Color.Black, width))
                {
                    g.DrawLine(p, rect.Width / 2, rect.Width / 2 - length / 2, rect.Width / 2, rect.Width / 2 + length / 2);
                    g.DrawLine(p, rect.Width / 2 - length / 2, rect.Height / 2, rect.Width / 2 + length / 2, rect.Height / 2);
                }
            }
            else
            {
                using (Pen p = new Pen(Color.Black, Width / 7))
                {
                    g.DrawLine(p, rect.Width / 2 - length / 2, rect.Height / 2, rect.Width / 2 + length / 2, rect.Height / 2);
                }
            }

            
        }

        private Point center;
        public Point Center
        {
            get
            {
                return center;
            }

            set
            {
                if (this.Parent == null)
                    return;
                Rectangle rect = this.ClientRectangle;
                rect.Width = rect.Height > rect.Width ? rect.Width : rect.Height;
                rect.Height = rect.Width;
                center = value;

                this.Location = new Point(value.X - rect.Width / 2, Parent.Height - (value.Y + rect.Height / 2));
            }
        }

        public double Charge
        {
            get
            {
                if (mSign == ChargeSign.Negative)
                    return -1.0;
                else
                    return 1.0;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PointCharge
            // 
            this.Resize += new System.EventHandler(this.PointCharge_Resize);
            this.ResumeLayout(false);

        }
        public GraphicsPath Path;
        public void PointCharge_Resize(object sender, EventArgs e)
        {
            Path = new GraphicsPath();
            Rectangle rect = this.ClientRectangle;
            rect.Width = rect.Height > rect.Width ? rect.Width : rect.Height;
            rect.Height = rect.Width;
            Path.AddEllipse(rect);
            if (rect.Width > 0)
                this.Region = new Region(Path);            
        }

    }

    public enum ChargeSign
    {
        Positive,
        Negative
    }
}
