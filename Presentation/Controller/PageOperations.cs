using Presentation.View.Pages;
using System.Windows.Forms;

namespace Presentation.Controller
{
    public sealed class PageOperations
    {
        private static PageOperations instance = null;
        private static readonly object padlock = new object();

        public HomePage homePage;
        public SimulationPage simulation;
        public CalibrationPage calibration;
        PageOperations()
        {
            homePage = new HomePage();
            simulation = new SimulationPage();
            calibration = new CalibrationPage();
        }

        public static PageOperations Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new PageOperations();
                    }
                    return instance;
                }
            }
        }
        static internal void Change(Main Main, Form SubForm, Panel MainPanel)
        {
            SubForm.TopLevel = false;
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(SubForm);
            SubForm.Show();

            CheckMode(Main, SubForm);
        }
        static private void CheckMode(Main Main, Form SubForm)
        {
            if (Main.ButtonMode.Text == "Gündüz Mod")
            {
                Mode.NightMode(SubForm.Controls, null);
            }
        }
    }
}
