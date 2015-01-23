using System;
using System.Windows.Forms;

namespace Crypto
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (new UserSettings().checkPass(txtPass.Text, !chkVisible.Checked))
            {
                this.Hide();
                new Control(chkVisible.Checked).ShowDialog();
            }
            else
                CustomMsgBox.Show("Your password is incorrect!", Msg.Error);
        }

        private void btnForgot_Click(object sender, EventArgs e)
        {
            new AccessManager(false).ShowDialog();
        }

    }
}
