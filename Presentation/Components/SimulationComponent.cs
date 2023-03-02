using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SimulationComponent : DrawingArea
{
    protected override void OnDraw()
    {
        // Gets the image from the global resources
        Image broculoImage = global::Presentation.Properties.Resources.alarm_24px;
        Image xd = global::Presentation.Properties.Resources.logoLongWhite;

        // Sets the images' sizes and   positions
        int width = broculoImage.Size.Width;
        int height = broculoImage.Size.Height;
        Rectangle big = new Rectangle(0, 0, width, height);
        Rectangle small = new Rectangle(50, 50, (int)(0.75 * width), (int)(0.75 * height));

        // Draws the two images
        this.graphics.DrawImage(broculoImage, big);
    }
}
