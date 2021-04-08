using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChateauAuberge.WinFrontEnd
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            lbProductName.Text = Application.ProductName;
            lbVersion.Text = Application.ProductVersion;
            lbCompanyName.Text = Application.CompanyName;

            lbProductName.BackColor = Color.Transparent;
            lbVersion.BackColor = Color.Transparent;
            lbCompanyName.BackColor = Color.Transparent;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
