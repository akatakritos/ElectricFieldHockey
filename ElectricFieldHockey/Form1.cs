using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ElectricFieldHockey
{
    public partial class Form1 : Form
    {
        List<PointCharge> pointCharges;
        public Form1()
        {
            InitializeComponent();
            pointCharges = new List<PointCharge>();
            //this.Controls.Remove(pointCharge2);
            pointCharges.AddRange(new PointCharge[] { pointCharge1, pointCharge2 });
            pointCharges[0].Center = new Point(100, 100);
            pointCharges[1].Center = new Point(300, 150);
            puck1.Center = new Point(200, 200);
            pointCharge1.Sign = ChargeSign.Negative;
            pointCharge2.Sign = ChargeSign.Negative;
            pointCharge1.SendToBack();
            pointCharge2.SendToBack();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Vector force = Physics.CalcForce(puck1, pointCharges);

            PointF loc = puck1.Center;
            PointF center = Physics.CalcPosition(loc, puck1.Velocity, force*10, timer1.Interval / 1000.0);
            puck1.Velocity = Physics.CalcVelocity(puck1.Velocity, force*10, timer1.Interval / 1000.0);
            puck1.Center = center;

            if (crashed(puck1))
            {
                timer1.Enabled = false;
                puck1.Center = startPoint;
                MessageBox.Show("Crashed!");
                
            }
          
        }

        private bool crashed(Puck puck1)
        {
            if (puck1.Left <= 0)
                return true;
            if (puck1.Top <= 0)
                return true;
            if (puck1.Bottom >= ClientRectangle.Height)
                return true;
            if (puck1.Right >= ClientRectangle.Width)
                return true;

            //for (int i = 0; i < pointCharges.Count; i++)
            //{
            //    if (puck1.Bounds.IntersectsWith(pointCharges[i].Bounds))
            //        return true;
                
            //}

            return false;
        }

        PointF startPoint;
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            startPoint = puck1.Center;
        }

        void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add)
            {
                PointCharge p = new PointCharge();                
                p.Size = new Size(25, 25);
                p.Sign = ChargeSign.Positive; 
                p.Center = new Point(13, 13);
                Controls.Add(p);
                pointCharges.Add(p);
            }
        }
    }
}