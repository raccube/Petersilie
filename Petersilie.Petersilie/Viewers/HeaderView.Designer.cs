namespace Petersilie.Petersilie.Viewers
{
    partial class HeaderView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.editorVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // editorVersion
            // 
            this.editorVersion.AutoSize = true;
            this.editorVersion.Location = new System.Drawing.Point(13, 10);
            this.editorVersion.Name = "editorVersion";
            this.editorVersion.Size = new System.Drawing.Size(85, 15);
            this.editorVersion.TabIndex = 0;
            this.editorVersion.Text = "Editor Version: ";
            // 
            // HeaderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.editorVersion);
            this.Name = "HeaderView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label editorVersion;
    }
}
