using System.Drawing;
using System.Windows.Forms;

namespace Better.Controller
{
    internal class Mode
    {
        internal void ChangeMode(Control.ControlCollection Controls, Button Button = null)
        {
            if (Button.Text == "Gece Modu")
            {
                NightMode(Controls, Button);
            }
            else
            {
                DayMode(Controls, Button);
            }
        }
        internal void NightMode(Control.ControlCollection Controls, Button Button)
        {
            Color DarkGray = Color.FromArgb(24, 24, 24);

            foreach (Control item in Controls)
            {
                if (item is TableLayoutPanel || item is Panel)
                {
                    ChangeButtonImageColor(item.Controls, 211);
                    item.BackColor = Color.Black;
                    if (item.Controls.Count > 0)
                    {
                        foreach (var iitem in item.Controls)
                        {

                            if (iitem is Button)
                            {
                                (iitem as Button).FlatAppearance.MouseDownBackColor = Color.FromArgb(48, 48, 48);
                                (iitem as Button).FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 24, 24);
                                (iitem as Button).ForeColor = Color.LightGray;
                            }
                            else if (iitem is Label && (iitem as Label).ForeColor != Color.FromArgb(0, 131, 200))
                            {
                                (iitem as Label).ForeColor = Color.LightGray;
                            }
                            NightMode(item.Controls, null);
                        }
                    }
                }
            }
            if (Button != null)
            {
                Button.Text = "Gündüz Mod";
            }
        }
        internal void DayMode(Control.ControlCollection Controls, Button Button)
        {
            foreach (Control item in Controls)
            {
                if (item is TableLayoutPanel)
                {
                    ChangeButtonImageColor(item.Controls, 105);
                    item.BackColor = Color.White;
                    if (item.Controls.Count > 0)
                    {
                        foreach (var iitem in item.Controls)
                        {
                            if (iitem is Button)
                            {
                                (iitem as Button).FlatAppearance.MouseDownBackColor = SystemColors.ScrollBar;
                                (iitem as Button).FlatAppearance.MouseOverBackColor = SystemColors.ButtonFace;
                                (iitem as Button).ForeColor = Color.DimGray;
                            }
                            DayMode(item.Controls, null);
                        }
                    }
                }
                else if (item is Panel)
                {
                    item.BackColor = SystemColors.Control;
                }
            }
            if (Button != null)
            {
                Button.Text = "Gece Modu";
            }
        }
        private void ChangeButtonImageColor(Control.ControlCollection Controls, int colorValue)
        {
            foreach (Control item in Controls)
            {
                if (item is Button)
                {
                    Bitmap bitmap = new Bitmap((item as Button).Image);

                    int width = bitmap.Width;
                    int height = bitmap.Height;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            Color color = bitmap.GetPixel(x, y);

                            int alpha = color.A;

                            bitmap.SetPixel(x, y, Color.FromArgb(alpha, colorValue, colorValue, colorValue));
                        }
                    }
                    (item as Button).Image = bitmap;
                }
            }
        }
    }
}
