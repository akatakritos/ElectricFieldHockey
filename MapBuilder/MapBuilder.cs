using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace MapBuilder
{
    public partial class MapBuilder : Form
    {
        public MapBuilder()
        {
            InitializeComponent();
        }

        private void MapBuilder_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = "xml";
            dlg.Filter = "XML Files | *.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                XmlTextWriter writer = new XmlTextWriter(dlg.FileName, Encoding.UTF8);
                writer.WriteStartDocument();
                writer.WriteStartElement("Map");
                writer.WriteElementString("Difficulty", "1");
                writer.WriteElementString("NumberCharges", textBox1.Text);
                writer.WriteStartElement("PuckLocation");
                writer.WriteElementString("x", puck1.Location.X.ToString());
                writer.WriteElementString("y", puck1.Location.Y.ToString());
                writer.WriteEndElement();
                writer.WriteStartElement("Obstacles");
                foreach (Control c in Controls)
                {
                    if (c is Button)
                    {
                        if (c != button1 && c != button2)
                        {
                            writer.WriteStartElement("Obstacle");
                            writer.WriteStartElement("Location");
                            writer.WriteElementString("x", c.Location.X.ToString());
                            writer.WriteElementString("y", c.Location.Y.ToString());
                            writer.WriteEndElement();
                            writer.WriteStartElement("Size");
                            writer.WriteElementString("Width", c.Width.ToString());
                            writer.WriteElementString("Height", c.Height.ToString());
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                        }
                    }
                }
                writer.WriteEndDocument();
                writer.Close();
            }
        }
    }
}