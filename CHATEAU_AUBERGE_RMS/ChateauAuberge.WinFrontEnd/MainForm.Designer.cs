namespace ChateauAuberge.WinFrontEnd
{
    partial class MainForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.rMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewReservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createReservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelCreateReservation = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panelViewReservation = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelCreateReservation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelViewReservation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rMSToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(913, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "MenuStrip";
            // 
            // rMSToolStripMenuItem
            // 
            this.rMSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewReservationToolStripMenuItem,
            this.createReservationToolStripMenuItem});
            this.rMSToolStripMenuItem.Name = "rMSToolStripMenuItem";
            this.rMSToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.rMSToolStripMenuItem.Text = "&RMS";
            // 
            // viewReservationToolStripMenuItem
            // 
            this.viewReservationToolStripMenuItem.Name = "viewReservationToolStripMenuItem";
            this.viewReservationToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.viewReservationToolStripMenuItem.Tag = "ViewReservation";
            this.viewReservationToolStripMenuItem.Text = "&View Reservation";
            this.viewReservationToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // createReservationToolStripMenuItem
            // 
            this.createReservationToolStripMenuItem.Name = "createReservationToolStripMenuItem";
            this.createReservationToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.createReservationToolStripMenuItem.Tag = "CreateReservation";
            this.createReservationToolStripMenuItem.Text = "&Create Reservation";
            this.createReservationToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.logOutToolStripMenuItem.Text = "&Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 633);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(913, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightPink;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(3, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 29);
            this.label2.TabIndex = 36;
            this.label2.Text = "Reservation";
            // 
            // panelCreateReservation
            // 
            this.panelCreateReservation.BackColor = System.Drawing.Color.LightPink;
            this.panelCreateReservation.Controls.Add(this.pictureBox2);
            this.panelCreateReservation.Controls.Add(this.label3);
            this.panelCreateReservation.Controls.Add(this.label2);
            this.panelCreateReservation.Location = new System.Drawing.Point(483, 227);
            this.panelCreateReservation.Name = "panelCreateReservation";
            this.panelCreateReservation.Size = new System.Drawing.Size(230, 118);
            this.panelCreateReservation.TabIndex = 41;
            this.panelCreateReservation.Tag = "CreateReservation";
            this.panelCreateReservation.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ShowNewFormByPanel);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ChateauAuberge.WinFrontEnd.Properties.Resources.createreservation;
            this.pictureBox2.Location = new System.Drawing.Point(155, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(72, 75);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 43;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightPink;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(3, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 29);
            this.label3.TabIndex = 41;
            this.label3.Text = "Create";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label11.Location = new System.Drawing.Point(3, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(152, 29);
            this.label11.TabIndex = 36;
            this.label11.Text = "Reservation";
            // 
            // panelViewReservation
            // 
            this.panelViewReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelViewReservation.Controls.Add(this.pictureBox1);
            this.panelViewReservation.Controls.Add(this.label1);
            this.panelViewReservation.Controls.Add(this.label11);
            this.panelViewReservation.Location = new System.Drawing.Point(199, 227);
            this.panelViewReservation.Name = "panelViewReservation";
            this.panelViewReservation.Size = new System.Drawing.Size(230, 118);
            this.panelViewReservation.TabIndex = 39;
            this.panelViewReservation.Tag = "ViewReservation";
            this.panelViewReservation.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ShowNewFormByPanel);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ChateauAuberge.WinFrontEnd.Properties.Resources.viewreservation;
            this.pictureBox1.Location = new System.Drawing.Point(155, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 29);
            this.label1.TabIndex = 41;
            this.label1.Text = "View";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(913, 655);
            this.Controls.Add(this.panelCreateReservation);
            this.Controls.Add(this.panelViewReservation);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip);
            this.HelpButton = true;
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservation Management System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelCreateReservation.ResumeLayout(false);
            this.panelCreateReservation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelViewReservation.ResumeLayout(false);
            this.panelViewReservation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem rMSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewReservationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createReservationToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelCreateReservation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panelViewReservation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}