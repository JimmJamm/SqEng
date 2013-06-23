namespace SqDev
{
    partial class AnimationEditor
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
            this.lboBaseFrames = new System.Windows.Forms.ListBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.lboMyFrames = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tmrAnimate = new System.Windows.Forms.Timer(this.components);
            this.pnlCurrentFrame = new SqDev.DrawPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lboBaseFrames
            // 
            this.lboBaseFrames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lboBaseFrames.FormattingEnabled = true;
            this.lboBaseFrames.Location = new System.Drawing.Point(709, 25);
            this.lboBaseFrames.Name = "lboBaseFrames";
            this.lboBaseFrames.Size = new System.Drawing.Size(81, 381);
            this.lboBaseFrames.TabIndex = 0;
            this.lboBaseFrames.DoubleClick += new System.EventHandler(this.lboBaseFrames_DoubleClick);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(53, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(35, 13);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Name";
            // 
            // lboMyFrames
            // 
            this.lboMyFrames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lboMyFrames.FormattingEnabled = true;
            this.lboMyFrames.Location = new System.Drawing.Point(622, 25);
            this.lboMyFrames.Name = "lboMyFrames";
            this.lboMyFrames.Size = new System.Drawing.Size(81, 381);
            this.lboMyFrames.TabIndex = 4;
            this.lboMyFrames.DoubleClick += new System.EventHandler(this.lboMyFrames_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(627, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "This Animation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(717, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Available";
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayPause.Location = new System.Drawing.Point(168, 2);
            this.btnPlayPause.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(52, 33);
            this.btnPlayPause.TabIndex = 7;
            this.btnPlayPause.Text = "⏯";
            this.btnPlayPause.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPlayPause.UseVisualStyleBackColor = true;
            this.btnPlayPause.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(435, 11);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(100, 20);
            this.txtStart.TabIndex = 8;
            this.txtStart.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(400, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Start";
            // 
            // tmrAnimate
            // 
            this.tmrAnimate.Interval = 10;
            this.tmrAnimate.Tick += new System.EventHandler(this.tmrAnimate_Tick);
            // 
            // pnlCurrentFrame
            // 
            this.pnlCurrentFrame.Location = new System.Drawing.Point(12, 38);
            this.pnlCurrentFrame.Name = "pnlCurrentFrame";
            this.pnlCurrentFrame.Size = new System.Drawing.Size(604, 368);
            this.pnlCurrentFrame.TabIndex = 3;
            this.pnlCurrentFrame.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCurrentFrame_Paint);
            this.pnlCurrentFrame.Resize += new System.EventHandler(this.pnlCurrentFrame_Resize);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(541, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Rate";
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(259, 12);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(100, 20);
            this.txtRate.TabIndex = 12;
            this.txtRate.Text = "1";
            // 
            // AnimationEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 414);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.btnPlayPause);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lboMyFrames);
            this.Controls.Add(this.pnlCurrentFrame);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lboBaseFrames);
            this.Name = "AnimationEditor";
            this.Text = "AnimationEditor";
            this.Load += new System.EventHandler(this.AnimationEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lboBaseFrames;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label Label1;
        private DrawPanel pnlCurrentFrame;
        private System.Windows.Forms.ListBox lboMyFrames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer tmrAnimate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRate;
    }
}