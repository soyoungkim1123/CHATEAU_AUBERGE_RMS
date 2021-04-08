using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChateauAuberge.Model;

namespace ChateauAuberge.WinFrontEnd
{
    public partial class MainForm : Form
    {
        internal ClerkDTO clerk;

        public ToolStripStatusLabel StatusLabel1
        {
            get { return toolStripStatusLabel1; }
            set { toolStripStatusLabel1 = value; }
        }

        public ToolStripStatusLabel StatusLabel2
        {
            get { return toolStripStatusLabel2; }
            set { toolStripStatusLabel2 = value; }
        }

        public MainForm()
        {
            InitializeComponent();
            clerk = new ClerkDTO();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadUserData();

            foreach (Control control in this.Controls)
            {
                MdiClient client = control as MdiClient;
                if (!(client == null))
                {
                    client.BackColor = Color.Gainsboro;
                    break;
                }
            }
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            try
            {
                Form childForm = null;
                ToolStripMenuItem m = (ToolStripMenuItem)sender;

                switch (m.Tag)
                {
                    case "ViewReservation":
                        childForm = new frmViewReservation();
                        break;
                    case "CreateReservation":
                        childForm = new frmCreateReservation();
                        break;
                }

                if (childForm != null)
                {
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.GetType() == childForm.GetType())
                        {
                            f.Activate();
                            return;
                        }
                    }
                }

                childForm.MdiParent = this;
                childForm.Location = new Point(0, 0);
                panelCreateReservation.Visible = false;
                panelViewReservation.Visible = false;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void ShowNewFormByPanel(object sender, MouseEventArgs e)
        {
            try
            {
                Form childForm = null;
                Panel panel = (Panel)sender;

                switch (panel.Tag)
                {
                    case "ViewReservation":
                        childForm = new frmViewReservation();
                        break;
                    case "CreateReservation":
                        childForm = new frmCreateReservation();
                        break;
                }

                if (childForm != null)
                {
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.GetType() == childForm.GetType())
                        {
                            f.Activate();
                            return;
                        }
                    }
                }

                childForm.MdiParent = this;
                childForm.Location = new Point(0, 0);
                panelCreateReservation.Visible = false;
                panelViewReservation.Visible = false;
                childForm.Show();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void logOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadUserData();
        }


        private void LoadUserData()
        {
            Splash mySplash = new Splash();
            Login myLogin = new Login();

            if(toolStripStatusLabel1.Text == "")
            {
                mySplash.ShowDialog();

                if (mySplash.DialogResult != DialogResult.OK)
                {
                    this.Close();
                }

                else
                {
                    myLogin.ShowDialog();
                }

            }

            else
            {
                myLogin.ShowDialog();
            }

            if (myLogin.DialogResult == DialogResult.OK)
            {
                this.Show();
                clerk = myLogin.clerk;
                toolStripStatusLabel1.Text = $"Welcome, {clerk.FullName}.";
            }
            else
            {
                if(toolStripStatusLabel1.Text == "")
                {
                    this.Close();
                }
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUserData();
        }

        public void RefreshParent()
        {
            int openChildFormCount = Application.OpenForms.Cast<Form>().Count(openForm => openForm.IsMdiChild);
            if (openChildFormCount == 0)
            {
                panelCreateReservation.Visible = true;
                panelViewReservation.Visible = true;
                toolStripStatusLabel2.Text = "";
            }
        }
    }
}
