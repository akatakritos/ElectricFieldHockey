namespace ElectricFieldHockey
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.pointCharge2 = new ElectricFieldHockey.PointCharge();
            this.puck1 = new ElectricFieldHockey.Puck();
            this.pointCharge1 = new ElectricFieldHockey.PointCharge();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pointCharge2
            // 
            this.pointCharge2.BackColor = System.Drawing.Color.Transparent;
            this.pointCharge2.Center = new System.Drawing.Point(142, 228);
            this.pointCharge2.Location = new System.Drawing.Point(130, 216);
            this.pointCharge2.Name = "pointCharge2";
            this.pointCharge2.Sign = ElectricFieldHockey.ChargeSign.Negative;
            this.pointCharge2.Size = new System.Drawing.Size(25, 25);
            this.pointCharge2.TabIndex = 3;
            this.pointCharge2.Text = "pointCharge2";
            // 
            // puck1
            // 
            this.puck1.BackColor = System.Drawing.Color.Transparent;
            this.puck1.Center = new System.Drawing.Point(352, 355);
            this.puck1.Location = new System.Drawing.Point(341, 344);
            this.puck1.Name = "puck1";
            this.puck1.Size = new System.Drawing.Size(25, 25);
            this.puck1.TabIndex = 1;
            this.puck1.Text = "puck1";
            // 
            // pointCharge1
            // 
            this.pointCharge1.BackColor = System.Drawing.Color.Transparent;
            this.pointCharge1.Center = new System.Drawing.Point(337, 122);
            this.pointCharge1.Location = new System.Drawing.Point(325, 110);
            this.pointCharge1.Name = "pointCharge1";
            this.pointCharge1.Sign = ElectricFieldHockey.ChargeSign.Negative;
            this.pointCharge1.Size = new System.Drawing.Size(25, 25);
            this.pointCharge1.TabIndex = 0;
            this.pointCharge1.Text = "pointCharge1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 575);
            this.Controls.Add(this.pointCharge2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.puck1);
            this.Controls.Add(this.pointCharge1);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(Form1_KeyDown);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }



        #endregion

        private PointCharge pointCharge1;
        private System.Windows.Forms.Timer timer1;
        private Puck puck1;
        private System.Windows.Forms.Button button1;
        private PointCharge pointCharge2;
    }
}

