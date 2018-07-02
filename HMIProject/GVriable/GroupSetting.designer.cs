namespace HMIProject
{
    partial class GroupSetting
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.tcNetwork = new System.Windows.Forms.TabControl();
            this.Ethernet = new System.Windows.Forms.TabPage();
            this.cbHeader = new System.Windows.Forms.ComboBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbIPAddress = new System.Windows.Forms.TextBox();
            this.cbProtocol = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbGroupName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.RS485 = new System.Windows.Forms.TabPage();
            this.MVB = new System.Windows.Forms.TabPage();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tcNetwork.SuspendLayout();
            this.Ethernet.SuspendLayout();
            this.MVB.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(539, 294);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(79, 22);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "취소";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Location = new System.Drawing.Point(425, 294);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(88, 22);
            this.btn_Confirm.TabIndex = 7;
            this.btn_Confirm.Text = "확인";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // tcNetwork
            // 
            this.tcNetwork.Controls.Add(this.Ethernet);
            this.tcNetwork.Controls.Add(this.RS485);
            this.tcNetwork.Controls.Add(this.MVB);
            this.tcNetwork.Location = new System.Drawing.Point(34, 30);
            this.tcNetwork.Name = "tcNetwork";
            this.tcNetwork.SelectedIndex = 0;
            this.tcNetwork.Size = new System.Drawing.Size(588, 244);
            this.tcNetwork.TabIndex = 0;
            // 
            // Ethernet
            // 
            this.Ethernet.Controls.Add(this.cbHeader);
            this.Ethernet.Controls.Add(this.tbPort);
            this.Ethernet.Controls.Add(this.label10);
            this.Ethernet.Controls.Add(this.tbIPAddress);
            this.Ethernet.Controls.Add(this.cbProtocol);
            this.Ethernet.Controls.Add(this.label2);
            this.Ethernet.Controls.Add(this.label1);
            this.Ethernet.Controls.Add(this.label9);
            this.Ethernet.Controls.Add(this.tbGroupName);
            this.Ethernet.Controls.Add(this.label8);
            this.Ethernet.Location = new System.Drawing.Point(4, 22);
            this.Ethernet.Name = "Ethernet";
            this.Ethernet.Padding = new System.Windows.Forms.Padding(3);
            this.Ethernet.Size = new System.Drawing.Size(580, 218);
            this.Ethernet.TabIndex = 2;
            this.Ethernet.Text = "Ethernet";
            this.Ethernet.UseVisualStyleBackColor = true;
            // 
            // cbHeader
            // 
            this.cbHeader.FormattingEnabled = true;
            this.cbHeader.Location = new System.Drawing.Point(371, 31);
            this.cbHeader.Name = "cbHeader";
            this.cbHeader.Size = new System.Drawing.Size(131, 20);
            this.cbHeader.TabIndex = 13;
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(132, 165);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(121, 21);
            this.tbPort.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(285, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 12);
            this.label10.TabIndex = 11;
            this.label10.Text = "Header";
            // 
            // tbIPAddress
            // 
            this.tbIPAddress.Location = new System.Drawing.Point(132, 119);
            this.tbIPAddress.Name = "tbIPAddress";
            this.tbIPAddress.Size = new System.Drawing.Size(150, 21);
            this.tbIPAddress.TabIndex = 10;
            // 
            // cbProtocol
            // 
            this.cbProtocol.FormattingEnabled = true;
            this.cbProtocol.Location = new System.Drawing.Point(132, 31);
            this.cbProtocol.Name = "cbProtocol";
            this.cbProtocol.Size = new System.Drawing.Size(121, 20);
            this.cbProtocol.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Protocol";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Group Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "Port";
            // 
            // tbGroupName
            // 
            this.tbGroupName.Location = new System.Drawing.Point(132, 73);
            this.tbGroupName.Name = "tbGroupName";
            this.tbGroupName.Size = new System.Drawing.Size(121, 21);
            this.tbGroupName.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "IP Address";
            // 
            // RS485
            // 
            this.RS485.Location = new System.Drawing.Point(4, 22);
            this.RS485.Name = "RS485";
            this.RS485.Padding = new System.Windows.Forms.Padding(3);
            this.RS485.Size = new System.Drawing.Size(580, 218);
            this.RS485.TabIndex = 1;
            this.RS485.Text = "RS485";
            this.RS485.UseVisualStyleBackColor = true;
            // 
            // MVB
            // 
            this.MVB.Controls.Add(this.comboBox5);
            this.MVB.Controls.Add(this.comboBox4);
            this.MVB.Controls.Add(this.comboBox3);
            this.MVB.Controls.Add(this.comboBox2);
            this.MVB.Controls.Add(this.comboBox1);
            this.MVB.Controls.Add(this.label7);
            this.MVB.Controls.Add(this.label6);
            this.MVB.Controls.Add(this.label5);
            this.MVB.Controls.Add(this.label4);
            this.MVB.Controls.Add(this.label3);
            this.MVB.Location = new System.Drawing.Point(4, 22);
            this.MVB.Name = "MVB";
            this.MVB.Padding = new System.Windows.Forms.Padding(3);
            this.MVB.Size = new System.Drawing.Size(580, 218);
            this.MVB.TabIndex = 0;
            this.MVB.Text = "MVB";
            this.MVB.UseVisualStyleBackColor = true;
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(451, 38);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(85, 20);
            this.comboBox5.TabIndex = 14;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(346, 38);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(85, 20);
            this.comboBox4.TabIndex = 13;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(237, 38);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(85, 20);
            this.comboBox3.TabIndex = 12;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(131, 38);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(85, 20);
            this.comboBox2.TabIndex = 11;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(26, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(85, 20);
            this.comboBox1.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(466, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "Bit Length";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(354, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "Bit Position";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(251, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "SRC/SNK";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "FCode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "PORT";
            // 
            // GroupSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 328);
            this.Controls.Add(this.tcNetwork);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Confirm);
            this.Name = "GroupSetting";
            this.Text = "Group Setting";
            this.Load += new System.EventHandler(this.GroupSetting_Load);
            this.tcNetwork.ResumeLayout(false);
            this.Ethernet.ResumeLayout(false);
            this.Ethernet.PerformLayout();
            this.MVB.ResumeLayout(false);
            this.MVB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.TabControl tcNetwork;
        private System.Windows.Forms.TabPage Ethernet;
        private System.Windows.Forms.ComboBox cbHeader;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbIPAddress;
        private System.Windows.Forms.ComboBox cbProtocol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbGroupName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage RS485;
        private System.Windows.Forms.TabPage MVB;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}