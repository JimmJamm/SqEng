using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using SqEng.Internal.Animation;

namespace SqDev
{

    public partial class FrameEditor : Form
    {
        public FrameEditor(string frameName)
        {
            frame = new Frame(frameName);
            InitializeComponent();
        }

        #region Variables

        private Frame frame;
        public Frame Frame
        {
            get
            {
                return frame;
            }
            set
            {
                frame = value;
            }
        }

        public Bitmap TileSheet;
        public Point TSOffset = new Point(0, 0);

        public Graphics pnlBuffer;
        public Bitmap pnlBmp;

        public Point PtMouseDown = new Point();

        public int Snap
        {
            get
            {
                try
                {
                    return Convert.ToInt32(txtSnap.Text);
                }
                catch (Exception)
                {
                    txtSnap.Text = "16";
                    return Snap;
                }
            }
        }

        public Pen RectPen = new Pen(Brushes.Green, 2.0f);
        public int counter;
        #endregion

        public void FrameToControls()
        {
            txtX.Text = frame.X.ToString();
            txtY.Text = frame.Y.ToString();
            txtW.Text = frame.W.ToString();
            txtH.Text = frame.H.ToString();

            if (frame.TileSheet != null)
            {
                TileSheet = new Bitmap("data/tilesheets/" + frame.TileSheet);
            }

            pnlTileSheet.Invalidate();
        }

        private void FrameEditor_Load(object sender, EventArgs e)
        {
            this.SetStyle(
                ControlStyles.OptimizedDoubleBuffer,
                true
            );

            pnlBmp = new Bitmap(pnlTileSheet.Width, pnlTileSheet.Height);
            pnlBuffer = Graphics.FromImage(pnlBmp);

            FrameToControls();

            foreach (FileInfo fi in (new DirectoryInfo("data/tilesheets")).GetFiles())
            {
                lboTilesheets.Items.Add(fi.Name);
            }

            FrameToControls();

            pnlTileSheet.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //base.OnPaint(e);
            if (TileSheet != null)
            {
                pnlBuffer.FillRectangle(Brushes.Green, 0, 0, pnlTileSheet.Width, pnlTileSheet.Height);
                pnlBuffer.DrawImage(TileSheet, TSOffset);
                pnlBuffer.DrawRectangle(
                    RectPen,
                    new Rectangle(
                        TSOffset.X + frame.X,
                        TSOffset.Y + frame.Y,
                        frame.W, frame.H
                    )
                );

                e.Graphics.DrawImage(pnlBmp, new Point(0, 0));
            }
            else
                Text = "nulll";
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            float pctX = ((float)e.X) / pnlTileSheet.Width;
            float pxtY = ((float)e.Y) / pnlTileSheet.Height;

            if (@MouseButtons == MouseButtons.Left)
            {
                frame.W = (e.X - PtMouseDown.X)/Snap * Snap;
                frame.H = (e.Y - PtMouseDown.Y) / Snap * Snap;
            }

            if (@MouseButtons == MouseButtons.Right)
            {
                TSOffset.X = -(int)((pctX) * pnlBmp.Width);
                TSOffset.Y = -(int)((pxtY) * pnlBmp.Height);
            }

            FrameToControls();

            pnlTileSheet.Invalidate();
        }

        private void pnlTileSheet_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                frame.X = (e.X - TSOffset.X) / Snap * Snap;
                frame.Y = (e.Y - TSOffset.Y) / Snap * Snap;

                PtMouseDown = new Point(e.X, e.Y);
            }
        }

        private void tmrUpdateBrush_Tick(object sender, EventArgs e)
        {
            unchecked
            {
                RectPen = new Pen(Color.FromArgb(counter % 255, (counter / 2) % 255, (counter / 4) % 255), 2.0f);
                counter++;
            }
        }

        private void lboTilesheets_DoubleClick(object sender, EventArgs e)
        {
            if (lboTilesheets.SelectedItem != null)
            {
                frame.TileSheet = lboTilesheets.SelectedItem.ToString();
                FrameToControls();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            File.WriteAllText("data/frames/" + frame.Name + " /data.xml", frame.ToXml());
        }

        private void pnlTileSheet_Resize(object sender, EventArgs e)
        {
            if (pnlBuffer != null)
                pnlBuffer.Dispose();
            if (pnlTileSheet.Width > 0 && pnlTileSheet.Height > 0)
            {
                pnlBmp = new Bitmap(pnlTileSheet.Width, pnlTileSheet.Height);
                pnlBuffer = Graphics.FromImage(pnlBmp);
            }
        }
    }

    public class MyPanel : System.Windows.Forms.Panel
    {
        public MyPanel()
        {
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
        }
    }

}
