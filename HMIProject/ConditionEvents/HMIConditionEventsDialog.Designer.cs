namespace HMIProject
{
    partial class HMIConditionEventsDialog
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
            this.conditionEventsDataGridView = new System.Windows.Forms.DataGridView();
            this.statementDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gUIOTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.propertyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conditionEventBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.conditionEventsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conditionEventBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // conditionEventsDataGridView
            // 
            this.conditionEventsDataGridView.AutoGenerateColumns = false;
            this.conditionEventsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.conditionEventsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statementDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.gNameDataGridViewTextBoxColumn,
            this.gUIOTypeDataGridViewTextBoxColumn,
            this.propertyDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.conditionEventsDataGridView.DataSource = this.conditionEventBindingSource;
            this.conditionEventsDataGridView.Location = new System.Drawing.Point(12, 24);
            this.conditionEventsDataGridView.Name = "conditionEventsDataGridView";
            this.conditionEventsDataGridView.RowTemplate.Height = 23;
            this.conditionEventsDataGridView.Size = new System.Drawing.Size(643, 352);
            this.conditionEventsDataGridView.TabIndex = 0;
            // 
            // statementDataGridViewTextBoxColumn
            // 
            this.statementDataGridViewTextBoxColumn.DataPropertyName = "statement";
            this.statementDataGridViewTextBoxColumn.HeaderText = "조건식";
            this.statementDataGridViewTextBoxColumn.Name = "statementDataGridViewTextBoxColumn";
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "이벤트 타입";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            // 
            // gNameDataGridViewTextBoxColumn
            // 
            this.gNameDataGridViewTextBoxColumn.DataPropertyName = "gName";
            this.gNameDataGridViewTextBoxColumn.HeaderText = "G-Name";
            this.gNameDataGridViewTextBoxColumn.Name = "gNameDataGridViewTextBoxColumn";
            // 
            // gUIOTypeDataGridViewTextBoxColumn
            // 
            this.gUIOTypeDataGridViewTextBoxColumn.DataPropertyName = "GUIOType";
            this.gUIOTypeDataGridViewTextBoxColumn.HeaderText = "GUIO 타입";
            this.gUIOTypeDataGridViewTextBoxColumn.Name = "gUIOTypeDataGridViewTextBoxColumn";
            // 
            // propertyDataGridViewTextBoxColumn
            // 
            this.propertyDataGridViewTextBoxColumn.DataPropertyName = "property";
            this.propertyDataGridViewTextBoxColumn.HeaderText = "속성";
            this.propertyDataGridViewTextBoxColumn.Name = "propertyDataGridViewTextBoxColumn";
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "값";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            // 
            // conditionEventBindingSource
            // 
            this.conditionEventBindingSource.DataSource = typeof(HMIProject.ConditionEvent);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(362, 382);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "추가";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(472, 382);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "삭제";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(580, 382);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "닫기";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // HMIConditionEventsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 417);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.conditionEventsDataGridView);
            this.Name = "HMIConditionEventsDialog";
            this.Text = "Condition Events";
            this.Load += new System.EventHandler(this.HMIConditionEventsDialog_Load);
            this.SizeChanged += new System.EventHandler(this.HMIConditionEventsDialog_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.conditionEventsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conditionEventBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView conditionEventsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn statementDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gUIOTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn propertyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource conditionEventBindingSource;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button closeButton;
    }
}