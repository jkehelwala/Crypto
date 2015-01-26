namespace Crypto
{
    partial class ManageGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageGroup));
            this.pnlCtrl = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.lblGroupDesc = new System.Windows.Forms.Label();
            this.txtGrpName = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.pnlCtrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCtrl
            // 
            this.pnlCtrl.Controls.Add(this.btnEdit);
            this.pnlCtrl.Controls.Add(this.btnAdd);
            this.pnlCtrl.Location = new System.Drawing.Point(243, 71);
            this.pnlCtrl.Name = "pnlCtrl";
            this.pnlCtrl.Size = new System.Drawing.Size(71, 49);
            this.pnlCtrl.TabIndex = 10;
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::Crypto.Properties.Resources.edit;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(6, 7);
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
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Location = new System.Drawing.Point(11, 19);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(35, 13);
            this.lblGroupName.TabIndex = 11;
            this.lblGroupName.Text = "Name";
            // 
            // lblGroupDesc
            // 
            this.lblGroupDesc.AutoSize = true;
            this.lblGroupDesc.Location = new System.Drawing.Point(11, 48);
            this.lblGroupDesc.Name = "lblGroupDesc";
            this.lblGroupDesc.Size = new System.Drawing.Size(60, 13);
            this.lblGroupDesc.TabIndex = 12;
            this.lblGroupDesc.Text = "Description";
            // 
            // txtGrpName
            // 
            this.txtGrpName.Location = new System.Drawing.Point(52, 16);
            this.txtGrpName.MaxLength = 255;
            this.txtGrpName.Name = "txtGrpName";
            this.txtGrpName.Size = new System.Drawing.Size(262, 20);
            this.txtGrpName.TabIndex = 13;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(12, 71);
            this.txtDesc.MaxLength = 255;
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(225, 49);
            this.txtDesc.TabIndex = 14;
            // 
            // ManageGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(324, 142);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtGrpName);
            this.Controls.Add(this.lblGroupDesc);
            this.Controls.Add(this.lblGroupName);
            this.Controls.Add(this.pnlCtrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageGroup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Password Group";
            this.pnlCtrl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlCtrl;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.Label lblGroupDesc;
        private System.Windows.Forms.TextBox txtGrpName;
        private System.Windows.Forms.TextBox txtDesc;

    }
}