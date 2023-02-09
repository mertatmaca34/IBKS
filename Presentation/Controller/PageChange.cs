﻿using System.Windows.Forms;

namespace Presentation.Controller
{
    internal class PageChange
    {
        static internal void Change(Main Main, Form SubForm, Panel MainPanel)
        {
            if (MainPanel.Controls.Count > 0)
            {
                foreach (var item in MainPanel.Controls)
                {
                    if ((item as Form).Text == SubForm.Text)
                    {
                        break;
                    }
                }
            }
            else
            {
                SubForm.TopLevel = false;
                MainPanel.Controls.Clear();
                MainPanel.Controls.Add(SubForm);
                SubForm.Show();

                CheckMode(Main,SubForm);
            }
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