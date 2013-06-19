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
        
        private List<Image> tilesheets;
        public List<Image> Tilesheets
        {
            get
            {
                if (tilesheets == null)
                {
                    RefreshItems();
                }
                return tilesheets;
            }
        }

        private List<Frame> frames;
        public List<Frame> Frames
        {
            get
            {
                if (frames == null)
                    RefreshItems();
                return frames;
            }
        }

        public Frame CurrentFrame;

        public FrameEditor()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frame f = new Frame();
            string name = Microsoft.VisualBasic.Interaction.InputBox("Name: ");
            try { System.IO.Directory.CreateDirectory("data/frames/" + name); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            File.WriteAllText("data/frames/" + name + "/data.xml", f.ToXml());
            Refresh();
        }

        //do not use
        private void discardChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void discardChangesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void RefreshItems()
        {
            if (!Directory.Exists("data/frames"))
            {
                Directory.CreateDirectory("data/frames");
                MessageBox.Show("Folder data/frames did not exist at instantiation. It has now been created.");
            }

            tilesheets = new List<Image>();
            lboTilesheets.Items.Clear();
            foreach (FileInfo fi in (new DirectoryInfo("data/tilesheets")).GetFiles())
            {
                tilesheets.Add(new Bitmap(fi.FullName));
                lboTilesheets.Items.Add(fi.Name);
            }

            frames = new List<Frame>();
            lboFrames.Items.Clear();
            foreach (DirectoryInfo di in (new DirectoryInfo("data/frames")).GetDirectories())
            {
                frames.Add(new Frame(di.Name));
                lboFrames.Items.Add(di.Name);
            }

            
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FrameEditor_Load(object sender, EventArgs e)
        {
            RefreshItems();
        }
    }
}
