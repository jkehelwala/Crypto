using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Crypto
{
    public partial class Control : Form
    {
        bool notSafe;
        ItemLists getStack;
        List<Password> passList = new List<Password>();
        List<int> passIndex = new List<int>();
        List<PassGroup> groupList = new List<PassGroup>();
        List<string> groupNIndex = new List<string>();

        //Search through datagrid view
        private void searchFor(DataGridView grd, string str)
        {
            if (grd.Rows.Count > 0)
            {
                List<int> rem = new List<int>();
                foreach (DataGridViewRow row in grd.Rows)
                {
                    if (!row.Cells[1].Value.ToString().ToLower().Contains(str))
                        rem.Add(row.Index);
                }
                rem.Reverse();
                foreach (int rInd in rem)
                    grd.Rows.RemoveAt(rInd);
            }
        }

        //Password Initiation

        private void setPasswords()
        {
            dgvPass.Rows.Clear();            
            foreach (Password a in passList)
            {                 
                try
                {
                    passIndex.Add(a.PassId);
                    dgvPass.Rows.Add(new String[] { a.PassId.ToString(), a.PassName, a.PassWebSite });
                }
                catch (Exception ex)
                {
                    CustomMsgBox.Show("Password List Initiation", ex.Message, Msg.Information);
                }
            }
        }
    
        private void setPasswords(List<int> lst)
        {
            dgvPass.Rows.Clear();
            foreach (int inc in lst)
            {
                try
                {
                    int v = passIndex.BinarySearch(inc);
                    if(!notSafe || (notSafe && v >= 0) )
                    dgvPass.Rows.Add(new String[] { passList[v].PassId.ToString(), passList[v].PassName, passList[v].PassWebSite });
                }
                catch (Exception ex)
                {
                    CustomMsgBox.Show("Password List Retrieval", ex.Message , Msg.Information);
                }
            }
        }

        private void passwordRefresh()
        {
            txtPwrds.Clear();
            passList.Clear();
            passIndex.Clear();
            passList.AddRange(getStack.getPasswords());
            setPasswords();
        }

        //Password Group Initiation

        private void setPasswordGroups()
        {
            if (!notSafe)
                dgvGroups.Rows.Clear();
            cmbGroups.Items.Clear();
            foreach (PassGroup a in groupList)
            {
                try
                {
                    groupNIndex.Add(a.GroupName);
                    cmbGroups.Items.Add(a.GroupName);
                    if (!notSafe)
                        dgvGroups.Rows.Add(new String[] { a.GroupId.ToString() , a.GroupName });
                }
                catch (Exception ex)
                {
                    CustomMsgBox.Show("Group List Initiation", ex.Message, Msg.Information);
                }
            }
        }

        private void setPasswordGroups(bool notFromDb)
        {
            dgvGroups.Rows.Clear();
            cmbGroups.Items.Clear();
            foreach (PassGroup a in groupList)
            {
                dgvGroups.Rows.Add(new String[] { a.GroupId.ToString(), a.GroupName });
            }
        }

        private void setPasswordGroups(List<string> lst)
        {
            dgvGroups.Rows.Clear();
            foreach (string inc in lst)
            {
                try
                {
                    int v = groupNIndex.BinarySearch(inc);
                    dgvGroups.Rows.Add(new String[] { groupList[v].GroupId.ToString(), groupList[v].GroupName });
                }
                catch (Exception ex)
                {
                    CustomMsgBox.Show("Group List Retrieval", ex.Message, Msg.Information);
                }
            }
        }

        private void passgroupRefresh()
        {
            txtGroups.Clear();
            lblDesc.ResetText();
            groupList.Clear();
            groupNIndex.Clear();
            cmbGroups.Items.Clear();
            groupList.AddRange(getStack.getGroups());
            setPasswordGroups();

            btnResetInc.Enabled = false;
            btnResetNotInc.Enabled = true;

        }
 
        private void fillGroupDataGrids(int index)
        {
            List<int> notIncIndex = new List<int>();
            notIncIndex.AddRange(passIndex);
            try
            {
                lblDesc.Text = groupList[index].GroupDesc;  
                if (groupList[index].PassList.Count > 0)
                {
                    foreach (int inc in groupList[index].PassList)
                    {
                        notIncIndex.Remove(inc);
                        dgvIncPass.Rows.Add(new String[] { inc.ToString(), passList[passIndex.BinarySearch(inc)].PassName });
                    }
                }

                if(notIncIndex.Count > 0){
                    foreach (int nInc in notIncIndex)
                        dgvNotIncPass.Rows.Add(new String[] { nInc.ToString(), passList[passIndex.BinarySearch(nInc)].PassName });
                }
            }
            catch (Exception e)
            {
                CustomMsgBox.Show(e.Message, Msg.Exception);
            }
        }
        
        //Constructor
        public Control(bool notSf)
        {
            InitializeComponent();

            notSafe = notSf;
            safeProtocol();
            cmbChoice.SelectedIndex = 0;
            cmbSelection.SelectedIndex = 0;

            getStack = new ItemLists(notSafe);
            passList.AddRange(getStack.getPasswords());
            groupList.AddRange(getStack.getGroups());

            setPasswords();
            setPasswordGroups();

        }
        
        //Simple Functions

        private void safeProtocol()
        {
            lblPassword.Visible = !notSafe;
            lblEmail.Visible = !notSafe;
            lblUserName.Visible = !notSafe;
            lblWebSite.Visible = !notSafe;

            btnAdd.Visible = !notSafe;
            btnEdit.Visible = !notSafe;
            btnRemove.Visible = !notSafe;
            btnSettings.Visible = !notSafe;

            if (notSafe)
                tbCtrlDash.TabPages.Remove(tbGroups);
        }

        private void CopyToClip(string txt)
        {
            if (txt != "")
                System.Windows.Forms.Clipboard.SetText(txt);
            else
                CustomMsgBox.Show("Text Empty", Msg.Information);
        }

        private void setLabelValues(Password pw)
        {
            lblPassword.Text = pw.Passwrd;
            lblUserName.Text = pw.PassUserName;
            lblEmail.Text = pw.PassEmail;
            lblWebSite.Text = pw.PassWebSite;
        }

        private void setLabelValues()
        {
            lblPassword.Text = "";
            lblUserName.Text = "";
            lblEmail.Text = "";
            lblWebSite.Text = "";
        }


        /**** Events ****/

        //Override Default Form Close
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //Open Settings
        private void btnSettings_Click(object sender, EventArgs e)
        {
            new AccessManager(true).ShowDialog();
        }       

        //Group
        private void btnGAdd_Click(object sender, EventArgs e)
        {
            ItemLists.lastPassGroup = null;
            new ManageGroup().ShowDialog();
            if (ItemLists.lastPassGroup != null)
            {
                PassGroup added = ItemLists.lastPassGroup;
                groupNIndex.Add(added.GroupName);
                groupNIndex.Sort();
                groupList.Insert(groupNIndex.IndexOf(added.GroupName),added);
                cmbGroups.Items.Add(added.GroupName);
                setPasswordGroups(true);
            }
        }

        private void btnGEdit_Click(object sender, EventArgs e)
        {
            int ind = groupNIndex.BinarySearch(dgvGroups.SelectedRows[0].Cells[1].Value.ToString());
            new ManageGroup(groupList[ind]).ShowDialog();
            groupList[ind].refresh();
            dgvGroups.SelectedRows[0].Cells[1].Value = groupList[ind].GroupName;
            lblDesc.Text = groupList[ind].GroupDesc;
        }

        private void btnGDelete_Click(object sender, EventArgs e)
        {
            int ind = groupNIndex.BinarySearch(dgvGroups.SelectedRows[0].Cells[1].Value.ToString());
            bool del = groupList[ind].deletePassGroup();
            if (del)
            {
                groupNIndex.RemoveAt(ind);
                groupList.RemoveAt(ind);
                dgvGroups.Rows.RemoveAt(dgvGroups.SelectedRows[0].Index);
            }
        }

        //Passwords in groups 
        private void btnAddGrp_Click(object sender, EventArgs e)
        {
            try
            {
                int gInd = groupNIndex.BinarySearch(dgvGroups.SelectedRows[0].Cells[1].Value.ToString());
                List<int> pInd = new List<int>();

                foreach (DataGridViewRow rw in dgvNotIncPass.SelectedRows)
                    pInd.Add(Convert.ToInt32(rw.Cells[0].Value));

                bool success = groupList[gInd].addToGroup(pInd);

                if (success)
                    CustomMsgBox.Show("Passwords Added To Group", Msg.Success);
                else
                    CustomMsgBox.Show("Password Add Failed!", Msg.Error);
                dgvGroups_SelectionChanged(sender, e);
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show(ex.Message, Msg.Exception);
            }
        }

        private void btnRemGroup_Click(object sender, EventArgs e)
        {
            try
            {
                int gInd = groupNIndex.BinarySearch(dgvGroups.SelectedRows[0].Cells[1].Value.ToString());
                List<int> pInd = new List<int>();
                foreach (DataGridViewRow rw in dgvIncPass.SelectedRows)
                    pInd.Add(Convert.ToInt32(rw.Cells[0].Value));
                bool success = groupList[gInd].removeFromGroup(pInd);
                if (success)
                    CustomMsgBox.Show("Password Removed From Group", Msg.Success);
                else
                    CustomMsgBox.Show("Passwored Removal Failed!", Msg.Error);
                dgvGroups_SelectionChanged(sender, e);
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show(ex.Message, Msg.Exception);
            }
        }       

        //Password 

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ItemLists.lastPassword = null;
            new ManagePassword().ShowDialog();
            if (ItemLists.lastPassword != null)
            {
                Password added = ItemLists.lastPassword;
                passIndex.Add(added.PassId);
                passList.Add(added);
                dgvPass.Rows.Add(new String[] { added.PassId.ToString(), added.PassName, added.PassWebSite });
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int ind = passIndex.BinarySearch(Convert.ToInt32(dgvPass.SelectedRows[0].Cells[0].Value));
            new ManagePassword(passList[ind]).ShowDialog();
            passList[ind].refresh();

            dgvPass.SelectedRows[0].Cells[1].Value = passList[ind].PassName;
            dgvPass.SelectedRows[0].Cells[2].Value = passList[ind].PassWebSite;

            setLabelValues(passList[ind]);
        }
        
        private void btnRemove_Click(object sender, EventArgs e)
        {
            int pId = Convert.ToInt32(dgvPass.SelectedRows[0].Cells[0].Value);
            int ind = passIndex.BinarySearch(pId);
            bool del = passList[ind].deletePassword();
            if (del)
            {
                foreach (PassGroup grp in groupList)
                    grp.removeFromList(pId);

                passIndex.RemoveAt(ind);
                passList.RemoveAt(ind);
                dgvPass.Rows.RemoveAt(dgvPass.SelectedRows[0].Index);
            }
        }

        //Copy password Items

        private void btnCopy_Click(object sender, EventArgs e)
        {
            CopyToClip(lblPassword.Text);
        }

        private void btnCopyUName_Click(object sender, EventArgs e)
        {
            CopyToClip(lblUserName.Text);
        }

        private void btnCopyEmail_Click(object sender, EventArgs e)
        {
            CopyToClip(lblEmail.Text);
        }

        private void btnCopySite_Click(object sender, EventArgs e)
        {
            CopyToClip(lblWebSite.Text);
        }

        //Go to website
        private void btnGoToSite_Click(object sender, EventArgs e)
        {
            if (lblWebSite.Text != "")
            {
                try
                {
                    System.Diagnostics.Process.Start(lblWebSite.Text);
                }
                catch
                {
                    CustomMsgBox.Show("Invalid Site Link", Msg.Information);
                }
            }
        }        

     
        //Search Events

        private void btnSearchPwrds_Click(object sender, EventArgs e)
        {
            if (txtPwrds.Text != "")
                setPasswords(getStack.getPasswordIndex(cmbSelection.SelectedIndex, txtPwrds.Text));
            else
                btnRefreshPass.PerformClick();
        }

        private void btnSearchGroups_Click(object sender, EventArgs e)
        {
            string searchStr = txtGroups.Text;
            if (searchStr != "")
            {
                switch (cmbChoice.SelectedIndex)
                {
                    case 0:
                        setPasswordGroups(getStack.getGroupByName(searchStr));
                        break;
                    case 1:
                        btnResetInc.Enabled = true;
                        btnResetInc.PerformClick();
                        searchFor(dgvIncPass, searchStr);
                        break;
                    case 2:
                        btnResetNotInc.Enabled = true;
                        btnResetNotInc.PerformClick();
                        searchFor(dgvNotIncPass, searchStr);
                        break;
                    default:
                        break;
                }
            }
            else
                passgroupRefresh();            
        }

        //Refresh Events
        private void btnRefreshGroup_Click(object sender, EventArgs e)
        {
            passgroupRefresh();       
        }

        private void btnRefreshPass_Click(object sender, EventArgs e)
        {
            passwordRefresh(); 
        }

        //DataGridView Selection Change Events

        private void dgvIncPass_SelectionChanged(object sender, EventArgs e)
        {
            btnRemGroup.Enabled = dgvIncPass.SelectedRows.Count > 0;
        }

        private void dgvNotIncPass_SelectionChanged(object sender, EventArgs e)
        {
            btnAddGrp.Enabled = dgvNotIncPass.SelectedRows.Count > 0;
        }

        private void dgvGroups_SelectionChanged(object sender, EventArgs e)
        {
            dgvIncPass.Rows.Clear();
            dgvNotIncPass.Rows.Clear();
            bool status = dgvGroups.SelectedRows.Count > 0;
            btnGEdit.Enabled = status;
            btnGDelete.Enabled = status;

            if (status)
            {
                try
                {
                   string  vName = dgvGroups.SelectedRows[0].Cells[1].Value.ToString();
                   int  ind = groupNIndex.BinarySearch(vName);                
                   fillGroupDataGrids(ind);                   
                }
                catch (Exception ex)
                {
                    CustomMsgBox.Show("Group View", ex.Message, Msg.Information);
                    CopyToClip(ex.ToString());
                }
            }
        }

        private void dgvPass_SelectionChanged(object sender, EventArgs e)
        {
            bool status = dgvPass.SelectedRows.Count > 0;
            btnEdit.Enabled = status;
            btnRemove.Enabled = status;

            if (status)
            {
                try
                {
                    int passInd = Convert.ToInt32(dgvPass.SelectedRows[0].Cells[0].Value);
                    int ind = passIndex.BinarySearch(passInd);
                    setLabelValues(passList[ind]);
                }
                catch (Exception ex)
                {
                    CustomMsgBox.Show("Password View", ex.Message, Msg.Information);
                }
            }
            else
                setLabelValues();
        }

        //Combobox Change Events

        private void cmbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGroups.Text != "")
            {
                int ind = groupNIndex.BinarySearch(cmbGroups.Text);
                setPasswords(groupList[ind].PassList);
                
            }
        }

        private void btnResetInc_Click(object sender, EventArgs e)
        {
            dgvIncPass.Rows.Clear();
            int index = groupNIndex.BinarySearch(dgvGroups.SelectedRows[0].Cells[1].Value.ToString());

            if (groupList[index].PassList.Count > 0)
            {
                foreach (int inc in groupList[index].PassList)
                    dgvIncPass.Rows.Add(new String[] { inc.ToString(), passList[passIndex.BinarySearch(inc)].PassName });
            }            
        }

        private void btnResetNotInc_Click(object sender, EventArgs e)
        {
            dgvNotIncPass.Rows.Clear();
            int index = groupNIndex.BinarySearch(dgvGroups.SelectedRows[0].Cells[1].Value.ToString());
            List<int> notIncIndex = new List<int>();
            notIncIndex.AddRange(passIndex);

            if (groupList[index].PassList.Count > 0)
            {
                foreach (int inc in groupList[index].PassList)
                    notIncIndex.Remove(inc);
            }

            if (notIncIndex.Count > 0)
            {
                foreach (int nInc in notIncIndex)
                    dgvNotIncPass.Rows.Add(new String[] { nInc.ToString(), passList[passIndex.BinarySearch(nInc)].PassName });
            }


        }

        private void txtPwrds_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtPwrds.Text != "")
            {
                btnSearchPwrds.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtGroups_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtGroups.Text != "")
            {
                btnSearchGroups.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        
       
    }
}
