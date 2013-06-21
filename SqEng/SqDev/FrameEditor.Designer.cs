namespace SqDev
{
    partial class FrameEditor
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
            this.lboTilesheets = new System.Windows.Forms.ListBox();
            this.pboFull = new System.Windows.Forms.PictureBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtH = new System.Windows.Forms.TextBox();
            this.txtW = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pboFull)).BeginInit();
            this.SuspendLayout();
            // 
            // lboTilesheets
            // 
            this.lboTilesheets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lboTilesheets.FormattingEnabled = true;
            this.lboTilesheets.Location = new System.Drawing.Point(752, 54);
            this.lboTilesheets.Name = "lboTilesheets";
            this.lboTilesheets.Size = new System.Drawing.Size(150, 459);
            this.lboTilesheets.TabIndex = 2;
            // 
            // pboFull
            // 
            this.pboFull.Location = new System.Drawing.Point(13, 142);
            this.pboFull.Name = "pboFull";
            this.pboFull.Size = new System.Drawing.Size(733, 371);
            this.pboFull.TabIndex = 3;
            this.pboFull.TabStop = false;
            this.pboFull.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pboFull.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(13, 15);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(99, 20);
            this.txtX.TabIndex = 4;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(13, 41);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(99, 20);
            this.txtY.TabIndex = 5;
            // 
            // txtH
            // 
            this.txtH.Location = new System.Drawing.Point(13, 93);
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(99, 20);
            this.txtH.TabIndex = 7;
            // 
            // txtW
            // 
            this.txtW.Location = new System.Drawing.Point(13, 67);
            this.txtW.Name = "txtW";
            this.txtW.Size = new System.Drawing.Size(99, 20);
            this.txtW.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(752, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrameEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 530);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtH);
            this.Controls.Add(this.txtW);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.pboFull);
            this.Controls.Add(this.lboTilesheets);
            this.Name = "FrameEditor";
            this.Text = "FrameEditor";
            this.Load += new System.EventHandler(this.FrameEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboFull)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lboTilesheets;
        private System.Windows.Forms.PictureBox pboFull;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.TextBox txtW;
        private System.Windows.Forms.Button btnSave;
    }
}