namespace DVLD_project
{
    partial class ScheduleTest
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
            this.ctrSchedultTesst1 = new DVLD_project.ctrSchedultTesst();
            this.SuspendLayout();
            // 
            // button1Close
            // 
            this.button1Close.BackColor = System.Drawing.Color.Red;
            this.button1Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1Close.Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1Close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1Close.Location = new System.Drawing.Point(710, 688);
            this.button1Close.Name = "button1Close";
            this.button1Close.Size = new System.Drawing.Size(124, 41);
            this.button1Close.TabIndex = 19;
            this.button1Close.Text = "Close";
            this.button1Close.UseVisualStyleBackColor = false;
            this.button1Close.Click += new System.EventHandler(this.button1Close_Click);
            // 
            // ctrSchedultTesst1
            // 
            this.ctrSchedultTesst1.Location = new System.Drawing.Point(12, 12);
            this.ctrSchedultTesst1.Name = "ctrSchedultTesst1";
            this.ctrSchedultTesst1.Size = new System.Drawing.Size(844, 679);
            this.ctrSchedultTesst1.TabIndex = 20;
            this.ctrSchedultTesst1.TestTypeID = DVLD_Business.clsTestTypes.eTestType.VisionTest;
            // 
            // ScheduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 741);
            this.Controls.Add(this.ctrSchedultTesst1);
            this.Controls.Add(this.button1Close);
            this.Name = "ScheduleTest";
            this.Text = "ScheduleTest";
            this.Load += new System.EventHandler(this.ScheduleVisionTest_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1Close;
        private ctrSchedultTesst ctrSchedultTesst1;
    }
}