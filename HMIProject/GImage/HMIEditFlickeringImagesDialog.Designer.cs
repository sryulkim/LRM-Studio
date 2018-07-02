namespace HMIProject
{
    partial class HMIEditFlickeringImagesDialog
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
            this.flickeringImagesDataGridView = new System.Windows.Forms.DataGridView();
            this.imageNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flickeringImageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.flickeringImagesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flickeringImageBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // flickeringImagesDataGridView
            // 
            this.flickeringImagesDataGridView.AutoGenerateColumns = false;
            this.flickeringImagesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.flickeringImagesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.imageNameDataGridViewTextBoxColumn});
            this.flickeringImagesDataGridView.DataSource = this.flickeringImageBindingSource;
            this.flickeringImagesDataGridView.Location = new System.Drawing.Point(13, 13);
            this.flickeringImagesDataGridView.Name = "flickeringImagesDataGridView";
            this.flickeringImagesDataGridView.Size = new System.Drawing.Size(343, 301);
            this.flickeringImagesDataGridView.TabIndex = 0;
            // 
            // imageNameDataGridViewTextBoxColumn
            // 
            this.imageNameDataGridViewTextBoxColumn.DataPropertyName = "imageName";
            this.imageNameDataGridViewTextBoxColumn.HeaderText = "Image Name";
            this.imageNameDataGridViewTextBoxColumn.Name = "imageNameDataGridViewTextBoxColumn";
            this.imageNameDataGridViewTextBoxColumn.Width = 300;
            // 
            // flickeringImageBindingSource
            // 
            this.flickeringImageBindingSource.DataSource = typeof(HMIProject.flickeringImage);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(119, 340);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "추가";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(200, 340);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "삭제";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(281, 340);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "닫기";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // HMIEditFlickeringImagesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 395);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.flickeringImagesDataGridView);
            this.Name = "HMIEditFlickeringImagesDialog";
            this.Text = "HMIEditFlickeringImagesDialog";
            this.Load += new System.EventHandler(this.HMIEditFlickeringImagesDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flickeringImagesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flickeringImageBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public  System.Windows.Forms.DataGridView flickeringImagesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource flickeringImageBindingSource;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button closeButton;
    }
}