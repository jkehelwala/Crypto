namespace Crypto
{
    partial class ManagePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagePassword));
            this.pnlCtrl = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblPassName = new System.Windows.Forms.Label();
            this.lblWebsite = new System.Windows.Forms.Label();
            this.lblUname = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPwrd = new System.Windows.Forms.Label();
            this.chkConfidential = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSite = new System.Windows.Forms.TextBox();
            this.txtUname = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPwrd = new System.Windows.Forms.TextBox();
            this.pnlCtrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCtrl
            // 
            this.pnlCtrl.Controls.Add(this.btnEdit);
            this.pnlCtrl.Controls.Add(this.btnAdd);
            this.pnlCtrl.Location = new System.Drawing.Point(297, 125);
            this.pnlCtrl.Name = "pnlCtrl";
            this.pnlCtrl.Size = new System.Drawing.Size(71, 49);
            this.pnlCtrl.TabIndex = 9;
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::Crypto.Properties.Resources.edit;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(7, 7);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Padding = new System.Windows.Forms.Padding(5);
            this.btnEdit.Size = new System.Drawing.Size(58, 35);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Crypto.Properties.Resources.tinyadd;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(7, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(5);
            this.btnAdd.Size = new System.Drawing.Size(58, 35);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblPassName
            // 
            this.lblPassName.AutoSize = true;
            this.lblPassName.Location = new System.Drawing.Point(13, 19);
            this.lblPassName.Name = "lblPassName";
            this.lblPassName.Size = new System.Drawing.Size(47, 13);
            this.lblPassName.TabIndex = 10;
            this.lblPassName.Text = "Identifier";
            // 
            // lblWebsite
            // 
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.Location = new System.Drawing.Point(13, 48);
            this.lblWebsite.Name = "lblWebsite";
            this.lblWebsite.Size = new System.Drawing.Size(46, 13);
            this.lblWebsite.TabIndex = 11;
            this.lblWebsite.Text = "Website";
            // 
            // lblUname
            // 
            this.lblUname.AutoSize = true;
            this.lblUname.Location = new System.Drawing.Point(13, 75);
            this.lblUname.Name = "lblUname";
            this.lblUname.Size = new System.Drawing.Size(60, 13);
            this.lblUname.TabIndex = 12;
            this.lblUname.Text = "User Name";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(14, 101);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 14;
            this.lblEmail.Text = "Email";
            // 
            // lblPwrd
            // 
            this.lblPwrd.AutoSize = true;
            this.lblPwrd.Location = new System.Drawing.Point(13, 127);
            this.lblPwrd.Name = "lblPwrd";
            this.lblPwrd.Size = new System.Drawing.Size(53, 13);
            this.lblPwrd.TabIndex = 15;
            this.lblPwrd.Text = "Password";
            // 
            // chkConfidential
            // 
            this.chkConfidential.AutoSize = true;
            this.chkConfidential.Location = new System.Drawing.Point(90, 126);
            this.chkConfidential.Name = "chkConfidential";
            this.chkConfidential.Size = new System.Drawing.Size(81, 17);
            this.chkConfidential.TabIndex = 16;
            this.chkConfidential.Text = "Confidential";
            this.chkConfidential.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(90, 16);
            this.txtName.MaxLength = 255;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(278, 20);
            this.txtName.TabIndex = 17;
            // 
            // txtSite
            // 
            this.txtSite.Location = new System.Drawing.Point(90, 45);
            this.txtSite.MaxLength = 255;
            this.txtSite.Name = "txtSite";
            this.txtSite.Size = new System.Drawing.Size(278, 20);
            this.txtSite.TabIndex = 18;
            // 
            // txtUname
            // 
            this.txtUname.Location = new System.Drawing.Point(90, 72);
            this.txtUname.MaxLength = 255;
            this.txtUname.Name = "txtUname";
            this.txtUname.Size = new System.Drawing.Size(186, 20);
            this.txtUname.TabIndex = 19;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(90, 98);
            this.txtEmail.MaxLength = 255;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(278, 20);
            this.txtEmail.TabIndex = 20;
            // 
            // txtPwrd
            // 
            this.txtPwrd.Location = new System.Drawing.Point(35, 154);
            this.txtPwrd.MaxLength = 255;
            this.txtPwrd.Name = "txtPwrd";
            this.txtPwrd.Size = new System.Drawing.Size(241, 20);
            this.txtPwrd.TabIndex = 21;
            // 
            // ManagePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(384, 192);
            this.Controls.Add(this.txtPwrd);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtUname);
            this.Controls.Add(this.txtSite);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.chkConfidential);
            this.Controls.Add(this.lblPwrd);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblUname);
            this.Controls.Add(this.lblWebsite);
            this.Controls.Add(this.lblPassName);
            this.Controls.Add(this.pnlCtrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManagePassword";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Password";
            this.pnlCtrl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlCtrl;
        private System.Windows.Forms.Label lblPassName;
        private System.Windows.Forms.Label lblWebsite;
        private System.Windows.Forms.Label lblUname;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPwrd;
        private System.Windows.Forms.CheckBox chkConfidential;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSite;
        private System.Windows.Forms.TextBox txtUname;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPwrd;
    }
}