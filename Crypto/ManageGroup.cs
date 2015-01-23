using System;
using System.Windows.Forms;

namespace Crypto
{
    public partial class ManageGroup : Form
    {
        PassGroup val;

        private void commonInitate(bool edit)
        {
            btnAdd.Visible = !edit;
            btnEdit.Visible = edit;
        }

        private void editInitate()
        {
            this.Text = "Edit " + this.Text;
            txtGrpName.Text = val.GroupName;
            txtDesc.Text = val.GroupDesc;
        }

        private void addInitiate()
        {
            this.Text = "Add " + this.Text;
        }

        public ManageGroup(PassGroup grp)
        {
            InitializeComponent();
            val = grp;
            commonInitate(true);
            editInitate();
        }

        public ManageGroup()
        {
            InitializeComponent();
            commonInitate(false);
            addInitiate();
        }


        private bool validate()
        {
            return txtGrpName.Text != "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ItemLists.lastPassGroup = null;
            if (validate())
            {
                val = new PassGroup(txtGrpName.Text, txtDesc.Text);
                ItemLists.lastPassGroup = val;
                this.Dispose();
            }
            else
                CustomMsgBox.Show("Required Fields are Empty", Msg.Error);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                PassGroup compVal = new PassGroup(val.GroupId, txtGrpName.Text, txtDesc.Text);
                int success = val.editPassGroup(compVal);
                if (success == 1)
                    CustomMsgBox.Show("Password Group Edited", Msg.Success);
                else if (success == 0)
                    CustomMsgBox.Show("Error in Editing Password Group", Msg.Error);
                else
                    CustomMsgBox.Show("Fields have not been changed. Edit request Ignored!", Msg.Information);
                this.Dispose();
            }
            else
                CustomMsgBox.Show("Required Fields are Empty", Msg.Error);
        }


    }
}
