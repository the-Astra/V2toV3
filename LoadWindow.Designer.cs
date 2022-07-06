
namespace Heck_V2toV3
{
    partial class LoadWindow
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
            this.loadText = new System.Windows.Forms.Label();
            this.loadBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // loadText
            // 
            this.loadText.Dock = System.Windows.Forms.DockStyle.Top;
            this.loadText.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loadText.Location = new System.Drawing.Point(0, 0);
            this.loadText.Name = "loadText";
            this.loadText.Size = new System.Drawing.Size(800, 36);
            this.loadText.TabIndex = 0;
            this.loadText.Text = "label1";
            this.loadText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // loadBar
            // 
            this.loadBar.Location = new System.Drawing.Point(13, 55);
            this.loadBar.Name = "loadBar";
            this.loadBar.Size = new System.Drawing.Size(775, 25);
            this.loadBar.TabIndex = 1;
            // 
            // LoadWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 92);
            this.Controls.Add(this.loadBar);
            this.Controls.Add(this.loadText);
            this.Name = "LoadWindow";
            this.Text = "Loading...";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label loadText;
        private System.Windows.Forms.ProgressBar loadBar;
    }
}