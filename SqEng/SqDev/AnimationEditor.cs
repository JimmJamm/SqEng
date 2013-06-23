using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SqEng.Internal.Animation;
using System.IO;

namespace SqDev
{
    public partial class AnimationEditor : Form
    {
        #region variables

        public Animation Animation;

        public Graphics pnlBuffer;
        public Bitmap pnlBmp;

        public DateTime LastTick;

        #endregion

        public void RefreshBaseFrames()
        {
            lboBaseFrames.Items.Clear();
            foreach(DirectoryInfo di in (new DirectoryInfo("data/frames").GetDirectories()))
            {
                lboBaseFrames.Items.Add(di.Name);
            }
        }

        public void AnimationToControls()
        {
            lboMyFrames.Items.Clear();
            foreach (Frame f in @Animation.Frames)
            {
                lboMyFrames.Items.Add(f.BasePath);
            }

            txtName.Text = @Animation.Name;
            txtRate.Text = @Animation.Rate.ToString();
            txtStart.Text = @Animation.Start.ToString();
        }

        public AnimationEditor(string path)
        {
            Animation = new Animation(path);
            InitializeComponent();
        }

        private void AnimationEditor_Load(object sender, EventArgs e)
        {
            AnimationToControls();
            RefreshBaseFrames();
            bufferInit();
            tmrAnimate.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tmrAnimate_Tick(object sender, EventArgs e)
        {
            SqEng.Internal.Execution.DeltaTimeMS = (DateTime.Now - LastTick).TotalMilliseconds;
            @Animation.Tick();
            pnlCurrentFrame.Invalidate();
            LastTick = DateTime.Now;

            Text = SqEng.Internal.Execution.DeltaTimeMS.ToString();
        }

        private void pnlCurrentFrame_Paint(object sender, PaintEventArgs e)
        {
            return;
            if (lboMyFrames.Items.Count > 0)
            {
                try
                {
                    Frame f = @Animation.Frames[@Animation.Index];
                    Image tmpImage = Image.FromFile("data/tilesheets/" + f.TileSheet);
                    Rectangle sourceRect = new Rectangle(f.X, f.Y, f.W, f.H);
                    Rectangle destRect = new Rectangle(0, 0, f.W, f.H);

                    pnlBuffer.FillRectangle(Brushes.Blue, 0, 0, pnlCurrentFrame.Width, pnlCurrentFrame.Height);
                    pnlBuffer.DrawImage(tmpImage, destRect, sourceRect, GraphicsUnit.Pixel);

                    tmpImage.Dispose();
                }
                catch (Exception ex)
                {
                    Text = ex.Message;
                }
            }
            else
            {
                //Text = "0...";
            }
        }

        private void lboBaseFrames_DoubleClick(object sender, EventArgs e)
        {
            if (lboBaseFrames.SelectedItem != null)
            {
                @Animation.Frames.Add(new Frame(lboBaseFrames.SelectedItem.ToString()));
                AnimationToControls();
            }
        }

        private void lboMyFrames_DoubleClick(object sender, EventArgs e)
        {
            if (lboMyFrames.SelectedItem != null)
            {
                @Animation.Frames.RemoveAt(lboMyFrames.SelectedIndex);
                AnimationToControls();
            }
        }

        private void bufferInit()
        {
            if (pnlBmp != null)
                pnlBmp.Dispose();
            if (pnlBuffer != null)
                pnlBuffer.Dispose();

            pnlBmp = new Bitmap(pnlCurrentFrame.Width, pnlCurrentFrame.Height);
            pnlBuffer = Graphics.FromImage(pnlBmp);
        }

        private void pnlCurrentFrame_Resize(object sender, EventArgs e)
        {
            bufferInit();
        }
    }
}
