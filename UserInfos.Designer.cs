namespace DVLD_project
{
    partial class UserInfos
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usrPersonInfos1 = new DVLD_project.usrPersonInfos();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7IsActive = new System.Windows.Forms.Label();
            this.label7UserName = new System.Windows.Forms.Label();
            this.label7UserID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // usrPersonInfos1
            // 
            this.usrPersonInfos1.Location = new System.Drawing.Point(3, 3);
            this.usrPersonInfos1.Name = "usrPersonInfos1";
            this.usrPersonInfos1.Size = new System.Drawing.Size(851, 368);
            this.usrPersonInfos1.TabIndex = 0;
            this.usrPersonInfos1.Load += new System.EventHandler(this.usrPersonInfos1_Load);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7IsActive);
            this.groupBox1.Controls.Add(this.label7UserName);
            this.groupBox1.Controls.Add(this.label7UserID);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 377);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(851, 108);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login Information";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label7IsActive
            // 
            this.label7IsActive.AutoSize = true;
            this.label7IsActive.Location = new System.Drawing.Point(720, 51);
            this.label7IsActive.Name = "label7IsActive";
            this.label7IsActive.Size = new System.Drawing.Size(34, 25);
            this.label7IsActive.TabIndex = 15;
            this.label7IsActive.Text = "??";
            // 
            // label7UserName
            // 
            this.label7UserName.AutoSize = true;
            this.label7UserName.Location = new System.Drawing.Point(423, 51);
            this.label7UserName.Name = "label7UserName";
            this.label7UserName.Size = new System.Drawing.Size(34, 25);
            this.label7UserName.TabIndex = 14;
            this.label7UserName.Text = "??";
            // 
            // label7UserID
            // 
            this.label7UserID.AutoSize = true;
            this.label7UserID.Location = new System.Drawing.Point(174, 51);
            this.label7UserID.Name = "label7UserID";
            this.label7UserID.Size = new System.Drawing.Size(34, 25);
            this.label7UserID.TabIndex = 13;
            this.label7UserID.Text = "??";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(627, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 29);
            this.label6.TabIndex = 12;
            this.label6.Text = "IsActive :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(317, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 29);
            this.label5.TabIndex = 11;
            this.label5.Text = "UserName :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(80, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 29);
            this.label4.TabIndex = 10;
            this.label4.Text = "UserID :";
            // 
            // UserInfos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.usrPersonInfos1);
            this.Name = "UserInfos";
            this.Size = new System.Drawing.Size(858, 493);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private usrPersonInfos usrPersonInfos1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7IsActive;
        private System.Windows.Forms.Label label7UserName;
        private System.Windows.Forms.Label label7UserID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}
