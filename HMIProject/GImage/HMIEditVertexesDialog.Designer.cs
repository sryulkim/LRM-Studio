namespace HMIProject
{
    partial class HMIEditVertexesDialog
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
            this.vertexesDataGridView = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.vertexBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.xDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.vertexesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vertexBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // vertexesDataGridView
            // 
            this.vertexesDataGridView.AutoGenerateColumns = false;
            this.vertexesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vertexesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xDataGridViewTextBoxColumn,
            this.yDataGridViewTextBoxColumn,
            this.scale});
            this.vertexesDataGridView.DataSource = this.vertexBindingSource;
            this.vertexesDataGridView.Location = new System.Drawing.Point(26, 22);
            this.vertexesDataGridView.Name = "vertexesDataGridView";
            this.vertexesDataGridView.RowTemplate.Height = 23;
            this.vertexesDataGridView.Size = new System.Drawing.Size(344, 303);
            this.vertexesDataGridView.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(126, 341);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "추가";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(211, 341);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "삭제";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(295, 341);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "닫기";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // vertexBindingSource
            // 
            this.vertexBindingSource.DataSource = typeof(HMIProject.vertex);
            // 
            // xDataGridViewTextBoxColumn
            // 
            this.xDataGridViewTextBoxColumn.DataPropertyName = "x";
            this.xDataGridViewTextBoxColumn.HeaderText = "X Point";
            this.xDataGridViewTextBoxColumn.Name = "xDataGridViewTextBoxColumn";
            // 
            // yDataGridViewTextBoxColumn
            // 
            this.yDataGridViewTextBoxColumn.DataPropertyName = "y";
            this.yDataGridViewTextBoxColumn.HeaderText = "Y Point";
            this.yDataGridViewTextBoxColumn.Name = "yDataGridViewTextBoxColumn";
            // 
            // scale
            // 
            this.scale.DataPropertyName = "scale";
            this.scale.HeaderText = "Scale";
            this.scale.Name = "scale";
            // 
            // HMIEditVertexesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 387);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.vertexesDataGridView);
            this.Name = "HMIEditVertexesDialog";
            this.Text = "HMIEditVertexesDialog";
            this.Load += new System.EventHandler(this.HMIEditVertexesDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vertexesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vertexBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public  System.Windows.Forms.DataGridView vertexesDataGridView;
        private System.Windows.Forms.BindingSource vertexBindingSource;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn xDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scale;
    }
}