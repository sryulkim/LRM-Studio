namespace HMIProject
{
    partial class Alarm
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
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbPeriod = new System.Windows.Forms.TextBox();
            this.chLogData = new System.Windows.Forms.CheckBox();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.tbHighPage = new System.Windows.Forms.TextBox();
            this.tbHighPriority = new System.Windows.Forms.TextBox();
            this.tbHighAlarm = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbLowPage = new System.Windows.Forms.TextBox();
            this.tbLowPriority = new System.Windows.Forms.TextBox();
            this.tbLowAlarm = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chHigh = new System.Windows.Forms.CheckBox();
            this.chMessage = new System.Windows.Forms.CheckBox();
            this.chLow = new System.Windows.Forms.CheckBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Location = new System.Drawing.Point(402, 174);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(88, 22);
            this.btn_Confirm.TabIndex = 3;
            this.btn_Confirm.Text = "확인";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.tbPeriod);
            this.groupBox2.Controls.Add(this.chLogData);
            this.groupBox2.Controls.Add(this.tbMessage);
            this.groupBox2.Controls.Add(this.tbHighPage);
            this.groupBox2.Controls.Add(this.tbHighPriority);
            this.groupBox2.Controls.Add(this.tbHighAlarm);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbLowPage);
            this.groupBox2.Controls.Add(this.tbLowPriority);
            this.groupBox2.Controls.Add(this.tbLowAlarm);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.chHigh);
            this.groupBox2.Controls.Add(this.chMessage);
            this.groupBox2.Controls.Add(this.chLow);
            this.groupBox2.Location = new System.Drawing.Point(22, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(576, 135);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Alarm";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(310, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 23;
            this.label10.Text = "알람주기";
            // 
            // tbPeriod
            // 
            this.tbPeriod.Location = new System.Drawing.Point(390, 71);
            this.tbPeriod.Name = "tbPeriod";
            this.tbPeriod.Size = new System.Drawing.Size(121, 21);
            this.tbPeriod.TabIndex = 18;
            // 
            // chLogData
            // 
            this.chLogData.AutoSize = true;
            this.chLogData.Location = new System.Drawing.Point(28, 104);
            this.chLogData.Name = "chLogData";
            this.chLogData.Size = new System.Drawing.Size(88, 16);
            this.chLogData.TabIndex = 17;
            this.chLogData.Text = "데이터 기록";
            this.chLogData.UseVisualStyleBackColor = true;
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(111, 71);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(177, 21);
            this.tbMessage.TabIndex = 16;
            // 
            // tbHighPage
            // 
            this.tbHighPage.Location = new System.Drawing.Point(529, 44);
            this.tbHighPage.Name = "tbHighPage";
            this.tbHighPage.Size = new System.Drawing.Size(39, 21);
            this.tbHighPage.TabIndex = 15;
            // 
            // tbHighPriority
            // 
            this.tbHighPriority.Location = new System.Drawing.Point(460, 44);
            this.tbHighPriority.Name = "tbHighPriority";
            this.tbHighPriority.Size = new System.Drawing.Size(51, 21);
            this.tbHighPriority.TabIndex = 14;
            // 
            // tbHighAlarm
            // 
            this.tbHighAlarm.Location = new System.Drawing.Point(390, 44);
            this.tbHighAlarm.Name = "tbHighAlarm";
            this.tbHighAlarm.Size = new System.Drawing.Size(51, 21);
            this.tbHighAlarm.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(527, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "페이지";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(458, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "우선순위";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(388, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 10;
            this.label9.Text = "알람변수";
            // 
            // tbLowPage
            // 
            this.tbLowPage.Location = new System.Drawing.Point(249, 43);
            this.tbLowPage.Name = "tbLowPage";
            this.tbLowPage.Size = new System.Drawing.Size(39, 21);
            this.tbLowPage.TabIndex = 9;
            // 
            // tbLowPriority
            // 
            this.tbLowPriority.Location = new System.Drawing.Point(181, 43);
            this.tbLowPriority.Name = "tbLowPriority";
            this.tbLowPriority.Size = new System.Drawing.Size(51, 21);
            this.tbLowPriority.TabIndex = 8;
            // 
            // tbLowAlarm
            // 
            this.tbLowAlarm.Location = new System.Drawing.Point(111, 44);
            this.tbLowAlarm.Name = "tbLowAlarm";
            this.tbLowAlarm.Size = new System.Drawing.Size(51, 21);
            this.tbLowAlarm.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(247, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "페이지";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "우선순위";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "알람변수";
            // 
            // chHigh
            // 
            this.chHigh.AutoSize = true;
            this.chHigh.Location = new System.Drawing.Point(312, 45);
            this.chHigh.Name = "chHigh";
            this.chHigh.Size = new System.Drawing.Size(49, 16);
            this.chHigh.TabIndex = 3;
            this.chHigh.Text = "High";
            this.chHigh.UseVisualStyleBackColor = true;
            this.chHigh.CheckedChanged += new System.EventHandler(this.chHigh_CheckedChanged);
            // 
            // chMessage
            // 
            this.chMessage.AutoSize = true;
            this.chMessage.Location = new System.Drawing.Point(28, 76);
            this.chMessage.Name = "chMessage";
            this.chMessage.Size = new System.Drawing.Size(60, 16);
            this.chMessage.TabIndex = 2;
            this.chMessage.Text = "메세지";
            this.chMessage.UseVisualStyleBackColor = true;
            this.chMessage.CheckedChanged += new System.EventHandler(this.chMessage_CheckedChanged);
            // 
            // chLow
            // 
            this.chLow.AutoSize = true;
            this.chLow.Location = new System.Drawing.Point(28, 45);
            this.chLow.Name = "chLow";
            this.chLow.Size = new System.Drawing.Size(48, 16);
            this.chLow.TabIndex = 0;
            this.chLow.Text = "Low";
            this.chLow.UseVisualStyleBackColor = true;
            this.chLow.CheckedChanged += new System.EventHandler(this.chLow_CheckedChanged);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(509, 174);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(79, 22);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "취소";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // Alarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 212);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_Confirm);
            this.Name = "Alarm";
            this.Text = "Alarm Setting";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chMessage;
        private System.Windows.Forms.CheckBox chLow;
        private System.Windows.Forms.CheckBox chHigh;
        private System.Windows.Forms.CheckBox chLogData;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.TextBox tbHighPage;
        private System.Windows.Forms.TextBox tbHighPriority;
        private System.Windows.Forms.TextBox tbHighAlarm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbLowPage;
        private System.Windows.Forms.TextBox tbLowPriority;
        private System.Windows.Forms.TextBox tbLowAlarm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbPeriod;
    }
}