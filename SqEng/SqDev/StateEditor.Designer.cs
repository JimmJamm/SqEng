namespace SqDev
{
    partial class StateEditor
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
            this.pnlState = new SqDev.DrawPanel();
            this.txtSnap = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pnlState
            // 
            this.pnlState.Location = new System.Drawing.Point(4, 0);
            this.pnlState.Name = "pnlState";
            this.pnlState.Size = new System.Drawing.Size(800, 600);
            this.pnlState.TabIndex = 0;
            // 
            // txtSnap
            // 
            this.txtSnap.Location = new System.Drawing.Point(811, 13);
            this.txtSnap.Name = "txtSnap";
            this.txtSnap.Size = new System.Drawing.Size(100, 20);
            this.txtSnap.TabIndex = 1;
            // 
            // StateEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 761);
            this.Controls.Add(this.txtSnap);
            this.Controls.Add(this.pnlState);
            this.Name = "StateEditor";
            this.Text = "StateEditor";
            this.Load += new System.EventHandler(this.StateEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DrawPanel pnlState;
        private System.Windows.Forms.TextBox txtSnap;
    }
}