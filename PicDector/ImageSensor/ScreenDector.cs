using System.Drawing;
using System.Windows.Forms;

namespace ImageSensor
{
    class ScreenDector
    {

        public static Bitmap ScreenShot()
        {
            return ScreenShot(Screen.PrimaryScreen.Bounds);
        }

        public static Bitmap ScreenShot(int X, int Y, int Width, int Height)
        {
            return ScreenShot(new Rectangle(X, Y, Width, Height));
        }

        public static Bitmap ScreenShot(Point pt, Size size)
        {
            return ScreenShot(new Rectangle(pt, size));
        }

        public static Bitmap ScreenShot(Rectangle margin)
        {
            Bitmap bmp = new Bitmap(margin.Width, margin.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(margin.Location, new Point(0, 0), margin.Size);
            }
            return bmp;
        }
    }
}
