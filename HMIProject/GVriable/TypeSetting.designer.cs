namespace HMIProject
{
    partial class TypeSetting
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
            this.gbMemory = new System.Windows.Forms.GroupBox();
            this.rbMemoryString = new System.Windows.Forms.RadioButton();
            this.rbMemoryReal = new System.Windows.Forms.RadioButton();
            this.rbMemoryInt = new System.Windows.Forms.RadioButton();
            this.rbMemoryBool = new System.Windows.Forms.RadioButton();
            this.gbRelay = new System.Windows.Forms.GroupBox();
            this.tcRelay = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.comboBox10 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.comboBox9 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.gbNetwork = new System.Windows.Forms.GroupBox();
            this.tcNetwork = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbIPAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rbSystem = new System.Windows.Forms.RadioButton();
            this.rbRelay = new System.Windows.Forms.RadioButton();
            this.rbNetwork = new System.Windows.Forms.RadioButton();
            this.rbMemory = new System.Windows.Forms.RadioButton();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.gbSystem = new System.Windows.Forms.GroupBox();
            this.rbSystemPage = new System.Windows.Forms.RadioButton();
            this.rbSystemVersion = new System.Windows.Forms.RadioButton();
            this.rbSystemClock = new System.Windows.Forms.RadioButton();
            this.comboBox11 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.gbMemory.SuspendLayout();
            this.gbRelay.SuspendLayout();
            this.tcRelay.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.gbNetwork.SuspendLayout();
            this.tcNetwork.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.gbSystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMemory
            // 
            this.gbMemory.Controls.Add(this.rbMemoryString);
            this.gbMemory.Controls.Add(this.rbMemoryReal);
            this.gbMemory.Controls.Add(this.rbMemoryInt);
            this.gbMemory.Controls.Add(this.rbMemoryBool);
            this.gbMemory.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gbMemory.Location = new System.Drawing.Point(29, 145);
            this.gbMemory.Name = "gbMemory";
            this.gbMemory.Size = new System.Drawing.Size(587, 64);
            this.gbMemory.TabIndex = 0;
            this.gbMemory.TabStop = false;
            // 
            // rbMemoryString
            // 
            this.rbMemoryString.AutoSize = true;
            this.rbMemoryString.Location = new System.Drawing.Point(338, 30);
            this.rbMemoryString.Name = "rbMemoryString";
            this.rbMemoryString.Size = new System.Drawing.Size(68, 16);
            this.rbMemoryString.TabIndex = 9;
            this.rbMemoryString.TabStop = true;
            this.rbMemoryString.Text = "STRING";
            this.rbMemoryString.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbMemoryString.UseVisualStyleBackColor = true;
            // 
            // rbMemoryReal
            // 
            this.rbMemoryReal.AutoSize = true;
            this.rbMemoryReal.Location = new System.Drawing.Point(234, 30);
            this.rbMemoryReal.Name = "rbMemoryReal";
            this.rbMemoryReal.Size = new System.Drawing.Size(54, 16);
            this.rbMemoryReal.TabIndex = 8;
            this.rbMemoryReal.TabStop = true;
            this.rbMemoryReal.Text = "REAL";
            this.rbMemoryReal.UseVisualStyleBackColor = true;
            // 
            // rbMemoryInt
            // 
            this.rbMemoryInt.AutoSize = true;
            this.rbMemoryInt.Location = new System.Drawing.Point(125, 30);
            this.rbMemoryInt.Name = "rbMemoryInt";
            this.rbMemoryInt.Size = new System.Drawing.Size(43, 16);
            this.rbMemoryInt.TabIndex = 7;
            this.rbMemoryInt.TabStop = true;
            this.rbMemoryInt.Text = "INT";
            this.rbMemoryInt.UseVisualStyleBackColor = true;
            // 
            // rbMemoryBool
            // 
            this.rbMemoryBool.AutoSize = true;
            this.rbMemoryBool.Location = new System.Drawing.Point(21, 30);
            this.rbMemoryBool.Name = "rbMemoryBool";
            this.rbMemoryBool.Size = new System.Drawing.Size(56, 16);
            this.rbMemoryBool.TabIndex = 6;
            this.rbMemoryBool.TabStop = true;
            this.rbMemoryBool.Text = "BOOL";
            this.rbMemoryBool.UseVisualStyleBackColor = true;
            // 
            // gbRelay
            // 
            this.gbRelay.Controls.Add(this.tcRelay);
            this.gbRelay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gbRelay.Location = new System.Drawing.Point(29, 245);
            this.gbRelay.Name = "gbRelay";
            this.gbRelay.Size = new System.Drawing.Size(587, 117);
            this.gbRelay.TabIndex = 1;
            this.gbRelay.TabStop = false;
            // 
            // tcRelay
            // 
            this.tcRelay.Controls.Add(this.tabPage4);
            this.tcRelay.Controls.Add(this.tabPage5);
            this.tcRelay.Location = new System.Drawing.Point(17, 20);
            this.tcRelay.Name = "tcRelay";
            this.tcRelay.SelectedIndex = 0;
            this.tcRelay.Size = new System.Drawing.Size(564, 88);
            this.tcRelay.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.comboBox6);
            this.tabPage4.Controls.Add(this.comboBox7);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(556, 62);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Digital";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(131, 34);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(85, 20);
            this.comboBox6.TabIndex = 17;
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(26, 34);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(85, 20);
            this.comboBox7.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "Bit Position";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "Address";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.comboBox10);
            this.tabPage5.Controls.Add(this.label12);
            this.tabPage5.Controls.Add(this.comboBox8);
            this.tabPage5.Controls.Add(this.comboBox9);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Controls.Add(this.label11);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(556, 62);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Analog";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // comboBox10
            // 
            this.comboBox10.FormattingEnabled = true;
            this.comboBox10.Location = new System.Drawing.Point(237, 36);
            this.comboBox10.Name = "comboBox10";
            this.comboBox10.Size = new System.Drawing.Size(85, 20);
            this.comboBox10.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(252, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 12);
            this.label12.TabIndex = 22;
            this.label12.Text = "Bit Length";
            // 
            // comboBox8
            // 
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Location = new System.Drawing.Point(131, 36);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(85, 20);
            this.comboBox8.TabIndex = 21;
            // 
            // comboBox9
            // 
            this.comboBox9.FormattingEnabled = true;
            this.comboBox9.Location = new System.Drawing.Point(26, 36);
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.Size = new System.Drawing.Size(85, 20);
            this.comboBox9.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(139, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "Bit Position";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "Address";
            // 
            // gbNetwork
            // 
            this.gbNetwork.Controls.Add(this.tcNetwork);
            this.gbNetwork.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gbNetwork.Location = new System.Drawing.Point(29, 390);
            this.gbNetwork.Name = "gbNetwork";
            this.gbNetwork.Size = new System.Drawing.Size(587, 131);
            this.gbNetwork.TabIndex = 2;
            this.gbNetwork.TabStop = false;
            // 
            // tcNetwork
            // 
            this.tcNetwork.Controls.Add(this.tabPage1);
            this.tcNetwork.Controls.Add(this.tabPage2);
            this.tcNetwork.Controls.Add(this.tabPage3);
            this.tcNetwork.Location = new System.Drawing.Point(17, 17);
            this.tcNetwork.Name = "tcNetwork";
            this.tcNetwork.SelectedIndex = 0;
            this.tcNetwork.Size = new System.Drawing.Size(564, 108);
            this.tcNetwork.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox5);
            this.tabPage1.Controls.Add(this.comboBox4);
            this.tabPage1.Controls.Add(this.comboBox3);
            this.tabPage1.Controls.Add(this.comboBox2);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(556, 82);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "MVB";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(556, 82);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "RS485";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.comboBox11);
            this.tabPage3.Controls.Add(this.tbPort);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.tbIPAddress);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(556, 82);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Ethernet";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(104, 45);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(101, 21);
            this.tbPort.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "Port";
            // 
            // tbIPAddress
            // 
            this.tbIPAddress.Location = new System.Drawing.Point(104, 18);
            this.tbIPAddress.Name = "tbIPAddress";
            this.tbIPAddress.Size = new System.Drawing.Size(196, 21);
            this.tbIPAddress.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "IP Address";
            // 
            // rbSystem
            // 
            this.rbSystem.AutoSize = true;
            this.rbSystem.Checked = true;
            this.rbSystem.Location = new System.Drawing.Point(29, 22);
            this.rbSystem.Name = "rbSystem";
            this.rbSystem.Size = new System.Drawing.Size(70, 16);
            this.rbSystem.TabIndex = 3;
            this.rbSystem.TabStop = true;
            this.rbSystem.Text = "System ";
            this.rbSystem.UseVisualStyleBackColor = true;
            this.rbSystem.CheckedChanged += new System.EventHandler(this.rbSystemClock_CheckedChanged);
            // 
            // rbRelay
            // 
            this.rbRelay.AutoSize = true;
            this.rbRelay.Location = new System.Drawing.Point(29, 223);
            this.rbRelay.Name = "rbRelay";
            this.rbRelay.Size = new System.Drawing.Size(55, 16);
            this.rbRelay.TabIndex = 4;
            this.rbRelay.Text = "Relay";
            this.rbRelay.UseVisualStyleBackColor = true;
            this.rbRelay.CheckedChanged += new System.EventHandler(this.rbRelay_CheckedChanged);
            // 
            // rbNetwork
            // 
            this.rbNetwork.AutoSize = true;
            this.rbNetwork.Location = new System.Drawing.Point(29, 368);
            this.rbNetwork.Name = "rbNetwork";
            this.rbNetwork.Size = new System.Drawing.Size(69, 16);
            this.rbNetwork.TabIndex = 5;
            this.rbNetwork.Text = "Network";
            this.rbNetwork.UseVisualStyleBackColor = true;
            this.rbNetwork.CheckedChanged += new System.EventHandler(this.rbNetwork_CheckedChanged);
            // 
            // rbMemory
            // 
            this.rbMemory.AutoSize = true;
            this.rbMemory.Location = new System.Drawing.Point(29, 123);
            this.rbMemory.Name = "rbMemory";
            this.rbMemory.Size = new System.Drawing.Size(70, 16);
            this.rbMemory.TabIndex = 6;
            this.rbMemory.Text = "Memory";
            this.rbMemory.UseVisualStyleBackColor = true;
            this.rbMemory.CheckedChanged += new System.EventHandler(this.rbMemory_CheckedChanged);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(537, 535);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(79, 22);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "취소";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Location = new System.Drawing.Point(430, 535);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(88, 22);
            this.btn_Confirm.TabIndex = 7;
            this.btn_Confirm.Text = "확인";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // gbSystem
            // 
            this.gbSystem.Controls.Add(this.rbSystemPage);
            this.gbSystem.Controls.Add(this.rbSystemVersion);
            this.gbSystem.Controls.Add(this.rbSystemClock);
            this.gbSystem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gbSystem.Location = new System.Drawing.Point(29, 44);
            this.gbSystem.Name = "gbSystem";
            this.gbSystem.Size = new System.Drawing.Size(587, 64);
            this.gbSystem.TabIndex = 10;
            this.gbSystem.TabStop = false;
            // 
            // rbSystemPage
            // 
            this.rbSystemPage.AutoSize = true;
            this.rbSystemPage.Location = new System.Drawing.Point(234, 30);
            this.rbSystemPage.Name = "rbSystemPage";
            this.rbSystemPage.Size = new System.Drawing.Size(52, 16);
            this.rbSystemPage.TabIndex = 8;
            this.rbSystemPage.Text = "Page";
            this.rbSystemPage.UseVisualStyleBackColor = true;
            // 
            // rbSystemVersion
            // 
            this.rbSystemVersion.AutoSize = true;
            this.rbSystemVersion.Location = new System.Drawing.Point(125, 30);
            this.rbSystemVersion.Name = "rbSystemVersion";
            this.rbSystemVersion.Size = new System.Drawing.Size(66, 16);
            this.rbSystemVersion.TabIndex = 7;
            this.rbSystemVersion.Text = "Version";
            this.rbSystemVersion.UseVisualStyleBackColor = true;
            // 
            // rbSystemClock
            // 
            this.rbSystemClock.AutoSize = true;
            this.rbSystemClock.Checked = true;
            this.rbSystemClock.Location = new System.Drawing.Point(21, 30);
            this.rbSystemClock.Name = "rbSystemClock";
            this.rbSystemClock.Size = new System.Drawing.Size(55, 16);
            this.rbSystemClock.TabIndex = 6;
            this.rbSystemClock.TabStop = true;
            this.rbSystemClock.Text = "Clock";
            this.rbSystemClock.UseVisualStyleBackColor = true;
            // 
            // comboBox11
            // 
            this.comboBox11.FormattingEnabled = true;
            this.comboBox11.Items.AddRange(new object[] {
            "BOOL",
            "INT",
            "REAL",
            "STRING"});
            this.comboBox11.Location = new System.Drawing.Point(380, 45);
            this.comboBox11.Name = "comboBox11";
            this.comboBox11.Size = new System.Drawing.Size(121, 20);
            this.comboBox11.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(415, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 12);
            this.label13.TabIndex = 5;
            this.label13.Text = "Data Type";
            // 
            // TypeSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 566);
            this.Controls.Add(this.gbSystem);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Confirm);
            this.Controls.Add(this.rbMemory);
            this.Controls.Add(this.rbNetwork);
            this.Controls.Add(this.rbRelay);
            this.Controls.Add(this.rbSystem);
            this.Controls.Add(this.gbNetwork);
            this.Controls.Add(this.gbRelay);
            this.Controls.Add(this.gbMemory);
            this.Name = "TypeSetting";
            this.Text = "TypeSetting";
            this.Load += new System.EventHandler(this.TypeSetting_Load);
            this.gbMemory.ResumeLayout(false);
            this.gbMemory.PerformLayout();
            this.gbRelay.ResumeLayout(false);
            this.tcRelay.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.gbNetwork.ResumeLayout(false);
            this.tcNetwork.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.gbSystem.ResumeLayout(false);
            this.gbSystem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMemory;
        private System.Windows.Forms.GroupBox gbRelay;
        private System.Windows.Forms.GroupBox gbNetwork;
        private System.Windows.Forms.TabControl tcNetwork;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RadioButton rbSystem;
        private System.Windows.Forms.RadioButton rbRelay;
        private System.Windows.Forms.RadioButton rbNetwork;
        private System.Windows.Forms.TabControl tcRelay;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.RadioButton rbMemory;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.RadioButton rbMemoryString;
        private System.Windows.Forms.RadioButton rbMemoryReal;
        private System.Windows.Forms.RadioButton rbMemoryInt;
        private System.Windows.Forms.RadioButton rbMemoryBool;
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
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbIPAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbSystem;
        private System.Windows.Forms.RadioButton rbSystemPage;
        private System.Windows.Forms.RadioButton rbSystemVersion;
        private System.Windows.Forms.RadioButton rbSystemClock;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.ComboBox comboBox9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBox11;
    }
}