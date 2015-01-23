namespace Crypto
{
    partial class AccessManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccessManager));
            this.txtQ1 = new System.Windows.Forms.TextBox();
            this.lbltxtA1 = new System.Windows.Forms.Label();
            this.txtA1 = new System.Windows.Forms.TextBox();
            this.txtA2 = new System.Windows.Forms.TextBox();
            this.lbltxtA2 = new System.Windows.Forms.Label();
            this.txtQ2 = new System.Windows.Forms.TextBox();
            this.gbxConf = new System.Windows.Forms.GroupBox();
            this.txtConfNew = new System.Windows.Forms.TextBox();
            this.lbltxtConfNew = new System.Windows.Forms.Label();
            this.gbvVuln = new System.Windows.Forms.GroupBox();
            this.txtVulnNew = new System.Windows.Forms.TextBox();
            this.lbltxtVulnNew = new System.Windows.Forms.Label();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnSecInfo = new System.Windows.Forms.Button();
            this.btnVuln = new System.Windows.Forms.Button();
            this.lblVuln = new System.Windows.Forms.Label();
            this.btnConf = new System.Windows.Forms.Button();
            this.lblConf = new System.Windows.Forms.Label();
            this.lbltxtQ2 = new System.Windows.Forms.Label();
            this.lbltxtQ1 = new System.Windows.Forms.Label();
            this.gbxConf.SuspendLayout();
            this.gbvVuln.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtQ1
            // 
            this.txtQ1.Location = new System.Drawing.Point(84, 27);
            this.txtQ1.Name = "txtQ1";
            this.txtQ1.Size = new System.Drawing.Size(277, 20);
            this.txtQ1.TabIndex = 1;
            // 
            // lbltxtA1
            // 
            this.lbltxtA1.AutoSize = true;
            this.lbltxtA1.Location = new System.Drawing.Point(57, 59);
            this.lbltxtA1.Name = "lbltxtA1";
            this.lbltxtA1.Size = new System.Drawing.Size(42, 13);
            this.lbltxtA1.TabIndex = 2;
            this.lbltxtA1.Text = "Answer";
            // 
            // txtA1
            // 
            this.txtA1.Location = new System.Drawing.Point(105, 56);
            this.txtA1.Name = "txtA1";
            this.txtA1.Size = new System.Drawing.Size(219, 20);
            this.txtA1.TabIndex = 2;
            // 
            // txtA2
            // 
            this.txtA2.Location = new System.Drawing.Point(105, 128);
            this.txtA2.Name = "txtA2";
            this.txtA2.Size = new System.Drawing.Size(219, 20);
            this.txtA2.TabIndex = 5;
            // 
            // lbltxtA2
            // 
            this.lbltxtA2.AutoSize = true;
            this.lbltxtA2.Location = new System.Drawing.Point(57, 131);
            this.lbltxtA2.Name = "lbltxtA2";
            this.lbltxtA2.Size = new System.Drawing.Size(42, 13);
            this.lbltxtA2.TabIndex = 6;
            this.lbltxtA2.Text = "Answer";
            // 
            // txtQ2
            // 
            this.txtQ2.Location = new System.Drawing.Point(84, 96);
            this.txtQ2.Name = "txtQ2";
            this.txtQ2.Size = new System.Drawing.Size(277, 20);
            this.txtQ2.TabIndex = 4;
            // 
            // gbxConf
            // 
            this.gbxConf.Controls.Add(this.btnConf);
            this.gbxConf.Controls.Add(this.txtConfNew);
            this.gbxConf.Controls.Add(this.lbltxtConfNew);
            this.gbxConf.Controls.Add(this.lblConf);
            this.gbxConf.Location = new System.Drawing.Point(12, 173);
            this.gbxConf.Name = "gbxConf";
            this.gbxConf.Size = new System.Drawing.Size(214, 101);
            this.gbxConf.TabIndex = 7;
            this.gbxConf.TabStop = false;
            this.gbxConf.Text = " Confidential Password ";
            // 
            // txtConfNew
            // 
            this.txtConfNew.Location = new System.Drawing.Point(24, 55);
            this.txtConfNew.Name = "txtConfNew";
            this.txtConfNew.Size = new System.Drawing.Size(102, 20);
            this.txtConfNew.TabIndex = 10;
            // 
            // lbltxtConfNew
            // 
            this.lbltxtConfNew.AutoSize = true;
            this.lbltxtConfNew.Location = new System.Drawing.Point(10, 33);
            this.lbltxtConfNew.Name = "lbltxtConfNew";
            this.lbltxtConfNew.Size = new System.Drawing.Size(106, 13);
            this.lbltxtConfNew.TabIndex = 11;
            this.lbltxtConfNew.Text = "Enter New Password";
            // 
            // gbvVuln
            // 
            this.gbvVuln.Controls.Add(this.btnVuln);
            this.gbvVuln.Controls.Add(this.txtVulnNew);
            this.gbvVuln.Controls.Add(this.lbltxtVulnNew);
            this.gbvVuln.Controls.Add(this.lblVuln);
            this.gbvVuln.Location = new System.Drawing.Point(238, 173);
            this.gbvVuln.Name = "gbvVuln";
            this.gbvVuln.Size = new System.Drawing.Size(214, 101);
            this.gbvVuln.TabIndex = 12;
            this.gbvVuln.TabStop = false;
            this.gbvVuln.Text = "Vulnerable Password ";
            // 
            // txtVulnNew
            // 
            this.txtVulnNew.Location = new System.Drawing.Point(21, 59);
            this.txtVulnNew.Name = "txtVulnNew";
            this.txtVulnNew.Size = new System.Drawing.Size(102, 20);
            this.txtVulnNew.TabIndex = 15;
            // 
            // lbltxtVulnNew
            // 
            this.lbltxtVulnNew.AutoSize = true;
            this.lbltxtVulnNew.Location = new System.Drawing.Point(6, 33);
            this.lbltxtVulnNew.Name = "lbltxtVulnNew";
            this.lbltxtVulnNew.Size = new System.Drawing.Size(106, 13);
            this.lbltxtVulnNew.TabIndex = 15;
            this.lbltxtVulnNew.Text = "Enter New Password";
            // 
            // btnBackup
            // 
            this.btnBackup.Image = global::Crypto.Properties.Resources.backup;
            this.btnBackup.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBackup.Location = new System.Drawing.Point(399, 3);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnBackup.Size = new System.Drawing.Size(71, 51);
            this.btnBackup.TabIndex = 13;
            this.btnBackup.Text = "Backup Database";
            this.btnBackup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnSecInfo
            // 
            this.btnSecInfo.Image = global::Crypto.Properties.Resources.edit;
            this.btnSecInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSecInfo.Location = new System.Drawing.Point(356, 128);
            this.btnSecInfo.Name = "btnSecInfo";
            this.btnSecInfo.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSecInfo.Size = new System.Drawing.Size(71, 34);
            this.btnSecInfo.TabIndex = 6;
            this.btnSecInfo.Text = "Update";
            this.btnSecInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSecInfo.UseVisualStyleBackColor = true;
            this.btnSecInfo.Click += new System.EventHandler(this.btnSecInfo_Click);
            // 
            // btnVuln
            // 
            this.btnVuln.Image = global::Crypto.Properties.Resources.edit;
            this.btnVuln.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVuln.Location = new System.Drawing.Point(137, 40);
            this.btnVuln.Name = "btnVuln";
            this.btnVuln.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnVuln.Size = new System.Drawing.Size(70, 35);
            this.btnVuln.TabIndex = 16;
            this.btnVuln.Text = "Update";
            this.btnVuln.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVuln.UseVisualStyleBackColor = true;
            this.btnVuln.Click += new System.EventHandler(this.btnVuln_Click);
            // 
            // lblVuln
            // 
            this.lblVuln.AutoSize = true;
            this.lblVuln.Image = global::Crypto.Properties.Resources.visible;
            this.lblVuln.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVuln.Location = new System.Drawing.Point(180, -2);
            this.lblVuln.MinimumSize = new System.Drawing.Size(22, 22);
            this.lblVuln.Name = "lblVuln";
            this.lblVuln.Size = new System.Drawing.Size(22, 22);
            this.lblVuln.TabIndex = 9;
            this.lblVuln.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnConf
            // 
            this.btnConf.Image = global::Crypto.Properties.Resources.edit;
            this.btnConf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConf.Location = new System.Drawing.Point(137, 40);
            this.btnConf.Name = "btnConf";
            this.btnConf.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnConf.Size = new System.Drawing.Size(70, 35);
            this.btnConf.TabIndex = 11;
            this.btnConf.Text = "Update";
            this.btnConf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConf.UseVisualStyleBackColor = true;
            this.btnConf.Click += new System.EventHandler(this.btnConf_Click);
            // 
            // lblConf
            // 
            this.lblConf.AutoSize = true;
            this.lblConf.Image = global::Crypto.Properties.Resources.lockimg;
            this.lblConf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblConf.Location = new System.Drawing.Point(180, -1);
            this.lblConf.MinimumSize = new System.Drawing.Size(22, 22);
            this.lblConf.Name = "lblConf";
            this.lblConf.Size = new System.Drawing.Size(22, 22);
            this.lblConf.TabIndex = 9;
            this.lblConf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbltxtQ2
            // 
            this.lbltxtQ2.AutoSize = true;
            this.lbltxtQ2.Image = global::Crypto.Properties.Resources.question;
            this.lbltxtQ2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbltxtQ2.Location = new System.Drawing.Point(22, 95);
            this.lbltxtQ2.MinimumSize = new System.Drawing.Size(45, 20);
            this.lbltxtQ2.Name = "lbltxtQ2";
            this.lbltxtQ2.Size = new System.Drawing.Size(45, 20);
            this.lbltxtQ2.TabIndex = 4;
            this.lbltxtQ2.Text = "Q2";
            this.lbltxtQ2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbltxtQ1
            // 
            this.lbltxtQ1.AutoSize = true;
            this.lbltxtQ1.Image = global::Crypto.Properties.Resources.question;
            this.lbltxtQ1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbltxtQ1.Location = new System.Drawing.Point(22, 26);
            this.lbltxtQ1.MinimumSize = new System.Drawing.Size(45, 20);
            this.lbltxtQ1.Name = "lbltxtQ1";
            this.lbltxtQ1.Size = new System.Drawing.Size(45, 20);
            this.lbltxtQ1.TabIndex = 0;
            this.lbltxtQ1.Text = "Q1";
            this.lbltxtQ1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AccessManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(471, 290);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnSecInfo);
            this.Controls.Add(this.gbvVuln);
            this.Controls.Add(this.gbxConf);
            this.Controls.Add(this.txtA2);
            this.Controls.Add(this.lbltxtA2);
            this.Controls.Add(this.txtQ2);
            this.Controls.Add(this.lbltxtQ2);
            this.Controls.Add(this.txtA1);
            this.Controls.Add(this.lbltxtA1);
            this.Controls.Add(this.txtQ1);
            this.Controls.Add(this.lbltxtQ1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccessManager";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Access Manager";
            this.TopMost = true;
            this.gbxConf.ResumeLayout(false);
            this.gbxConf.PerformLayout();
            this.gbvVuln.ResumeLayout(false);
            this.gbvVuln.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltxtQ1;
        private System.Windows.Forms.TextBox txtQ1;
        private System.Windows.Forms.Label lbltxtA1;
        private System.Windows.Forms.TextBox txtA1;
        private System.Windows.Forms.TextBox txtA2;
        private System.Windows.Forms.Label lbltxtA2;
        private System.Windows.Forms.TextBox txtQ2;
        private System.Windows.Forms.Label lbltxtQ2;
        private System.Windows.Forms.Label lblConf;
        private System.Windows.Forms.GroupBox gbxConf;
        private System.Windows.Forms.Button btnConf;
        private System.Windows.Forms.TextBox txtConfNew;
        private System.Windows.Forms.Label lbltxtConfNew;
        private System.Windows.Forms.GroupBox gbvVuln;
        private System.Windows.Forms.Button btnVuln;
        private System.Windows.Forms.TextBox txtVulnNew;
        private System.Windows.Forms.Label lbltxtVulnNew;
        private System.Windows.Forms.Label lblVuln;
        private System.Windows.Forms.Button btnSecInfo;
        private System.Windows.Forms.Button btnBackup;
    }
}