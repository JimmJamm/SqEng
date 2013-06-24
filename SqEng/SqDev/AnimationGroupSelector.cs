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
    public partial class AnimationGroupSelector : Form
    {

        #region functions

        public void RefreshItems()
        {
            lboAGroups.Items.Clear();
            foreach(DirectoryInfo di in (new DirectoryInfo("data/animationgroups")).GetDirectories())
            {
                lboAGroups.Items.Add(di.Name);
            }
        }

        #endregion

        public AnimationGroupSelector()
        {
            if (!Directory.Exists("data/animationgroups"))
            {
                Directory.CreateDirectory("data/animationgroups");
                MessageBox.Show("data/animationgroups directory created.");
            }
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            string path = Microsoft.VisualBasic.Interaction.InputBox("Name: ");
            AnimationGroup tmpAGroup = new AnimationGroup() { BasePath = path };
            File.WriteAllText("data/animationgroups/" + path + "/data.xml", tmpAGroup.ToXml());
            
        }
    }
}
