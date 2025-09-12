namespace DVLD_project
{
    partial class AddUpdateForm
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
            this.components = new System.ComponentModel.Container();
            this.button1Close = new System.Windows.Forms.Button();
            this.label1Title = new System.Windows.Forms.Label();
            this.button2Save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3PersonIDvalue = new System.Windows.Forms.Label();
            this.linkLabelRemove = new System.Windows.Forms.LinkLabel();
            this.linkLabelSetImage = new System.Windows.Forms.LinkLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxNationalNo = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxThirdName = new System.Windows.Forms.TextBox();
            this.textBoxSecondName = new System.Windows.Forms.TextBox();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1Close
            // 
            this.button1Close.BackColor = System.Drawing.Color.Red;
            this.button1Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1Close.Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1Close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1Close.Location = new System.Drawing.Point(12, 140);
            this.button1Close.Name = "button1Close";
            this.button1Close.Size = new System.Drawing.Size(124, 41);
            this.button1Close.TabIndex = 1;
            this.button1Close.Text = "Close";
            this.button1Close.UseVisualStyleBackColor = false;
            this.button1Close.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1Title
            // 
            this.label1Title.AutoSize = true;
            this.label1Title.Font = new System.Drawing.Font("Rockwell Condensed", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1Title.ForeColor = System.Drawing.Color.Red;
            this.label1Title.Location = new System.Drawing.Point(435, 38);
            this.label1Title.Name = "label1Title";
            this.label1Title.Size = new System.Drawing.Size(127, 51);
            this.label1Title.TabIndex = 2;
            this.label1Title.Text = "label1";
            this.label1Title.Click += new System.EventHandler(this.label1_Click);
            // 
            // button2Save
            // 
            this.button2Save.BackColor = System.Drawing.Color.Lime;
            this.button2Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2Save.Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2Save.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2Save.Location = new System.Drawing.Point(1003, 140);
            this.button2Save.Name = "button2Save";
            this.button2Save.Size = new System.Drawing.Size(124, 41);
            this.button2Save.TabIndex = 3;
            this.button2Save.Text = "Save";
            this.button2Save.UseVisualStyleBackColor = false;
            this.button2Save.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(335, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "PersonID :";
            // 
            // label3PersonIDvalue
            // 
            this.label3PersonIDvalue.AutoSize = true;
            this.label3PersonIDvalue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3PersonIDvalue.Location = new System.Drawing.Point(504, 152);
            this.label3PersonIDvalue.Name = "label3PersonIDvalue";
            this.label3PersonIDvalue.Size = new System.Drawing.Size(63, 29);
            this.label3PersonIDvalue.TabIndex = 5;
            this.label3PersonIDvalue.Text = "N/A ";
            // 
            // linkLabelRemove
            // 
            this.linkLabelRemove.AutoSize = true;
            this.linkLabelRemove.Location = new System.Drawing.Point(978, 601);
            this.linkLabelRemove.Name = "linkLabelRemove";
            this.linkLabelRemove.Size = new System.Drawing.Size(68, 20);
            this.linkLabelRemove.TabIndex = 56;
            this.linkLabelRemove.TabStop = true;
            this.linkLabelRemove.Text = "Remove";
            this.linkLabelRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRemove_LinkClicked);
            // 
            // linkLabelSetImage
            // 
            this.linkLabelSetImage.AutoSize = true;
            this.linkLabelSetImage.Location = new System.Drawing.Point(978, 568);
            this.linkLabelSetImage.Name = "linkLabelSetImage";
            this.linkLabelSetImage.Size = new System.Drawing.Size(83, 20);
            this.linkLabelSetImage.TabIndex = 55;
            this.linkLabelSetImage.TabStop = true;
            this.linkLabelSetImage.Text = "Set Image";
            this.linkLabelSetImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSetImage_LinkClicked);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(690, 484);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(196, 28);
            this.comboBox1.TabIndex = 54;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(690, 345);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(196, 26);
            this.dateTimePicker1.TabIndex = 53;
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(690, 412);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(196, 26);
            this.textBoxPhone.TabIndex = 52;
            this.textBoxPhone.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPhone_Validating);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(510, 484);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 25);
            this.label12.TabIndex = 51;
            this.label12.Text = "Country";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(510, 414);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 25);
            this.label11.TabIndex = 50;
            this.label11.Text = "Phone";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(510, 346);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 25);
            this.label10.TabIndex = 49;
            this.label10.Text = "Date Of Birth";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(323, 414);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(87, 24);
            this.radioButton2.TabIndex = 48;
            this.radioButton2.Text = "Female";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(214, 414);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(68, 24);
            this.radioButton1.TabIndex = 47;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Male";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(214, 555);
            this.textBoxAddress.Multiline = true;
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(672, 126);
            this.textBoxAddress.TabIndex = 46;
            this.textBoxAddress.TextChanged += new System.EventHandler(this.textBoxAddress_TextChanged);
            this.textBoxAddress.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxAddress_Validating);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(214, 483);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(196, 26);
            this.textBoxEmail.TabIndex = 45;
            this.textBoxEmail.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxEmail_Validating);
            // 
            // textBoxNationalNo
            // 
            this.textBoxNationalNo.Location = new System.Drawing.Point(214, 345);
            this.textBoxNationalNo.Name = "textBoxNationalNo";
            this.textBoxNationalNo.Size = new System.Drawing.Size(196, 26);
            this.textBoxNationalNo.TabIndex = 44;
            this.textBoxNationalNo.TextChanged += new System.EventHandler(this.textBoxNationalNo_TextChanged);
            this.textBoxNationalNo.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxNationalNo_Validating);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_project.Properties.Resources.man;
            this.pictureBox1.Location = new System.Drawing.Point(928, 331);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 210);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(762, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 25);
            this.label9.TabIndex = 42;
            this.label9.Text = "Third";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(997, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 25);
            this.label8.TabIndex = 41;
            this.label8.Text = "Last";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(504, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 25);
            this.label7.TabIndex = 40;
            this.label7.Text = "Second";
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(928, 275);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(196, 26);
            this.textBoxLastName.TabIndex = 39;
            this.textBoxLastName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxLastName_Validating);
            // 
            // textBoxThirdName
            // 
            this.textBoxThirdName.Location = new System.Drawing.Point(690, 275);
            this.textBoxThirdName.Name = "textBoxThirdName";
            this.textBoxThirdName.Size = new System.Drawing.Size(196, 26);
            this.textBoxThirdName.TabIndex = 38;
            // 
            // textBoxSecondName
            // 
            this.textBoxSecondName.Location = new System.Drawing.Point(452, 275);
            this.textBoxSecondName.Name = "textBoxSecondName";
            this.textBoxSecondName.Size = new System.Drawing.Size(196, 26);
            this.textBoxSecondName.TabIndex = 37;
            this.textBoxSecondName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxSecondName_Validating);
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(214, 275);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(196, 26);
            this.textBoxFirstName.TabIndex = 36;
            this.textBoxFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxFirstName_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(50, 554);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 25);
            this.label6.TabIndex = 35;
            this.label6.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 484);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 25);
            this.label5.TabIndex = 34;
            this.label5.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(277, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 25);
            this.label4.TabIndex = 33;
            this.label4.Text = "First";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 25);
            this.label3.TabIndex = 32;
            this.label3.Text = "Gendor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 344);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 25);
            this.label1.TabIndex = 31;
            this.label1.Text = "National No";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(50, 274);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 25);
            this.label13.TabIndex = 57;
            this.label13.Text = "Name";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AddUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 715);
            this.Controls.Add(this.linkLabelRemove);
            this.Controls.Add(this.linkLabelSetImage);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxNationalNo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxThirdName);
            this.Controls.Add(this.textBoxSecondName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label3PersonIDvalue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2Save);
            this.Controls.Add(this.label1Title);
            this.Controls.Add(this.button1Close);
            this.Name = "AddUpdateForm";
            this.Text = "AddUpdateForm";
            this.Load += new System.EventHandler(this.AddUpdateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1Close;
        private System.Windows.Forms.Label label1Title;
        private System.Windows.Forms.Button button2Save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3PersonIDvalue;
        private System.Windows.Forms.LinkLabel linkLabelRemove;
        private System.Windows.Forms.LinkLabel linkLabelSetImage;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxNationalNo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxThirdName;
        private System.Windows.Forms.TextBox textBoxSecondName;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}