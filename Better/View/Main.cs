using Better.Controller;
using Better.View.Pages;
using System;
using System.Windows.Forms;

namespace Better
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        #region DropShadow
        private const int CS_DROPSHADOW = 0x20000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        #endregion

        //Window Actions
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ButtonMaximize_Click(object sender, EventArgs e)
        {
            new WindowStyle().Maximize(this);
        }
        private void ButtonMinimize_Click(object sender, EventArgs e)
        {
            new WindowStyle().Minimize(this);
        }
        //Side Menu Actions
        private void ButtonMode_Click(object sender, EventArgs e)
        {
            new Mode().ChangeMode(Controls,ButtonMode);
        }
        private void WindowHeaderTableLayoutPanel_MouseDown(object sender, MouseEventArgs e)
        {
            new WindowStyle().HoldAndMove(this);
        }
        private void ButtonHomePage_Click(object sender, EventArgs e)
        {
            new PageChange().Change(this, new Home(), PanelContent);
        }
    }
}
