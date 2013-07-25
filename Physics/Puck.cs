using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Physics
{
    public class Puck : Control
    {
        bool mouseDown = false, mMoveable =false;
        int xOffset, yOffset;
        private Vector mVelocity;
        public Puck()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            //this.MouseEnter += new EventHandler(Puck_MouseEnter);
            //this.MouseLeave += new EventHandler(Puck_MouseLeave);
            //this.MouseDown += new MouseEventHandler(Puck_MouseDown);
            //this.MouseMove += new MouseEventHandler(Puck_MouseMove);
            //this.MouseUp += new MouseEventHandler(Puck_MouseUp);
            mVelocity = new Vector(0, 0);
            this.Puck_Resize(null, null);
        }

        void Puck_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            RecalcCenter();
        }

        public void RecalcCenter()
        {
            Rectangle rect = this.ClientRectangle;
            rect.Width = rect.Width > rect.Height ? rect.Height : rect.Width;
            rect.Height = rect.Width;

            center.X = Left + rect.Width / 2;
            center.Y = ((Parent.Height - (Top + rect.Height / 2)));
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
            mouseDown = true;
            xOffset = e.X;
            yOffset = e.Y;
        }

        void Puck_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        void Puck_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.SizeAll;
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
            using (PathGradientBrush br = new PathGradientBrush(pth))
            {
                br.CenterColor = Color.WhiteSmoke;
                br.CenterPoint = new PointF(rect.Width / 4, rect.Width / 4);

                br.SurroundColors = new Color[] { Color.Black };

                g.FillEllipse(br, rect);
            }
        }

        private PointF center;
        public PointF Center
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

                this.Location = new Point((int)(value.X - rect.Width / 2), (int)(Parent.Height - (value.Y  + rect.Height / 2)));
            }
        }

        public Vector Velocity
        {
            get { return mVelocity; }
            set { mVelocity = value; }
        }

        public double Charge
        {
            get { return 1.0; }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Puck
            // 
            this.Resize += new System.EventHandler(this.Puck_Resize);
            this.SizeChanged += new System.EventHandler(this.Puck_Resize);
            this.ResumeLayout(false);

        }

        public GraphicsPath Path;
        public PointF[] PathPoints;

        public void Puck_Resize(object sender, EventArgs e)
        {
            Path = new GraphicsPath();
            Rectangle rect = this.ClientRectangle;
            rect.Width = rect.Height > rect.Width ? rect.Width : rect.Height;
            rect.Height = rect.Width;
            Path.AddEllipse(rect);
            PathPoints = Path.PathPoints;
            if (rect.Width > 0)
                this.Region = new Region(Path);
        }

        public void Reset()
        {
            this.Velocity = new Vector(0, 0);
            RecalcCenter();
        }

        public bool Moveable
        {
            get { return mMoveable; }
            set
            {
                mMoveable = value;
                if (mMoveable)
                {
                    this.MouseEnter += new EventHandler(Puck_MouseEnter);
                    this.MouseLeave += new EventHandler(Puck_MouseLeave);
                    this.MouseDown += new MouseEventHandler(Puck_MouseDown);
                    this.MouseMove += new MouseEventHandler(Puck_MouseMove);
                    this.MouseUp += new MouseEventHandler(Puck_MouseUp);
                }
                else
                {
                    this.MouseEnter -= new EventHandler(Puck_MouseEnter);
                    this.MouseLeave -= new EventHandler(Puck_MouseLeave);
                    this.MouseDown -= new MouseEventHandler(Puck_MouseDown);
                    this.MouseMove -= new MouseEventHandler(Puck_MouseMove);
                    this.MouseUp -= new MouseEventHandler(Puck_MouseUp);
                }
            }
        }
    }
}
