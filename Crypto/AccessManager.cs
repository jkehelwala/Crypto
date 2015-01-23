using System;
using System.Windows.Forms;

namespace Crypto
{
    public partial class AccessManager : Form
    {
        bool logged;
        UserSettings usettings;

        public void adjustVisibility()
        {
            txtQ1.ReadOnly = !logged;
            txtQ2.ReadOnly = !logged;
            txtQ1.TabStop = logged;
            txtQ2.TabStop = logged;
            
            btnBackup.Visible = logged;
            btnSecInfo.Visible = logged;
        }

        public AccessManager(bool log)
        {
            InitializeComponent();
            logged = log;
            adjustVisibility();
            usettings = new UserSettings();

            txtQ1.Text = usettings.SecQ1;
            txtQ2.Text = usettings.SecQ2;
        }

        private void btnSecInfo_Click(object sender, EventArgs e)
        {
            usettings.updateSecQuestions(txtQ1.Text, txtQ2.Text);
            usettings.updateSecAnswers(txtA1.Text, txtA2.Text);
            CustomMsgBox.Show("Security Information Updated", Msg.Success);
        }

        private void btnConf_Click(object sender, EventArgs e)
        {
            if (logged || usettings.validateAnswers(txtA1.Text, txtA2.Text))
                usettings.updatePassConfidential(txtConfNew.Text);           
            else
                CustomMsgBox.Show("Incorrect Security Information", Msg.Error);
        }       

        private void btnVuln_Click(object sender, EventArgs e)
        {
            if (logged || usettings.validateAnswers(txtA1.Text, txtA2.Text))
                usettings.updatePassVulnerable(txtVulnNew.Text);
            else
                CustomMsgBox.Show("Incorrect Security Information", Msg.Error);
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog backupFolder = new FolderBrowserDialog();
            backupFolder.Description = "Select folder";


            backupFolder.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            if (DialogResult.OK == backupFolder.ShowDialog())
            {
                new DbManagement().backupDatabase(backupFolder.SelectedPath);
            }
           
        }

    }
}
