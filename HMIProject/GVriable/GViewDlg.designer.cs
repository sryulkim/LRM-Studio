namespace HMIProject
{
    partial class GViewDlg
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnAdd = new System.Windows.Forms.Button();
            this.Ethernet = new System.Windows.Forms.TabPage();
            this.dvNEPoint = new System.Windows.Forms.DataGridView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.Memory = new System.Windows.Forms.TabPage();
            this.dvMPoint = new System.Windows.Forms.DataGridView();
            this.SysClock = new System.Windows.Forms.TabPage();
            this.dvSPoint = new System.Windows.Forms.DataGridView();
            this.MVB = new System.Windows.Forms.TabPage();
            this.dvNMPoint = new System.Windows.Forms.DataGridView();
            this.RS485 = new System.Windows.Forms.TabPage();
            this.dvNRPoint = new System.Windows.Forms.DataGridView();
            this.DigitalInput = new System.Windows.Forms.TabPage();
            this.dvDIPoint = new System.Windows.Forms.DataGridView();
            this.AnalogInput = new System.Windows.Forms.TabPage();
            this.dvAIPoint = new System.Windows.Forms.DataGridView();
            this.configDlgBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.buttonConditionEvent = new System.Windows.Forms.Button();
            this.ipAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataTypeDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initialValueDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gVariableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initialValueDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initialValueDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initialValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alarmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataTypeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initialValueDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alarmDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gVariableBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.gVariableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gVariableBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ethernet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvNEPoint)).BeginInit();
            this.tabControl.SuspendLayout();
            this.Memory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvMPoint)).BeginInit();
            this.SysClock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvSPoint)).BeginInit();
            this.MVB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvNMPoint)).BeginInit();
            this.RS485.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvNRPoint)).BeginInit();
            this.DigitalInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvDIPoint)).BeginInit();
            this.AnalogInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvAIPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configDlgBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gVariableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gVariableBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gVariableBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gVariableBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(407, 375);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(71, 22);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Ethernet
            // 
            this.Ethernet.Controls.Add(this.dvNEPoint);
            this.Ethernet.Location = new System.Drawing.Point(4, 22);
            this.Ethernet.Name = "Ethernet";
            this.Ethernet.Padding = new System.Windows.Forms.Padding(3);
            this.Ethernet.Size = new System.Drawing.Size(640, 320);
            this.Ethernet.TabIndex = 1;
            this.Ethernet.Text = "Ethernet";
            this.Ethernet.UseVisualStyleBackColor = true;
            // 
            // dvNEPoint
            // 
            this.dvNEPoint.AutoGenerateColumns = false;
            this.dvNEPoint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn2,
            this.ipAddress,
            this.typeDataGridViewTextBoxColumn2,
            this.initialValueDataGridViewTextBoxColumn2,
            this.portDataGridViewTextBoxColumn2,
            this.dataType});
            this.dvNEPoint.DataSource = this.gVariableBindingSource;
            this.dvNEPoint.Location = new System.Drawing.Point(0, 0);
            this.dvNEPoint.Name = "dvNEPoint";
            this.dvNEPoint.RowTemplate.Height = 23;
            this.dvNEPoint.Size = new System.Drawing.Size(644, 320);
            this.dvNEPoint.TabIndex = 3;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.Memory);
            this.tabControl.Controls.Add(this.SysClock);
            this.tabControl.Controls.Add(this.Ethernet);
            this.tabControl.Controls.Add(this.MVB);
            this.tabControl.Controls.Add(this.RS485);
            this.tabControl.Controls.Add(this.DigitalInput);
            this.tabControl.Controls.Add(this.AnalogInput);
            this.tabControl.Location = new System.Drawing.Point(19, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(648, 346);
            this.tabControl.TabIndex = 0;
            // 
            // Memory
            // 
            this.Memory.Controls.Add(this.dvMPoint);
            this.Memory.Location = new System.Drawing.Point(4, 22);
            this.Memory.Name = "Memory";
            this.Memory.Padding = new System.Windows.Forms.Padding(3);
            this.Memory.Size = new System.Drawing.Size(640, 320);
            this.Memory.TabIndex = 5;
            this.Memory.Text = "Memory";
            this.Memory.UseVisualStyleBackColor = true;
            // 
            // dvMPoint
            // 
            this.dvMPoint.AutoGenerateColumns = false;
            this.dvMPoint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn3,
            this.typeDataGridViewTextBoxColumn3,
            this.dataTypeDataGridViewTextBoxColumn3,
            this.initialValueDataGridViewTextBoxColumn3});
            this.dvMPoint.DataSource = this.gVariableBindingSource;
            this.dvMPoint.Location = new System.Drawing.Point(0, 0);
            this.dvMPoint.Name = "dvMPoint";
            this.dvMPoint.RowTemplate.Height = 23;
            this.dvMPoint.Size = new System.Drawing.Size(640, 320);
            this.dvMPoint.TabIndex = 5;
            // 
            // SysClock
            // 
            this.SysClock.Controls.Add(this.dvSPoint);
            this.SysClock.Location = new System.Drawing.Point(4, 22);
            this.SysClock.Name = "SysClock";
            this.SysClock.Padding = new System.Windows.Forms.Padding(3);
            this.SysClock.Size = new System.Drawing.Size(640, 320);
            this.SysClock.TabIndex = 7;
            this.SysClock.Text = "System";
            this.SysClock.UseVisualStyleBackColor = true;
            // 
            // dvSPoint
            // 
            this.dvSPoint.AutoGenerateColumns = false;
            this.dvSPoint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn4,
            this.typeDataGridViewTextBoxColumn4,
            this.initialValueDataGridViewTextBoxColumn4});
            this.dvSPoint.DataSource = this.gVariableBindingSource;
            this.dvSPoint.Location = new System.Drawing.Point(0, 0);
            this.dvSPoint.Name = "dvSPoint";
            this.dvSPoint.RowTemplate.Height = 23;
            this.dvSPoint.Size = new System.Drawing.Size(640, 320);
            this.dvSPoint.TabIndex = 5;
            // 
            // MVB
            // 
            this.MVB.Controls.Add(this.dvNMPoint);
            this.MVB.Location = new System.Drawing.Point(4, 22);
            this.MVB.Name = "MVB";
            this.MVB.Padding = new System.Windows.Forms.Padding(3);
            this.MVB.Size = new System.Drawing.Size(640, 320);
            this.MVB.TabIndex = 3;
            this.MVB.Text = "MVB";
            this.MVB.UseVisualStyleBackColor = true;
            // 
            // dvNMPoint
            // 
            this.dvNMPoint.AutoGenerateColumns = false;
            this.dvNMPoint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.dataTypeDataGridViewTextBoxColumn,
            this.initialValueDataGridViewTextBoxColumn,
            this.portDataGridViewTextBoxColumn,
            this.alarmDataGridViewTextBoxColumn});
            this.dvNMPoint.DataSource = this.gVariableBindingSource;
            this.dvNMPoint.Location = new System.Drawing.Point(0, 0);
            this.dvNMPoint.Name = "dvNMPoint";
            this.dvNMPoint.RowTemplate.Height = 23;
            this.dvNMPoint.Size = new System.Drawing.Size(644, 320);
            this.dvNMPoint.TabIndex = 2;
            // 
            // RS485
            // 
            this.RS485.Controls.Add(this.dvNRPoint);
            this.RS485.Location = new System.Drawing.Point(4, 22);
            this.RS485.Name = "RS485";
            this.RS485.Padding = new System.Windows.Forms.Padding(3);
            this.RS485.Size = new System.Drawing.Size(640, 320);
            this.RS485.TabIndex = 4;
            this.RS485.Text = "RS485";
            this.RS485.UseVisualStyleBackColor = true;
            // 
            // dvNRPoint
            // 
            this.dvNRPoint.AutoGenerateColumns = false;
            this.dvNRPoint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn1,
            this.typeDataGridViewTextBoxColumn1,
            this.dataTypeDataGridViewTextBoxColumn1,
            this.initialValueDataGridViewTextBoxColumn1,
            this.portDataGridViewTextBoxColumn1,
            this.alarmDataGridViewTextBoxColumn1});
            this.dvNRPoint.DataSource = this.gVariableBindingSource;
            this.dvNRPoint.Location = new System.Drawing.Point(0, 0);
            this.dvNRPoint.Name = "dvNRPoint";
            this.dvNRPoint.RowTemplate.Height = 23;
            this.dvNRPoint.Size = new System.Drawing.Size(644, 320);
            this.dvNRPoint.TabIndex = 4;
            // 
            // DigitalInput
            // 
            this.DigitalInput.Controls.Add(this.dvDIPoint);
            this.DigitalInput.Location = new System.Drawing.Point(4, 22);
            this.DigitalInput.Name = "DigitalInput";
            this.DigitalInput.Padding = new System.Windows.Forms.Padding(3);
            this.DigitalInput.Size = new System.Drawing.Size(640, 320);
            this.DigitalInput.TabIndex = 6;
            this.DigitalInput.Text = "Digital Input";
            this.DigitalInput.UseVisualStyleBackColor = true;
            // 
            // dvDIPoint
            // 
            this.dvDIPoint.Location = new System.Drawing.Point(0, 0);
            this.dvDIPoint.Name = "dvDIPoint";
            this.dvDIPoint.RowTemplate.Height = 23;
            this.dvDIPoint.Size = new System.Drawing.Size(640, 320);
            this.dvDIPoint.TabIndex = 5;
            // 
            // AnalogInput
            // 
            this.AnalogInput.Controls.Add(this.dvAIPoint);
            this.AnalogInput.Location = new System.Drawing.Point(4, 22);
            this.AnalogInput.Name = "AnalogInput";
            this.AnalogInput.Padding = new System.Windows.Forms.Padding(3);
            this.AnalogInput.Size = new System.Drawing.Size(640, 320);
            this.AnalogInput.TabIndex = 8;
            this.AnalogInput.Text = "Analog Input";
            // 
            // dvAIPoint
            // 
            this.dvAIPoint.Location = new System.Drawing.Point(0, 0);
            this.dvAIPoint.Name = "dvAIPoint";
            this.dvAIPoint.RowTemplate.Height = 23;
            this.dvAIPoint.Size = new System.Drawing.Size(640, 320);
            this.dvAIPoint.TabIndex = 6;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(502, 375);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(69, 22);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(592, 375);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 22);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // buttonConditionEvent
            // 
            this.buttonConditionEvent.Location = new System.Drawing.Point(23, 375);
            this.buttonConditionEvent.Name = "buttonConditionEvent";
            this.buttonConditionEvent.Size = new System.Drawing.Size(120, 23);
            this.buttonConditionEvent.TabIndex = 4;
            this.buttonConditionEvent.Text = "Condition Event";
            this.buttonConditionEvent.UseVisualStyleBackColor = true;
            this.buttonConditionEvent.Click += new System.EventHandler(this.buttonConditionEvent_Click);
            // 
            // ipAddress
            // 
            this.ipAddress.DataPropertyName = "ipAddress";
            this.ipAddress.HeaderText = "IP 주소";
            this.ipAddress.Name = "ipAddress";
            // 
            // nameDataGridViewTextBoxColumn3
            // 
            this.nameDataGridViewTextBoxColumn3.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn3.HeaderText = "변수명";
            this.nameDataGridViewTextBoxColumn3.Name = "nameDataGridViewTextBoxColumn3";
            // 
            // typeDataGridViewTextBoxColumn3
            // 
            this.typeDataGridViewTextBoxColumn3.DataPropertyName = "type";
            this.typeDataGridViewTextBoxColumn3.HeaderText = "타입";
            this.typeDataGridViewTextBoxColumn3.Name = "typeDataGridViewTextBoxColumn3";
            // 
            // dataTypeDataGridViewTextBoxColumn3
            // 
            this.dataTypeDataGridViewTextBoxColumn3.DataPropertyName = "dataType";
            this.dataTypeDataGridViewTextBoxColumn3.HeaderText = "데이터타입";
            this.dataTypeDataGridViewTextBoxColumn3.Name = "dataTypeDataGridViewTextBoxColumn3";
            // 
            // initialValueDataGridViewTextBoxColumn3
            // 
            this.initialValueDataGridViewTextBoxColumn3.DataPropertyName = "initialValue";
            this.initialValueDataGridViewTextBoxColumn3.HeaderText = "초기값";
            this.initialValueDataGridViewTextBoxColumn3.Name = "initialValueDataGridViewTextBoxColumn3";
            // 
            // gVariableBindingSource
            // 
            this.gVariableBindingSource.DataSource = typeof(HMIProject.GVariable);
            // 
            // nameDataGridViewTextBoxColumn4
            // 
            this.nameDataGridViewTextBoxColumn4.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn4.HeaderText = "변수명";
            this.nameDataGridViewTextBoxColumn4.Name = "nameDataGridViewTextBoxColumn4";
            // 
            // typeDataGridViewTextBoxColumn4
            // 
            this.typeDataGridViewTextBoxColumn4.DataPropertyName = "type";
            this.typeDataGridViewTextBoxColumn4.HeaderText = "타입";
            this.typeDataGridViewTextBoxColumn4.Name = "typeDataGridViewTextBoxColumn4";
            // 
            // initialValueDataGridViewTextBoxColumn4
            // 
            this.initialValueDataGridViewTextBoxColumn4.DataPropertyName = "initialValue";
            this.initialValueDataGridViewTextBoxColumn4.HeaderText = "초기값";
            this.initialValueDataGridViewTextBoxColumn4.Name = "initialValueDataGridViewTextBoxColumn4";
            // 
            // nameDataGridViewTextBoxColumn2
            // 
            this.nameDataGridViewTextBoxColumn2.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn2.HeaderText = "변수명";
            this.nameDataGridViewTextBoxColumn2.Name = "nameDataGridViewTextBoxColumn2";
            // 
            // typeDataGridViewTextBoxColumn2
            // 
            this.typeDataGridViewTextBoxColumn2.DataPropertyName = "type";
            this.typeDataGridViewTextBoxColumn2.HeaderText = "타입";
            this.typeDataGridViewTextBoxColumn2.Name = "typeDataGridViewTextBoxColumn2";
            // 
            // initialValueDataGridViewTextBoxColumn2
            // 
            this.initialValueDataGridViewTextBoxColumn2.DataPropertyName = "initialValue";
            this.initialValueDataGridViewTextBoxColumn2.HeaderText = "초기값";
            this.initialValueDataGridViewTextBoxColumn2.Name = "initialValueDataGridViewTextBoxColumn2";
            // 
            // portDataGridViewTextBoxColumn2
            // 
            this.portDataGridViewTextBoxColumn2.DataPropertyName = "port";
            this.portDataGridViewTextBoxColumn2.HeaderText = "포트 번호";
            this.portDataGridViewTextBoxColumn2.Name = "portDataGridViewTextBoxColumn2";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "변수명";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "타입";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            // 
            // dataTypeDataGridViewTextBoxColumn
            // 
            this.dataTypeDataGridViewTextBoxColumn.DataPropertyName = "dataType";
            this.dataTypeDataGridViewTextBoxColumn.HeaderText = "데이터타입";
            this.dataTypeDataGridViewTextBoxColumn.Name = "dataTypeDataGridViewTextBoxColumn";
            // 
            // initialValueDataGridViewTextBoxColumn
            // 
            this.initialValueDataGridViewTextBoxColumn.DataPropertyName = "initialValue";
            this.initialValueDataGridViewTextBoxColumn.HeaderText = "초기값";
            this.initialValueDataGridViewTextBoxColumn.Name = "initialValueDataGridViewTextBoxColumn";
            // 
            // portDataGridViewTextBoxColumn
            // 
            this.portDataGridViewTextBoxColumn.DataPropertyName = "port";
            this.portDataGridViewTextBoxColumn.HeaderText = "포트 번호";
            this.portDataGridViewTextBoxColumn.Name = "portDataGridViewTextBoxColumn";
            // 
            // alarmDataGridViewTextBoxColumn
            // 
            this.alarmDataGridViewTextBoxColumn.DataPropertyName = "alarm";
            this.alarmDataGridViewTextBoxColumn.HeaderText = "알람";
            this.alarmDataGridViewTextBoxColumn.Name = "alarmDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "변수명";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            // 
            // typeDataGridViewTextBoxColumn1
            // 
            this.typeDataGridViewTextBoxColumn1.DataPropertyName = "type";
            this.typeDataGridViewTextBoxColumn1.HeaderText = "타입";
            this.typeDataGridViewTextBoxColumn1.Name = "typeDataGridViewTextBoxColumn1";
            // 
            // dataTypeDataGridViewTextBoxColumn1
            // 
            this.dataTypeDataGridViewTextBoxColumn1.DataPropertyName = "dataType";
            this.dataTypeDataGridViewTextBoxColumn1.HeaderText = "데이터타입";
            this.dataTypeDataGridViewTextBoxColumn1.Name = "dataTypeDataGridViewTextBoxColumn1";
            // 
            // initialValueDataGridViewTextBoxColumn1
            // 
            this.initialValueDataGridViewTextBoxColumn1.DataPropertyName = "initialValue";
            this.initialValueDataGridViewTextBoxColumn1.HeaderText = "초기값";
            this.initialValueDataGridViewTextBoxColumn1.Name = "initialValueDataGridViewTextBoxColumn1";
            // 
            // portDataGridViewTextBoxColumn1
            // 
            this.portDataGridViewTextBoxColumn1.DataPropertyName = "port";
            this.portDataGridViewTextBoxColumn1.HeaderText = "포트 번호";
            this.portDataGridViewTextBoxColumn1.Name = "portDataGridViewTextBoxColumn1";
            // 
            // alarmDataGridViewTextBoxColumn1
            // 
            this.alarmDataGridViewTextBoxColumn1.DataPropertyName = "alarm";
            this.alarmDataGridViewTextBoxColumn1.HeaderText = "알람";
            this.alarmDataGridViewTextBoxColumn1.Name = "alarmDataGridViewTextBoxColumn1";
            // 
            // gVariableBindingSource3
            // 
            this.gVariableBindingSource3.DataSource = typeof(HMIProject.GVariable);
            // 
            // gVariableBindingSource1
            // 
            this.gVariableBindingSource1.DataSource = typeof(HMIProject.GVariable);
            // 
            // gVariableBindingSource2
            // 
            this.gVariableBindingSource2.DataSource = typeof(HMIProject.GVariable);
            // 
            // dataType
            // 
            this.dataType.DataPropertyName = "dataType";
            this.dataType.HeaderText = "데이터 타입";
            this.dataType.Name = "dataType";
            // 
            // GViewDlg
            // 
            this.ClientSize = new System.Drawing.Size(679, 417);
            this.Controls.Add(this.buttonConditionEvent);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tabControl);
            this.Name = "GViewDlg";
            this.Text = "G-Variable Dictionary";
            this.Load += new System.EventHandler(this.ConfigDlg_Load);
            this.Ethernet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvNEPoint)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.Memory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvMPoint)).EndInit();
            this.SysClock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvSPoint)).EndInit();
            this.MVB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvNMPoint)).EndInit();
            this.RS485.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvNRPoint)).EndInit();
            this.DigitalInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvDIPoint)).EndInit();
            this.AnalogInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvAIPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configDlgBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gVariableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gVariableBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gVariableBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gVariableBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TabPage Ethernet;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.BindingSource gVariableBindingSource;
        private System.Windows.Forms.BindingSource configDlgBindingSource;
        private System.Windows.Forms.BindingSource gVariableBindingSource1;
        private System.Windows.Forms.TabPage MVB;
        private System.Windows.Forms.TabPage RS485;
        private System.Windows.Forms.DataGridView dvNMPoint;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.BindingSource gVariableBindingSource2;
        private System.Windows.Forms.BindingSource gVariableBindingSource3;
        private System.Windows.Forms.DataGridView dvNEPoint;
        private System.Windows.Forms.DataGridView dvNRPoint;
        private System.Windows.Forms.TabPage Memory;
        private System.Windows.Forms.TabPage DigitalInput;
        private System.Windows.Forms.TabPage SysClock;
        private System.Windows.Forms.DataGridView dvMPoint;
        private System.Windows.Forms.DataGridView dvDIPoint;
        private System.Windows.Forms.DataGridView dvSPoint;
        private System.Windows.Forms.TabPage AnalogInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn portDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipAddressDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn portDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipAddressDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipAddressDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn portDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridView dvAIPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn neAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nePortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmPortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmFCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmSrcSnkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmBitPositionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmBitLengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrBitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrBitLengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diBitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aiAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aiBitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn initialValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn alarmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataTypeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn initialValueDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn alarmDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataTypeDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn initialValueDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn initialValueDataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button buttonConditionEvent;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn initialValueDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn portDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataType;
    }
}

