using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageSensor
{
    public partial class ScreenShoter : Form
    {

        public Rectangle CaptureBounds;

        private Point MouseStartPoint;
        private bool isMouseDown = false;

        private readonly Bitmap DumpPic;
        public Bitmap ScreenShot;

        public ScreenShoter()
        {
            InitializeComponent();
            this.TopMost = true;
            this.CaptureBounds = Screen.PrimaryScreen.Bounds;
            this.DumpPic = ScreenDector.ScreenShot();
            this.BackgroundImage = (Image)DumpPic.Clone();
            DialogResult = DialogResult.Cancel;
        }


        private void ScreenShoter_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.Close();
            isMouseDown = true;
            MouseStartPoint = e.Location;
        }

        private void ScreenShoter_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            isMouseDown = false;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ScreenShoter_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point MouseNow = e.Location;
                int WidthPM = MouseNow.X - MouseStartPoint.X;
                int HeightPM = MouseNow.Y - MouseStartPoint.Y;
                int x = WidthPM > 0 ? MouseStartPoint.X : MouseStartPoint.X + WidthPM;
                int y = HeightPM > 0 ? MouseStartPoint.Y : MouseStartPoint.Y + HeightPM;

                CaptureBounds = new Rectangle(x, y, Math.Abs(WidthPM), Math.Abs(HeightPM));

                using (Graphics g = Graphics.FromImage(BackgroundImage))
                {
                    g.DrawImage(DumpPic, new Point(0, 0));
                    g.DrawRectangle(new Pen(Color.DodgerBlue, 2), CaptureBounds);
                }

                this.Refresh();

            }
        }

        private void ScreenShoter_FormClosing(object sender, FormClosingEventArgs e)
        {
            BackgroundImage?.Dispose();
            ScreenShot = new Bitmap(CaptureBounds.Width, CaptureBounds.Height);
            using (Graphics g = Graphics.FromImage(ScreenShot))
            {
                g.DrawImage(DumpPic, new Rectangle(0, 0, CaptureBounds.Width, CaptureBounds.Height),
                            CaptureBounds,
                            GraphicsUnit.Pixel);
            }

            DumpPic?.Dispose();
        }

        private void ScreenShoter_Load(object sender, EventArgs e)
        {

        }
    }
}
