namespace DVLD_project
{
    partial class InternationalLicenseInfo
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
            this.button1Close = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrInternationalLicenseInfo1 = new DVLD_project.ctrInternationalLicenseInfo();
            this.SuspendLayout();
            // 
            // button1Close
            // 
            this.button1Close.BackColor = System.Drawing.Color.Red;
            this.button1Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1Close.Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1Close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1Close.Location = new System.Drawing.Point(943, 494);
            this.button1Close.Name = "button1Close";
            this.button1Close.Size = new System.Drawing.Size(124, 41);
            this.button1Close.TabIndex = 2;
            this.button1Close.Text = "Close";
            this.button1Close.UseVisualStyleBackColor = false;
            this.button1Close.Click += new System.EventHandler(this.button1Close_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell Condensed", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(201, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(612, 51);
            this.label4.TabIndex = 13;
            this.label4.Text = "Driver International License Info";
            // 
            // ctrInternationalLicenseInfo1
            // 
            this.ctrInternationalLicenseInfo1.Location = new System.Drawing.Point(12, 126);
            this.ctrInternationalLicenseInfo1.Name = "ctrInternationalLicenseInfo1";
            this.ctrInternationalLicenseInfo1.Size = new System.Drawing.Size(1052, 362);
            this.ctrInternationalLicenseInfo1.TabIndex = 0;
            this.ctrInternationalLicenseInfo1.Load += new System.EventHandler(this.ctrInternationalLicenseInfo1_Load);
            // 
            // InternationalLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 554);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1Close);
            this.Controls.Add(this.ctrInternationalLicenseInfo1);
            this.Name = "InternationalLicenseInfo";
            this.Text = "InternationalLicenseInfo";
            this.Load += new System.EventHandler(this.InternationalLicenseInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrInternationalLicenseInfo ctrInternationalLicenseInfo1;
        private System.Windows.Forms.Button button1Close;
        private System.Windows.Forms.Label label4;
    }
}