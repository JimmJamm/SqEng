namespace SqDev
{
    partial class AnimationGroupSelector
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
            this.lboAGroups = new System.Windows.Forms.ListBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lboAGroups
            // 
            this.lboAGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lboAGroups.FormattingEnabled = true;
            this.lboAGroups.Location = new System.Drawing.Point(12, 59);
            this.lboAGroups.Name = "lboAGroups";
            this.lboAGroups.Size = new System.Drawing.Size(510, 290);
            this.lboAGroups.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(13, 13);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // AnimationGroupSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 362);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lboAGroups);
            this.Name = "AnimationGroupSelector";
            this.Text = "AnimationGroupSelector";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lboAGroups;
        private System.Windows.Forms.Button btnNew;
    }
}