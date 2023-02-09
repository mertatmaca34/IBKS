using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Controller
{
    internal class WindowStyle
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        internal extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        internal extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        static internal void HoldAndMove(Form Form)
        {
            ReleaseCapture();
            SendMessage(Form.Handle, 0x112, 0xf012, 0);
        }
        static internal void Maximize(Form Form)
        {
            if (Form.WindowState == FormWindowState.Normal)
            {
                Form.WindowState = FormWindowState.Maximized;
            }
            else
            {
                Form.WindowState = FormWindowState.Normal;
            }
        }
        static internal void Minimize(Form Form)
        {
            Form.WindowState = FormWindowState.Minimized;
        }
        
    }
}
