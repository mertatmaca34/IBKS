using Presentation.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation.View.Pages
{
    public partial class SimulationPage : Form
    {
        readonly Bitmap havuzSuyu1 = new Bitmap(Resources.HavuzSuyu1);
        readonly Bitmap havuzSuyu2 = new Bitmap(Resources.HavuzSuyu2);
        readonly Bitmap tupAtiksiDolu1 = new Bitmap(Resources.TupAtiksiDolu1);
        readonly Bitmap tupAtiksiDolu2 = new Bitmap(Resources.TupAtiksiDolu2);
        readonly Bitmap boruAtiksu1 = new Bitmap(Resources.BoruAtiksu1);
        readonly Bitmap boruAtiksu2 = new Bitmap(Resources.BoruAtiksu2);

        readonly PanelDoubleBuffered PanelHavuzSuyu = new PanelDoubleBuffered();
        readonly PanelDoubleBuffered PanelTup = new PanelDoubleBuffered();
        readonly PanelDoubleBuffered PanelAtiksuBoru = new PanelDoubleBuffered();
        readonly PanelDoubleBuffered PanelAtiksuBoru2 = new PanelDoubleBuffered();


        public class PanelDoubleBuffered : Panel
        {
            public PanelDoubleBuffered()
                : base()
            {
                this.DoubleBuffered = true;
            }
        }

        public SimulationPage()
        {
            CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();
        }

        private void Simulation_Load(object sender, EventArgs e)
        {
            NewPanelDoubleBuffered(PanelHavuzSuyu, new Point(96, 352), havuzSuyu1);
            PanelBG.Controls.Add(PanelHavuzSuyu);

            NewPanelDoubleBuffered(PanelTup, new Point(632, 78), tupAtiksiDolu1);
            PanelBG.Controls.Add(PanelTup);

            NewPanelDoubleBuffered(PanelAtiksuBoru, new Point(310, 130), boruAtiksu1);
            PanelBG.Controls.Add(PanelAtiksuBoru);

            NewPanelDoubleBuffered(PanelAtiksuBoru2, new Point(0, 0), boruAtiksu1);
            PanelAtiksuBoru2.Parent = PanelAtiksuBoru;
            PanelBG.Controls.Add(PanelAtiksuBoru2);
        }

        private void NewPanelDoubleBuffered(PanelDoubleBuffered panel, Point location, Bitmap bgImage)
        {
            panel.Location = location;
            panel.Size = new Size(bgImage.Width, bgImage.Height);
            panel.BackColor = Color.Transparent;
            panel.BackgroundImage = bgImage;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            CheckNextFrame(PanelHavuzSuyu, havuzSuyu1, havuzSuyu2);
            CheckNextFrame(PanelTup, tupAtiksiDolu1, tupAtiksiDolu2);
            CheckNextFrame(PanelAtiksuBoru, boruAtiksu1, boruAtiksu2);
        }

        private void CheckNextFrame(Panel panel, Bitmap bitmapFirstFrame, Bitmap bitmapSecondFrame)
        {
            var bGW = new BackgroundWorker();
            bGW.DoWork += delegate
            {
                if (panel.BackgroundImage == bitmapFirstFrame)
                {
                    panel.BackgroundImage = bitmapSecondFrame;
                }
                else if (panel.BackgroundImage == bitmapSecondFrame)
                {
                    panel.BackgroundImage = bitmapFirstFrame;
                }
            };
            bGW.RunWorkerAsync();
        }

        private void PanelBG_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            MessageBox.Show("Tıklanan konumun X koordinatı: " + x.ToString() + "\nTıklanan konumun Y koordinatı: " + y.ToString());
        }
    }
}
