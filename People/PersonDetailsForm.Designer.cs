namespace DVLD_project
{
    partial class PersonDetailsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.usrPersonInfos1 = new DVLD_project.usrPersonInfos();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell Condensed", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(306, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "Person Details";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(763, 600);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(139, 46);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // usrPersonInfos1
            // 
            this.usrPersonInfos1.Location = new System.Drawing.Point(12, 173);
            this.usrPersonInfos1.Name = "usrPersonInfos1";
            this.usrPersonInfos1.Size = new System.Drawing.Size(890, 389);
            this.usrPersonInfos1.TabIndex = 0;
            this.usrPersonInfos1.Load += new System.EventHandler(this.usrPersonInfos1_Load);
            // 
            // PersonDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 658);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usrPersonInfos1);
            this.Name = "PersonDetailsForm";
            this.Text = "PersonDetailsForm";
            this.Load += new System.EventHandler(this.PersonDetailsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private usrPersonInfos usrPersonInfos1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
    }
}