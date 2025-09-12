namespace DVLD_project
{
    partial class LicenseHistory
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
            this.button1 = new System.Windows.Forms.Button();
            this.ctrPersoninfoWithzfilter1 = new DVLD_project.ctrPersoninfoWithzfilter();
            this.ctrLicensesHistory1 = new DVLD_project.ctrLicensesHistory();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(907, 507);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 44);
            this.button1.TabIndex = 19;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctrPersoninfoWithzfilter1
            // 
            this.ctrPersoninfoWithzfilter1.filterenabled = false;
            this.ctrPersoninfoWithzfilter1.Location = new System.Drawing.Point(35, 12);
            this.ctrPersoninfoWithzfilter1.Name = "ctrPersoninfoWithzfilter1";
            this.ctrPersoninfoWithzfilter1.showaddperson = true;
            this.ctrPersoninfoWithzfilter1.Size = new System.Drawing.Size(866, 519);
            this.ctrPersoninfoWithzfilter1.TabIndex = 20;
            this.ctrPersoninfoWithzfilter1.OnPersonselected += new System.Action<int>(this.ctrPersoninfoWithzfilter1_OnPersonselected);
            // 
            // ctrLicensesHistory1
            // 
            this.ctrLicensesHistory1.Location = new System.Drawing.Point(12, 557);
            this.ctrLicensesHistory1.Name = "ctrLicensesHistory1";
            this.ctrLicensesHistory1.Size = new System.Drawing.Size(1019, 320);
            this.ctrLicensesHistory1.TabIndex = 21;
            // 
            // LicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 889);
            this.Controls.Add(this.ctrLicensesHistory1);
            this.Controls.Add(this.ctrPersoninfoWithzfilter1);
            this.Controls.Add(this.button1);
            this.Name = "LicenseHistory";
            this.Text = "LicenseHistory";
            this.Load += new System.EventHandler(this.LicenseHistory_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private ctrPersoninfoWithzfilter ctrPersoninfoWithzfilter1;
        private ctrLicensesHistory ctrLicensesHistory1;
    }
}