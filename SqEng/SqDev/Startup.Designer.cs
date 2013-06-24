namespace SqDev
{
    partial class Startup
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
            this.btnRun = new System.Windows.Forms.Button();
            this.btnPublish = new System.Windows.Forms.Button();
            this.btnCompile = new System.Windows.Forms.Button();
            this.btnFrameEditor = new System.Windows.Forms.Button();
            this.btnAnimationEdtior = new System.Windows.Forms.Button();
            this.btnAnimationGroupEditor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(13, 13);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run Game";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // btnPublish
            // 
            this.btnPublish.Location = new System.Drawing.Point(13, 71);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(75, 23);
            this.btnPublish.TabIndex = 2;
            this.btnPublish.Text = "Publish";
            this.btnPublish.UseVisualStyleBackColor = true;
            // 
            // btnCompile
            // 
            this.btnCompile.Location = new System.Drawing.Point(13, 42);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(75, 23);
            this.btnCompile.TabIndex = 1;
            this.btnCompile.Text = "Compile";
            this.btnCompile.UseVisualStyleBackColor = true;
            // 
            // btnFrameEditor
            // 
            this.btnFrameEditor.Location = new System.Drawing.Point(145, 13);
            this.btnFrameEditor.Name = "btnFrameEditor";
            this.btnFrameEditor.Size = new System.Drawing.Size(127, 23);
            this.btnFrameEditor.TabIndex = 3;
            this.btnFrameEditor.Text = "Frame Editor";
            this.btnFrameEditor.UseVisualStyleBackColor = true;
            this.btnFrameEditor.Click += new System.EventHandler(this.btnFrameEditor_Click);
            // 
            // btnAnimationEdtior
            // 
            this.btnAnimationEdtior.Location = new System.Drawing.Point(145, 42);
            this.btnAnimationEdtior.Name = "btnAnimationEdtior";
            this.btnAnimationEdtior.Size = new System.Drawing.Size(127, 23);
            this.btnAnimationEdtior.TabIndex = 4;
            this.btnAnimationEdtior.Text = "Animation Editor";
            this.btnAnimationEdtior.UseVisualStyleBackColor = true;
            this.btnAnimationEdtior.Click += new System.EventHandler(this.btnAnimationEdtior_Click);
            // 
            // btnAnimationGroupEditor
            // 
            this.btnAnimationGroupEditor.Location = new System.Drawing.Point(145, 71);
            this.btnAnimationGroupEditor.Name = "btnAnimationGroupEditor";
            this.btnAnimationGroupEditor.Size = new System.Drawing.Size(127, 23);
            this.btnAnimationGroupEditor.TabIndex = 5;
            this.btnAnimationGroupEditor.Text = "AnimationGroup Editor";
            this.btnAnimationGroupEditor.UseVisualStyleBackColor = true;
            this.btnAnimationGroupEditor.Click += new System.EventHandler(this.btnAnimationGroupEditor_Click);
            // 
            // Startup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnAnimationGroupEditor);
            this.Controls.Add(this.btnAnimationEdtior);
            this.Controls.Add(this.btnFrameEditor);
            this.Controls.Add(this.btnCompile);
            this.Controls.Add(this.btnPublish);
            this.Controls.Add(this.btnRun);
            this.Name = "Startup";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.Button btnCompile;
        private System.Windows.Forms.Button btnFrameEditor;
        private System.Windows.Forms.Button btnAnimationEdtior;
        private System.Windows.Forms.Button btnAnimationGroupEditor;
    }
}

