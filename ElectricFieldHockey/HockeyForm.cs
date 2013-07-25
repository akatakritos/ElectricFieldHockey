using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Drawing.Drawing2D;
using Physics;
using System.IO;

namespace ElectricFieldHockey
{
    public partial class HockeyForm : Form
    {
        List<PointCharge> pointCharges;
        List<Rectangle> obstacles;
        int positives = 20, negatives = 20;
        Rectangle target;
        string filename = "Practice";
        int tries = 0;
        public HockeyForm()
        {
            InitializeComponent();
            pointCharges = new List<PointCharge>();
            obstacles = new List<Rectangle>();
            //loadXmlLevel(@"C:\Projects\ElectricFieldHockey\ElectricFieldHockey\bin\Debug\Level2.xml");
            target = new Rectangle(new Point(713, 172), new Size(57, 139));
            puck1.RecalcCenter();
            puck1.Puck_Resize(null, null);
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.Text = "Electric Field Hockey Beta - Practice";
            puck1.Moveable = true;
        }

        public HockeyForm(string arg)
        {
            InitializeComponent();
            pointCharges = new List<PointCharge>();
            obstacles = new List<Rectangle>();
            //loadXmlLevel(@"C:\Projects\ElectricFieldHockey\ElectricFieldHockey\bin\Debug\Level2.xml");
            target = new Rectangle(new Point(713, 172), new Size(57, 139));
            puck1.RecalcCenter();
            puck1.Puck_Resize(null, null);
            loadSavedGame(arg);
        }

        private void loadXmlLevel(string p)
        {
            tries = 0;
            toolStripLabel1.Text = "Attempts: 0";
            obstacles.Clear();
            XmlTextReader reader = new XmlTextReader(p);
            reader.Read();
            reader.Read();
            reader.ReadStartElement("Map");
            int diff = int.Parse(reader.ReadElementString("Difficulty"));
            positives = negatives = int.Parse(reader.ReadElementString("NumberCharges"));
            btnAddPositive.Text = "(" + positives + ")";
            btnAddNegative.Text = "(" + negatives + ")";
            
            reader.ReadStartElement("PuckLocation");
            int x = int.Parse(reader.ReadElementString("x"));
            int y = int.Parse(reader.ReadElementString("y"));
            puck1.Location = new Point(x, y);
            puck1.RecalcCenter();
            reader.ReadEndElement();

            //reader.ReadStartElement("Obstacles");
            while (reader.Read())
            {
                if (reader.Name == "Obstacle" && reader.NodeType == XmlNodeType.Element)
                {
                    reader.Read();
                    reader.ReadStartElement("Location");
                    x = int.Parse(reader.ReadElementString("x"));
                    y = int.Parse(reader.ReadElementString("y"));
                    reader.ReadEndElement();

                    reader.ReadStartElement("Size");
                    int width = int.Parse(reader.ReadElementString("Width"));
                    int height = int.Parse(reader.ReadElementString("Height"));
                    obstacles.Add(new Rectangle(x, y, width, height));
                }
            }
            filename = p;
            this.Text = "Electric Field Hockey Beta - " + Path.GetFileName(p);
            this.Invalidate();
            puck1.Moveable = false;
        }

        bool won = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (won)
                return;
            Vector force = Physics.Physics.CalcForce(puck1, pointCharges);

            PointF loc = puck1.Center;
            PointF center = Physics.Physics.CalcPosition(loc, puck1.Velocity, force*10, timer1.Interval / 1000.0);
            puck1.Velocity = Physics.Physics.CalcVelocity(puck1.Velocity, force*10, timer1.Interval / 1000.0);
            puck1.Center = center;

            if (checkWin(puck1))
            {
                
                timer1.Enabled = false;
                puck1.Center = startPoint;
                puck1.RecalcCenter();
                MessageBox.Show("Congrats! You've won!\n And it only took you " + tries.ToString() + " tries!" );
                btnGo.Enabled = true;
                
            }
            if (crashed(puck1))
            {
                timer1.Enabled = false;
                puck1.Center = startPoint;
                puck1.RecalcCenter();
                //MessageBox.Show("Crashed!");
                btnGo.Enabled = true;
            }
          
        }

        private bool checkWin(Puck puck1)
        {
            return puck1.Bounds.IntersectsWith(target);
        }

        private bool crashed(Puck puck1)
        {
            if (puck1.Left <= 0)
                return true;
            if (puck1.Top <= 25)
                return true;
            if (puck1.Bottom >= ClientRectangle.Height)
                return true;
            if (puck1.Right >= ClientRectangle.Width)
                return true;

            for (int i = 0; i < obstacles.Count; i++)
            {
                for(int j = 0; j < puck1.PathPoints.Length; j++)
                {
                    if (obstacles[i].Contains(puck1.Location.X + (int)puck1.PathPoints[j].X, puck1.Location.Y + (int)puck1.PathPoints[j].Y))
                        return true;                    
                }
            }

            for (int i = 0; i < pointCharges.Count; i++)
            {
                float dx = pointCharges[i].Center.X - puck1.Center.X;
                float dy = pointCharges[i].Center.Y - puck1.Center.Y;
                double r = Math.Sqrt(dx * dx + dy * dy);

                if (r < 25)
                    return true;
            }

            return false;
        }

        PointF startPoint;
        private void btnGo_Click(object sender, EventArgs e)
        {
            puck1.Reset();
            won = false;
            timer1.Enabled = true;
            startPoint = puck1.Center;
            tries++;
            toolStripLabel1.Text = "Attempts: " + tries;
            btnGo.Enabled = false;
        }

