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
            foreach (FileInfo fi in (new DirectoryInfo("data/animations").GetFiles()))
            {

            }
        }

        private void AnimationSelector_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists("data/animations"))
            {
                Directory.CreateDirectory("data/animations");
                MessageBox.Show("Directory data/animations created.");
            }
        }
    }
}
