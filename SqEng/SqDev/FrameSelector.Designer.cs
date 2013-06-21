namespace SqDev
{
    partial class FrameSelector
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
            this.lboFrames = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lboFrames
            // 
            this.lboFrames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lboFrames.FormattingEnabled = true;
            this.lboFrames.Location = new System.Drawing.Point(12, 51);
            this.lboFrames.Name = "lboFrames";
            this.lboFrames.Size = new System.Drawing.Size(454, 251);
            this.lboFrames.TabIndex = 1;
            this.lboFrames.DoubleClick += new System.EventHandler(this.lboFrames_DoubleClick);
            // 
            // FrameSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 317);
            this.Controls.Add(this.lboFrames);
            this.Name = "FrameSelector";
            this.Text = "FrameSelector";
            this.Load += new System.EventHandler(this.FrameSelector_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrameSelector_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lboFrames;
    }
}