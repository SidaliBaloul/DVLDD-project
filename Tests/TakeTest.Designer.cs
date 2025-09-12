namespace DVLD_project
{
    partial class TakeTest
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
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.button2Save = new System.Windows.Forms.Button();
            this.button1Close = new System.Windows.Forms.Button();
            this.ctrscheduledtest1 = new DVLD_project.ctrscheduledtest();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Rockwell Condensed", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(130, 470);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 26);
            this.label14.TabIndex = 21;
            this.label14.Text = "Result :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Rockwell Condensed", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(130, 524);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 26);
            this.label15.TabIndex = 22;
            this.label15.Text = "Notes :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(224, 524);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(597, 70);
            this.textBox1.TabIndex = 23;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(224, 474);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(73, 24);
            this.radioButton1.TabIndex = 24;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Pass";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(343, 474);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(63, 24);
            this.radioButton2.TabIndex = 25;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Fail";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // button2Save
            // 
            this.button2Save.BackColor = System.Drawing.Color.Lime;
            this.button2Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2Save.Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2Save.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2Save.Location = new System.Drawing.Point(685, 600);
            this.button2Save.Name = "button2Save";
            this.button2Save.Size = new System.Drawing.Size(136, 43);
            this.button2Save.TabIndex = 26;
            this.button2Save.Text = "Save";
            this.button2Save.UseVisualStyleBackColor = false;
            this.button2Save.Click += new System.EventHandler(this.button2Save_Click);
            // 
            // button1Close
            // 
            this.button1Close.BackColor = System.Drawing.Color.Red;
            this.button1Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1Close.Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1Close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1Close.Location = new System.Drawing.Point(537, 600);
            this.button1Close.Name = "button1Close";
            this.button1Close.Size = new System.Drawing.Size(124, 43);
            this.button1Close.TabIndex = 21;
            this.button1Close.Text = "Close";
            this.button1Close.UseVisualStyleBackColor = false;
            this.button1Close.Click += new System.EventHandler(this.button1Close_Click);
            // 
            // ctrscheduledtest1
            // 
            this.ctrscheduledtest1.Location = new System.Drawing.Point(-2, 7);
            this.ctrscheduledtest1.Name = "ctrscheduledtest1";
            this.ctrscheduledtest1.Size = new System.Drawing.Size(823, 460);
            this.ctrscheduledtest1.TabIndex = 27;
            // 
            // TakeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 662);
            this.Controls.Add(this.ctrscheduledtest1);
            this.Controls.Add(this.button1Close);
            this.Controls.Add(this.button2Save);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Name = "TakeTest";
            this.Text = "TakeTest";
            this.Load += new System.EventHandler(this.TakeTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button button2Save;
        private System.Windows.Forms.Button button1Close;
        private ctrscheduledtest ctrscheduledtest1;
    }
}