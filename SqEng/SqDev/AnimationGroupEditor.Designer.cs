namespace SqDev
{
    partial class AnimationGroupEditor
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
            this.lboAvailableAnimations = new System.Windows.Forms.ListBox();
            this.lboMyAnimations = new System.Windows.Forms.ListBox();
            this.lblRate = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lboAvailableAnimations
            // 
            this.lboAvailableAnimations.FormattingEnabled = true;
            this.lboAvailableAnimations.Location = new System.Drawing.Point(346, 10);
            this.lboAvailableAnimations.Name = "lboAvailableAnimations";
            this.lboAvailableAnimations.Size = new System.Drawing.Size(120, 394);
            this.lboAvailableAnimations.TabIndex = 0;
            this.lboAvailableAnimations.DoubleClick += new System.EventHandler(this.lboAvailableAnimations_DoubleClick);
            // 
            // lboMyAnimations
            // 
            this.lboMyAnimations.FormattingEnabled = true;
            this.lboMyAnimations.Location = new System.Drawing.Point(220, 10);
            this.lboMyAnimations.Name = "lboMyAnimations";
            this.lboMyAnimations.Size = new System.Drawing.Size(120, 394);
            this.lboMyAnimations.TabIndex = 1;
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(13, 13);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(30, 13);
            this.lblRate.TabIndex = 2;
            this.lblRate.Text = "Rate";
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(54, 10);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(100, 20);
            this.txtRate.TabIndex = 3;
            this.txtRate.Leave += new System.EventHandler(this.txtRate_Leave);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 380);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AnimationGroupEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 417);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.lboMyAnimations);
            this.Controls.Add(this.lboAvailableAnimations);
            this.Name = "AnimationGroupEditor";
            this.Text = "AnimationGroupEditor";
            this.Load += new System.EventHandler(this.AnimationGroupEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lboAvailableAnimations;
        private System.Windows.Forms.ListBox lboMyAnimations;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Button btnSave;
    }
}