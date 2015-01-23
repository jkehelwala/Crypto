using System;
using System.Windows.Forms;

namespace Crypto
{
    public partial class ManagePassword : Form
    {
        Password val;

        private void commonInitate(bool value)
        {
            btnAdd.Visible = !value;
            btnEdit.Visible = value;
        }

        private void editInitate()
        {
            this.Text = "Edit " + this.Text;
            txtName.Text = val.PassName;
            txtSite.Text = val.PassWebSite;
            txtEmail.Text = val.PassEmail;
            txtUname.Text = val.PassUserName;
            txtPwrd.Text = val.Passwrd;
            chkConfidential.Checked = val.Safe;
        }

        private void addInitiate()
        {
            this.Text = "Add " + this.Text;
        }

        public ManagePassword(Password pwrd)
        {
            InitializeComponent();
            commonInitate(true);
            val = pwrd;
            editInitate();
        }

        public ManagePassword()
        {
            InitializeComponent();
            commonInitate(false);
            addInitiate();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (validate())
            {
               Password compVal = new Password(val.PassId, txtName.Text, txtSite.Text, txtUname.Text, txtEmail.Text, txtPwrd.Text, chkConfidential.Checked);
               int success =  val.editPassword(compVal);
                if(success == 1)
                    CustomMsgBox.Show("Password Edited", Msg.Success);
                else if(success == 0)
                    CustomMsgBox.Show("Error in Editing Password", Msg.Error);
                else
                    CustomMsgBox.Show("Fields have not been changed. Edit request Ignored!", Msg.Information);
                this.Dispose();
            }
            else
                CustomMsgBox.Show("Required Fields are Empty", Msg.Error);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ItemLists.lastPassword = null;
            if (validate())
            {
                val = new Password(txtName.Text, txtSite.Text, txtUname.Text, txtEmail.Text, txtPwrd.Text, chkConfidential.Checked);
                ItemLists.lastPassword = val;
                this.Dispose();
            }
            else
                CustomMsgBox.Show("Required Fields are Empty", Msg.Error);
        }

        private bool validate()
        {
            if (txtName.Text != "" && txtPwrd.Text != "")
                return true;
            else
                return false;
        }

    }
}
