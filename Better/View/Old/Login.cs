using System;
using System.Drawing;
using System.Windows.Forms;

namespace Better
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

        private void tableLayoutPanelMain_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            var iskiBlue = new SolidBrush(Color.FromArgb(0, 131, 200));
            var white = new SolidBrush(Color.White);

            e.Graphics.FillRectangle(e.Column == 1 ? iskiBlue : white, e.CellBounds);
        }
    }
}
