using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private const int CS_DropShadow = 0x00020000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DropShadow;
                return cp;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanelMain_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {

        }
    }
}
