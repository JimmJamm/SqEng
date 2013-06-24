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
    public partial class AnimationGroupEditor : Form
    {
        #region variables
        public AnimationGroup AGroup;

        #endregion

        #region functions

        public void AGToControls()
        {
            lboMyAnimations.Items.Clear();

            foreach (string n in AGroup.Animations.Keys)
            {
                lboMyAnimations.Items.Add(n + " : " + AGroup.Animations[n].BasePath);
            }

            txtRate.Text = AGroup.Rate.ToString();
        }

        public void RefreshItems()
        {
            lboAvailableAnimations.Items.Clear();
            foreach (DirectoryInfo di in (new DirectoryInfo("data/animationgroups")).GetDirectories())
            {
                lboAvailableAnimations.Items.Add(di.Name);
            }
        }

        #endregion

        public AnimationGroupEditor(string path)
        {
            AGroup = new AnimationGroup(path);
            InitializeComponent();
        }


        private void AnimationGroupEditor_Load(object sender, EventArgs e)
        {
            AGToControls();
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {

        }

        private void lboAvailableAnimations_DoubleClick(object sender, EventArgs e)
        {
            if (lboAvailableAnimations.SelectedItem == null)
            {
                MessageBox.Show("Select an item!");
                return;
            }

            string name = Microsoft.VisualBasic.Interaction.InputBox("Name: ");
            AGroup.Animations[name] =
                new Animation(lboAvailableAnimations.SelectedItem.ToString());

            AGToControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            File.WriteAllText("data/animationgroups/" + AGroup.BasePath + "/data.xml", AGroup.ToXml());
        }

    }
}
