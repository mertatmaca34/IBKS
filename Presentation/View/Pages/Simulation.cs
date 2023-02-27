using Presentation.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;
using static Presentation.View.Pages.Simulation;

namespace Presentation.View.Pages
{
    public partial class Simulation : Form
    {
        Bitmap havuzSuyu1 = new Bitmap(Resources.HavuzSuyu1);
        Bitmap havuzSuyu2 = new Bitmap(Resources.HavuzSuyu2);
        Bitmap TupAtiksiDolu1 = new Bitmap(Resources.TupAtiksiDolu1);
        Bitmap TupAtiksiDolu2 = new Bitmap(Resources.TupAtiksiDolu2);

        PanelDoubleBuffered PanelHavuzSuyu = new PanelDoubleBuffered();
        PanelDoubleBuffered PanelTup = new PanelDoubleBuffered();

        public class PanelDoubleBuffered : System.Windows.Forms.Panel
        {
            public PanelDoubleBuffered()
                : base()
            {
                this.DoubleBuffered = true;
            }
        }

        public Simulation()
        {
            InitializeComponent();
        }

        private void Simulation_Load(object sender, EventArgs e)
        {
            NewPanelDoubleBuffered(PanelHavuzSuyu, new Point(96, 352), Color.Transparent, havuzSuyu1, true);
            panel1.Controls.Add(PanelHavuzSuyu);

            NewPanelDoubleBuffered(PanelTup, new Point(632, 78), Color.Transparent, TupAtiksiDolu1, true);
            panel1.Controls.Add(PanelTup);

        }

        private void NewPanelDoubleBuffered(PanelDoubleBuffered panel, Point location, Color color, Bitmap bgImage, bool visible)
        {
            panel.Location = location;
            panel.Size = new Size(bgImage.Width, bgImage.Height);
            panel.BackColor = color;
            panel.BackgroundImage = bgImage;
            panel.Visible = visible;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (PanelHavuzSuyu.BackgroundImage == havuzSuyu1)
            {
                PanelHavuzSuyu.BackgroundImage = havuzSuyu2;
            }
            else if (PanelHavuzSuyu.BackgroundImage == havuzSuyu2)
            {
                PanelHavuzSuyu.BackgroundImage = havuzSuyu1;
            }
        }

        private void CheckNextFrame()
        {

        }

    }
}
