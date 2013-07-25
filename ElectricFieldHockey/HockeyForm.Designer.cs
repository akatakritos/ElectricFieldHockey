using Physics;
namespace ElectricFieldHockey
{
    partial class HockeyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HockeyForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddPositive = new System.Windows.Forms.ToolStripButton();
            this.btnAddNegative = new System.Windows.Forms.ToolStripButton();
            this.btnGo = new System.Windows.Forms.ToolStripButton();
            this.btnOpenLevel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSaveGame = new System.Windows.Forms.ToolStripButton();
            this.btnOpenGame = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.puck1 = new Physics.Puck();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddPositive,
            this.btnAddNegative,
            this.btnGo,
            this.btnOpenLevel,
            this.toolStripSeparator1,
            this.btnSaveGame,
            this.btnOpenGame,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.btnHelp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(790, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddPositive
            // 
            this.btnAddPositive.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPositive.Image")));
            this.btnAddPositive.ImageTransparentColor = System.Drawing.Color.White;
            this.btnAddPositive.Name = "btnAddPositive";
            this.btnAddPositive.Size = new System.Drawing.Size(47, 22);
            this.btnAddPositive.Text = "(20)";
            this.btnAddPositive.ToolTipText = "Add a Positive Charge";
            this.btnAddPositive.Click += new System.EventHandler(this.btnAddPositive_Click);
            // 
            // btnAddNegative
            // 
            this.btnAddNegative.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNegative.Image")));
            this.btnAddNegative.ImageTransparentColor = System.Drawing.Color.White;
            this.btnAddNegative.Name = "btnAddNegative";
            this.btnAddNegative.Size = new System.Drawing.Size(47, 22);
            this.btnAddNegative.Text = "(20)";
            this.btnAddNegative.ToolTipText = "Add a Negative charge";
            this.btnAddNegative.Click += new System.EventHandler(this.btnAddNegative_Click);
            // 
            // btnGo
            // 
            this.btnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGo.Image = ((System.Drawing.Image)(resources.GetObject("btnGo.Image")));
            this.btnGo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(23, 22);
            this.btnGo.Text = "Go";
            this.btnGo.ToolTipText = "Start Simulation";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnOpenLevel
            // 
            this.btnOpenLevel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpenLevel.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenLevel.Image")));
            this.btnOpenLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenLevel.Name = "btnOpenLevel";
            this.btnOpenLevel.Size = new System.Drawing.Size(23, 22);
            this.btnOpenLevel.Text = "toolStripButton4";
            this.btnOpenLevel.ToolTipText = "Open a level";
            this.btnOpenLevel.Click += new System.EventHandler(this.btnOpenLevel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSaveGame
            // 
            this.btnSaveGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveGame.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveGame.Image")));
            this.btnSaveGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveGame.Name = "btnSaveGame";
            this.btnSaveGame.Size = new System.Drawing.Size(23, 22);
            this.btnSaveGame.Text = "Save game";
            this.btnSaveGame.Click += new System.EventHandler(this.btnSaveGame_Click);
            // 
            // btnOpenGame
            // 
            this.btnOpenGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpenGame.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenGame.Image")));
            this.btnOpenGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenGame.Name = "btnOpenGame";
            this.btnOpenGame.Size = new System.Drawing.Size(23, 22);
            this.btnOpenGame.Text = "Open saved game";
            this.btnOpenGame.Click += new System.EventHandler(this.btnOpenGame_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(62, 22);
            this.toolStripLabel1.Text = "Attempts: 0";
            // 
            // btnHelp
            // 
            this.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(23, 22);
            this.btnHelp.Text = "toolStripButton7";
            this.btnHelp.ToolTipText = "Help";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // puck1
            // 
            this.puck1.BackColor = System.Drawing.Color.Transparent;
            this.puck1.Center = ((System.Drawing.PointF)(resources.GetObject("puck1.Center")));
            this.puck1.Location = new System.Drawing.Point(344, 211);
            this.puck1.Moveable = false;
            this.puck1.Name = "puck1";
            this.puck1.Size = new System.Drawing.Size(25, 25);
            this.puck1.TabIndex = 2;
            this.puck1.Text = "puck1";
            // 
            // HockeyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(790, 467);
            this.Controls.Add(this.puck1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HockeyForm";
            this.Text = "Electric Field Hockey Beta";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.HockeyForm_Paint);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.HockeyForm_ControlRemoved);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddPositive;
        private System.Windows.Forms.ToolStripButton btnAddNegative;
        private System.Windows.Forms.ToolStripButton btnGo;
        private Puck puck1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton btnOpenLevel;
        private System.Windows.Forms.ToolStripButton btnSaveGame;
        private System.Windows.Forms.ToolStripButton btnOpenGame;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnHelp;
    }
}