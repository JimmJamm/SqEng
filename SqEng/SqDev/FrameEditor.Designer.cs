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
            this.components = new System.ComponentModel.Container();
            this.lboTilesheets = new System.Windows.Forms.ListBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtH = new System.Windows.Forms.TextBox();
            this.txtW = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSnap = new System.Windows.Forms.TextBox();
            this.tmrUpdateBrush = new System.Windows.Forms.Timer(this.components);
            this.pnlTileSheet = new SqDev.DrawPanel();
            this.SuspendLayout();
            // 
            // lboTilesheets
            // 
            this.lboTilesheets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lboTilesheets.FormattingEnabled = true;
            this.lboTilesheets.Location = new System.Drawing.Point(673, 12);
            this.lboTilesheets.Name = "lboTilesheets";
            this.lboTilesheets.Size = new System.Drawing.Size(120, 342);
            this.lboTilesheets.TabIndex = 0;
            this.lboTilesheets.DoubleClick += new System.EventHandler(this.lboTilesheets_DoubleClick);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(32, 9);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(100, 20);
            this.txtX.TabIndex = 1;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(32, 35);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(100, 20);
            this.txtY.TabIndex = 2;
            // 
            // txtH
            // 
            this.txtH.Location = new System.Drawing.Point(158, 35);
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(100, 20);
            this.txtH.TabIndex = 4;
            // 
            // txtW
            // 
            this.txtW.Location = new System.Drawing.Point(158, 9);
            this.txtW.Name = "txtW";
            this.txtW.Size = new System.Drawing.Size(100, 20);
            this.txtW.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "H";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(138, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "W";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(592, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(331, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Snap:";
            // 
            // txtSnap
            // 
            this.txtSnap.Location = new System.Drawing.Point(372, 9);
            this.txtSnap.Name = "txtSnap";
            this.txtSnap.Size = new System.Drawing.Size(100, 20);
            this.txtSnap.TabIndex = 12;
            this.txtSnap.Text = "16";
            // 
            // tmrUpdateBrush
            // 
            this.tmrUpdateBrush.Enabled = true;
            this.tmrUpdateBrush.Interval = 10;
            this.tmrUpdateBrush.Tick += new System.EventHandler(this.tmrUpdateBrush_Tick);
            // 
            // pnlTileSheet
            // 
            this.pnlTileSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTileSheet.BackColor = System.Drawing.Color.Transparent;
            this.pnlTileSheet.Location = new System.Drawing.Point(15, 61);
            this.pnlTileSheet.Name = "pnlTileSheet";
            this.pnlTileSheet.Size = new System.Drawing.Size(652, 293);
            this.pnlTileSheet.TabIndex = 9;
            this.pnlTileSheet.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.pnlTileSheet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTileSheet_MouseDown);
            this.pnlTileSheet.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.pnlTileSheet.Resize += new System.EventHandler(this.pnlTileSheet_Resize);
            // 
            // FrameEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 360);
            this.Controls.Add(this.txtSnap);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlTileSheet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtH);
            this.Controls.Add(this.txtW);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.lboTilesheets);
            this.Name = "FrameEditor";
            this.Text = "FrameEditor";
            this.Load += new System.EventHandler(this.FrameEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lboTilesheets;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.TextBox txtW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DrawPanel pnlTileSheet;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSnap;
        private System.Windows.Forms.Timer tmrUpdateBrush;
    }
}