        private void btnAddPositive_Click(object sender, EventArgs e)
        {
            if (positives > 0)
            {
                PointCharge p = new PointCharge();
                this.Controls.Add(p);
                p.Sign = ChargeSign.Positive;
                p.Size = new Size(25, 25);
                p.Center = new Point(50, this.Height - 75);
                p.PointCharge_Resize(null, null);
                positives--;
                btnAddPositive.Text = "(" + positives.ToString() + ")";
                pointCharges.Add(p);
            }
        }

        private void btnAddNegative_Click(object sender, EventArgs e)
        {
            if (negatives > 0)
            {
                PointCharge p = new PointCharge();
                this.Controls.Add(p);
                p.Sign = ChargeSign.Negative;
                p.Size = new Size(25, 25);
                p.PointCharge_Resize(null, null);
                p.Center = new Point(50, this.Height - 75);
                negatives--;
                btnAddNegative.Text = "(" + negatives.ToString() + ")";
                pointCharges.Add(p);
            }
        }

        private void HockeyForm_Paint(object sender, PaintEventArgs e)
        {
            foreach (Rectangle rect in obstacles)
            {
                e.Graphics.FillRectangle(Brushes.Black, rect);
            }

            e.Graphics.FillRectangle(Brushes.Green, target);
        }

        private void btnOpenLevel_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "XML Files | *.xml";
            dlg.InitialDirectory = Application.StartupPath;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < Controls.Count; i++)
                {
                    if (Controls[i] is PointCharge)
                    {
                        Controls.RemoveAt(i);
                        i--;
                    }
                }
                loadXmlLevel(dlg.FileName);
            }
            dlg.Dispose();
        }

        private void HockeyForm_ControlRemoved(object sender, ControlEventArgs e)
        {
            PointCharge p = e.Control as PointCharge;

            if (p != null)
            {
                if (pointCharges.Contains(p))
                    pointCharges.Remove(p);

                if (p.Sign == ChargeSign.Positive)
                {
                    positives++;
                    btnAddPositive.Text = string.Format("({0})", positives);
                }
                else
                {
                    negatives++;
                    btnAddNegative.Text = string.Format("({0})", negatives);
                }
            }
        }

        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = ".efh";
            dlg.Filter = "Saved Games | *.efh";
            dlg.InitialDirectory = Application.StartupPath;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                XmlTextWriter xmlout = new XmlTextWriter(dlg.FileName, Encoding.UTF8);
                xmlout.WriteStartDocument();
                xmlout.WriteStartElement("SavedGame");
                xmlout.WriteElementString("Map", filename);
                xmlout.WriteElementString("Attempts", tries.ToString());
                xmlout.WriteStartElement("PointCharges");                
                foreach (PointCharge c in pointCharges)
                {
                    xmlout.WriteStartElement("PointCharge");
                    xmlout.WriteElementString("Charge", ((int)c.Sign).ToString());
                    xmlout.WriteStartElement("Location");
                    xmlout.WriteElementString("x", c.Location.X.ToString());
                    xmlout.WriteElementString("y", c.Location.Y.ToString());
                    xmlout.WriteEndElement();
                    xmlout.WriteEndElement();
                }

                xmlout.WriteEndDocument();
                xmlout.Close();
            }
            dlg.Dispose();
        }

        private void btnOpenGame_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Saved Games | *.efh";
            dlg.InitialDirectory = Application.StartupPath;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < Controls.Count; i++)
                {
                    if (Controls[i] is PointCharge)
                    {
                        Controls.RemoveAt(i);
                        i--;
                    }
                }

                loadSavedGame(dlg.FileName);
            }
            dlg.Dispose();
        }

        private void loadSavedGame(string file)
        {
            XmlTextReader xmlin = new XmlTextReader(file);
            xmlin.Read();
            xmlin.Read();
            xmlin.ReadStartElement("SavedGame");
            string s = xmlin.ReadElementString("Map");
            if (s != "Practice")
                loadXmlLevel(s);
            //xmlin.Read();
            //if (xmlin.Name == "Attempts" && xmlin.NodeType == XmlNodeType.Element)
            //    {
            tries = int.Parse(xmlin.ReadElementString("Attempts"));
            toolStripLabel1.Text = "Attempts: " + tries;
            //}

            while (xmlin.Read())
            {

                if (xmlin.Name == "PointCharge" && xmlin.NodeType == XmlNodeType.Element)
                {
                    xmlin.Read();
                    string charge = xmlin.ReadElementString("Charge");
                    xmlin.ReadStartElement("Location");
                    int x = int.Parse(xmlin.ReadElementString("x"));
                    int y = int.Parse(xmlin.ReadElementString("y"));
                    xmlin.ReadEndElement();

                    PointCharge pc = new PointCharge();
                    pc.Sign = (ChargeSign)(int.Parse(charge));
                    if (pc.Sign == ChargeSign.Positive)
                    {
                        positives--;
                        btnAddPositive.Text = String.Format("({0})", positives);
                    }
                    else
                    {
                        negatives--;
                        btnAddNegative.Text = string.Format("({0})", negatives);
                    }
                    this.Controls.Add(pc);
                    pc.Location = new Point(x, y);
                    pointCharges.Add(pc);
                    pc.Size = new Size(25, 25);
                    pc.RecalcCenter();
                    pc.PointCharge_Resize(null, null);
                }
            }
            xmlin.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpForm f = new HelpForm();
            f.ShowDialog();
            f.Dispose();
        }
    }
}