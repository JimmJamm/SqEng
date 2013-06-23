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
    public partial class AnimationSelector : Form
    {
        public AnimationSelector()
        {
            InitializeComponent();
        }

        #region variables
        //public List<
        #endregion

        public void RefreshItems()
        {
            lboAnimations.Items.Clear();
            foreach (DirectoryInfo di in (new DirectoryInfo("data/animations").GetDirectories()))
            {
                lboAnimations.Items.Add(di.Name);
            }
        }

        private void AnimationSelector_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists("data/animations"))
            {
                Directory.CreateDirectory("data/animations");
                MessageBox.Show("Directory data/animations created.");
            }
            RefreshItems();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (lboAnimations.SelectedItem == null)
            {
                MessageBox.Show("Select an item!");
                return;
            }
            (new AnimationEditor(lboAnimations.SelectedItem.ToString())).Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshItems();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox("Name: ");
            Directory.CreateDirectory("data/animations/" + name);
            Animation tmpAnimation = new Animation();
            File.WriteAllText("data/animations/" + name + "/data.xml", tmpAnimation.ToXml());
            RefreshItems();
        }
    }
}
