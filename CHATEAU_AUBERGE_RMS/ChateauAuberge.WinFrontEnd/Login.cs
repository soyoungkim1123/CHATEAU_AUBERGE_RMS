using ChateauAuberge.Service;
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
    public partial class Login : Form
    {
        internal ClerkDTO clerk;
        public Login()
        {
            InitializeComponent();
            clerk = new ClerkDTO();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtPassword.Text.Trim() == string.Empty || txtUserName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter a valid input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    LoginService service = new LoginService();
                    clerk = service.GetClerkInfo(txtUserName.Text.Trim(), txtPassword.Text.Trim());

                    if (clerk != null)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Login failed. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
