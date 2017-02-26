namespace HMIProject
{
    partial class HMIMakeVertexDialog
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
            this.buttonCancle = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.scaleTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCancle
            // 
            this.buttonCancle.Location = new System.Drawing.Point(402, 52);
            this.buttonCancle.Name = "buttonCancle";
            this.buttonCancle.Size = new System.Drawing.Size(75, 23);
            this.buttonCancle.TabIndex = 15;
            this.buttonCancle.Text = "취소";
            this.buttonCancle.UseVisualStyleBackColor = true;
            this.buttonCancle.Click += new System.EventHandler(this.buttonCancle_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(298, 52);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 14;
            this.buttonConfirm.Text = "확인";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "X Point";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "Y Point";
            // 
            // xTextBox
            // 
            this.xTextBox.Location = new System.Drawing.Point(60, 12);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(100, 21);
            this.xTextBox.TabIndex = 18;
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(220, 12);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(100, 21);
            this.yTextBox.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "Scale";
            // 
            // scaleTextBox
            // 
            this.scaleTextBox.Location = new System.Drawing.Point(377, 12);
            this.scaleTextBox.Name = "scaleTextBox";
            this.scaleTextBox.Size = new System.Drawing.Size(100, 21);
            this.scaleTextBox.TabIndex = 21;
            // 
            // HMIMakeVertexDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 87);
            this.Controls.Add(this.scaleTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yTextBox);
            this.Controls.Add(this.xTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancle);
            this.Controls.Add(this.buttonConfirm);
            this.Name = "HMIMakeVertexDialog";
            this.Text = "HMIMakeVertexDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancle;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox scaleTextBox;
    }
}