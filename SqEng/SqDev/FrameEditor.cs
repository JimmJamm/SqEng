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
        public void FrameToControls()
        {
            txtW.Text = frame.W.ToString();
            txtH.Text = frame.H.ToString();
            txtX.Text = frame.X.ToString();
            txtY.Text = frame.Y.ToString();
        }

        public void ControlsToFrame()
        {
            try
            {
                frame.X = Convert.ToInt32(txtX.Text);
                frame.Y = Convert.ToInt32(txtY.Text);
                frame.W = Convert.ToInt32(txtW.Text);
                frame.H = Convert.ToInt32(txtH.Text);
            }
            catch (Exception ex)
            {
                //get rid of annoying warning
                (ex.Message).ToString();
                MessageBox.Show("Invalid value entered.");
            }
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
            
        }

        private void FrameEditor_Load(object sender, EventArgs e)
        {

        }

        int mouseX, mouseY;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (@MouseButtons == MouseButtons.Left)
            {
                
            }
            if (@MouseButtons == MouseButtons.Right)
            {

            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ControlsToFrame();
            File.WriteAllText("data/frames/" + frame.Name + "/data.xml", frame.ToXml());
            MessageBox.Show("Saved.");
        }
    }
}
