namespace DVLD_project
{
    partial class IssueDrivingLicense
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
            this.button2Save = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrApplicationInfos1 = new DVLD_project.ctrApplicationInfos();
            this.SuspendLayout();
            // 
            // button1Close
            // 
            this.button1Close.BackColor = System.Drawing.Color.Red;
            this.button1Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1Close.Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1Close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1Close.Location = new System.Drawing.Point(596, 649);
            this.button1Close.Name = "button1Close";
            this.button1Close.Size = new System.Drawing.Size(124, 43);
            this.button1Close.TabIndex = 27;
            this.button1Close.Text = "Close";
            this.button1Close.UseVisualStyleBackColor = false;
            this.button1Close.Click += new System.EventHandler(this.button1Close_Click);
            // 
            // button2Save
            // 
            this.button2Save.BackColor = System.Drawing.Color.Lime;
            this.button2Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2Save.Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2Save.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2Save.Location = new System.Drawing.Point(726, 649);
            this.button2Save.Name = "button2Save";
            this.button2Save.Size = new System.Drawing.Size(136, 43);
            this.button2Save.TabIndex = 30;
            this.button2Save.Text = "Issue";
            this.button2Save.UseVisualStyleBackColor = false;
            this.button2Save.Click += new System.EventHandler(this.button2Save_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(188, 559);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(674, 84);
            this.textBox1.TabIndex = 29;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(92, 559);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 29);
            this.label15.TabIndex = 28;
            this.label15.Text = "Notes :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell Condensed", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(222, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(403, 51);
            this.label4.TabIndex = 31;
            this.label4.Text = "Issue Driving License";
            // 
            // ctrApplicationInfos1
            // 
            //this.ctrApplicationInfos1.ApplicantPerson = "????";
            this.ctrApplicationInfos1.Location = new System.Drawing.Point(12, 79);
            this.ctrApplicationInfos1.Name = "ctrApplicationInfos1";
            //this.ctrApplicationInfos1.PersonID = 0;
            this.ctrApplicationInfos1.Size = new System.Drawing.Size(850, 449);
            this.ctrApplicationInfos1.TabIndex = 0;
            // 
            // IssueDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 704);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1Close);
            this.Controls.Add(this.button2Save);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.ctrApplicationInfos1);
            this.Name = "IssueDrivingLicense";
            this.Text = "IssueDrivingLicense";
            this.Load += new System.EventHandler(this.IssueDrivingLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrApplicationInfos ctrApplicationInfos1;
        private System.Windows.Forms.Button button1Close;
        private System.Windows.Forms.Button button2Save;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label4;
    }
}