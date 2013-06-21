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
    public partial class FrameSelector : Form
    {
        private Dictionary<string, Frame> frames;
        public Dictionary<string, Frame> Frames
        {
            get
            {
                if (frames == null)
                    RefreshItems();
                return frames;
            }
        }

        public FrameSelector()
        {
            InitializeComponent();
        }

        private void FrameSelector_Load(object sender, EventArgs e)
        {
            RefreshItems();
            foreach (Control ctrl in Controls)
            {
                ctrl.KeyPress += FrameSelector_KeyPress;
            }
        }

        public void RefreshItems()
        {
            if (!Directory.Exists("data/frames"))
            {
                Directory.CreateDirectory("data/frames");
                MessageBox.Show("Folder data/frames did not exist at instantiation. It has now been created.");
            }

            frames = new Dictionary<string, Frame>();
            lboFrames.Items.Clear();
            foreach (DirectoryInfo di in (new DirectoryInfo("data/frames")).GetDirectories())
            {
                frames[di.Name] = new Frame(di.Name);
                lboFrames.Items.Add(di.Name);
            }
        }

        private void FrameSelector_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void lboFrames_DoubleClick(object sender, EventArgs e)
        {
            (new FrameEditor() { Frame = new Frame(lboFrames.SelectedItem.ToString()) }).Show();
        }
    }
}
