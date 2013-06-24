using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SqEng;
using SqEng.Internal;
using SqEng.Internal.InstanceBases;
using SqEng.Internal.Animation;

namespace SqDev
{
    public partial class StateEditor : Form
    {   
        #region Variables

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
        public State @State = StaticResources.State;

        public StateEditor()
        {
            InitializeComponent();
        }

        private void StateEditor_Load(object sender, EventArgs e)
        {

        }
    }

    public class DrawPanel : System.Windows.Forms.Panel
    {
        public DrawPanel()
        {
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
        }
    }

}
