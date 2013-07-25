using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Physics;

namespace ElectricFields
{
    public partial class Form1 : Form
    {
        List<PointCharge> pointCharges;
        public Form1()
        {
            InitializeComponent();
            pointCharges = new List<PointCharge>();
            pointCharges.Add(pointCharge1);
            pointCharges.Add(pointCharge2);
            pointCharge1.PointCharge_Resize(null, null);
            pointCharge2.PointCharge_Resize(null, null);
            pointCharge1.RecalcCenter();
            pointCharge2.RecalcCenter();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (bmp != null)
                e.Graphics.DrawImage(bmp, 0, 0);

            
        }

        Bitmap bmp;
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            Graphics g = Graphics.FromImage(bmp);
            foreach (PointCharge c in pointCharges)
            {
                for (double angle = 0; angle < 2 * Math.PI; angle += (2 * Math.PI) / 8)
                {
                    bool keepGoing = true;
                    PointF start = new Point(c.Location.X + c.Size.Width / 2 + (int)(16 * Math.Cos(angle)), c.Location.Y + c.Size.Height / 2 + (int)(16 * Math.Sin(angle)));
                    PointF stop;
                    while (keepGoing)
                    {
                        if (c.Sign == ChargeSign.Positive)
                        {
                            Vector force = Physics.Physics.CalcForce(start, 1.0, pointCharges);
                            stop = Physics.Physics.CalcPosition(start, force, .1);
                            g.DrawLine(Pens.Black, start, stop);
                            start = stop;

                            keepGoing = ClientRectangle.Contains((int)stop.X, (int)stop.Y);
                        }
                        else
                        {
                            //Vector force = Physics.Physics.CalcForce(start, -1.0, pointCharges);
                            //stop = Physics.Physics.CalcPosition(start, force, .5);
                            //g.DrawLine(Pens.Black, start, stop);
                            //start = stop;


                            //keepGoing = ClientRectangle.Contains((int)stop.X, (int)stop.Y);
                            keepGoing = false;
                        }
                    }
                }
            }

            this.Invalidate();
        }
    }
}