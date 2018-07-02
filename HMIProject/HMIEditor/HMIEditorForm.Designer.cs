namespace HMIProject
{
    partial class HMIEditorForm
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
            this.SuspendLayout();
            // 
            // HMIEditorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "HMIEditorForm";
            this.Text = "HMIEditorForm";
            this.Load += new System.EventHandler(this.HMIEditorForm_Load);
            this.SizeChanged += new System.EventHandler(this.HMIEditorForm_SizeChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HMIEditorForm_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion
    }
}