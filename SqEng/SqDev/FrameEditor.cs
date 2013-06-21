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
using Microsoft.VisualBasic;

namespace SqDev
{
    public partial class FrameEditor : Form
    {
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
                    return 8;
                }
            }
        }

        public void FrameToControls()
        {
            txtW.Text = frame.W.ToString();
            txtH.Text = frame.H.ToString();
            txtX.Text = frame.X.ToString();
            txtY.Text = frame.Y.ToString();
            pboFull.Invalidate();
        }

        public void ControlsToFrame()
        {
            frame.X = Convert.ToInt32(txtX.Text);
            frame.Y = Convert.ToInt32(txtY.Text);
            frame.W = Convert.ToInt32(txtW.Text);
            frame.H = Convert.ToInt32(txtH.Text);
        }

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
                RefreshItems();
            }
        }

        private Dictionary<string, Image> tilesheets;
        public Dictionary<string, Image> TileSheets
        {
            get
            {
                if (tilesheets == null)
                    RefreshItems();
                return tilesheets;
            }
        }


        public FrameEditor()
        {
            InitializeComponent();
        }

        private void RefreshItems()
        {
            tilesheets = new Dictionary<string, Image>();
            lboTilesheets.Items.Clear();
            foreach (FileInfo fi in (new DirectoryInfo("data/tilesheets")).GetFiles())
            {
                tilesheets[fi.Name] = new Bitmap(fi.FullName);
                lboTilesheets.Items.Add(fi.Name);
            }
            FrameToControls();
            if (frame.TileSheet != null)
            {
                pboFull.Image = new Bitmap("data/tilesheets/" + frame.TileSheet);
            }
        }

        private void FrameEditor_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (@MouseButtons == MouseButtons.Left)
            {
                frame.W = e.X - frame.X;
                frame.H = e.Y - frame.Y;
                FrameToControls();
            }
            if (@MouseButtons == MouseButtons.Right)
            {
                
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            frame.X = e.X;
            frame.Y = e.Y;

            this.Text = e.X + " " + e.Y;

            //Extremely bizarre behavior. If I try to use frame.X and frame.Y from the picture box's paint method, I get the correct X but old Y.
            //So I'm just using this for now since it works but the frame object doesn't. 
            xtest = frame.X;
            ytest = frame.Y;

            xtest = ((int)(xtest/Snap)) * Snap;
            ytest = ((int)(xtest/Snap)) * Snap;

            FrameToControls();
        }

        int xtest, ytest;

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ControlsToFrame();
                File.WriteAllText("data/frames/" + frame.Name + "/data.xml", frame.ToXml());
                MessageBox.Show("Saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lboTilesheets_DoubleClick(object sender, EventArgs e)
        {
            if (lboTilesheets.SelectedItem != null)
            {
                frame.TileSheet = lboTilesheets.SelectedItem.ToString();
            }
            RefreshItems();
        }
        public Graphics gfx;
        private void tmrDraw_Tick(object sender, EventArgs e)
        {

        }

        private void pboFull_Paint(object sender, PaintEventArgs e)
        {
            if (pboFull.Image != null &&
                frame != null &&
                frame.W > 0 &&
                frame.H > 0
            )
            {
                gfx = e.Graphics;
                Text = new Point(xtest, ytest).ToString();
                gfx.DrawRectangle(
                    new Pen(Brushes.GreenYellow, 2.0f), 
                    new Rectangle(new Point(xtest, ytest), new Size(frame.W, frame.H))
                );
            }
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ControlsToFrame();
            }
            catch (Exception)
            {
            }
        }
    }
}
