using FastBitmapLib;
using ImageSensor;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PicDector
{
    public partial class PicDector : Form
    {
        public PicDector()
        {
            InitializeComponent();
        }

        private Binarizer binarizer;
        public Rectangle Range;
        ColorPicker.SquareBitmap sqbp;

        private void Form1_Load(object sender, System.EventArgs e)
        {
            //pictureBox1.Image = Image.FromFile("./1bpp1.png");
            //pictureBox1.Image = Image.FromFile("./HSVRGB.bmp");
            this.TopMost = OnTop.Checked;
            ColorLine.Image = new Bitmap(ColorLine.Width, ColorLine.Height);
            sqbp = new ColorPicker.SquareBitmap(Color.FromArgb(0, 0, 0), new HSV(0, 0, 255));
            sqbp.UpColorLine((Bitmap)ColorLine.Image, HsvRgb.Value, true);

        }

        private void Start_Click(object sender, EventArgs e)
        {
            bool Continue = CaptureFlag;
            CaptureFlag = false;
            pictureBox1.Image?.Dispose();

            ImageSensor.ScreenShoter ss = new ImageSensor.ScreenShoter();
            if (ss.ShowDialog() == DialogResult.OK)
            {
                Range = ss.CaptureBounds;
                Bitmap result = ss.ScreenShot;
                ss.Dispose();

                if (NoneCheck.Checked)
                {
                    pictureBox1.Image = result;
                    pictureBox1.Refresh();
                }

                if (ThresholdCheck.Checked)
                {
                    binarizer?.Dispose();
                    binarizer = new Binarizer(result);
                    binarizer.UpDateThreshold(trackBar1.Value, GetHsvRgb(), false);
                    pictureBox1.Image = binarizer.ColorBinarized();
                    binarizer?.Dispose();
                    pictureBox1.Refresh();
                }

                if (RangerCheck.Checked)
                {
                    binarizer?.Dispose();
                    binarizer = new Binarizer(result);
                    binarizer.UpDateFilter(trackBar1.Value, trackBar2.Value, GetHsvRgb(), true);
                    pictureBox1.Image = binarizer.ColorBinarized();
                    binarizer?.Dispose();
                    pictureBox1.Refresh();
                }
                CaptureFlag = true;
                Capturing();
            }
            else if (Continue)
            {
                CaptureFlag = true;
                Capturing();
            }
            ss.Dispose();
        }



        public bool CaptureFlag = false;
        private void Capturing()
        {  //http://www.clks.jp/csg/gt002.html
            double nextframe = Environment.TickCount;
            double start = nextframe;
            float wait = 1000f / 60f;
            double frames = 0;
            while (CaptureFlag)
            {
                if (Environment.TickCount >= nextframe)
                {
                    //計算処理

                    if (Environment.TickCount < nextframe + wait)
                    {
                        //描画処理
                        if (NoneCheck.Checked)
                        {
                            pictureBox1.Image?.Dispose();
                            pictureBox1.Image = ScreenDector.ScreenShot(Range);
                            pictureBox1.Refresh();
                        }
                        if (ThresholdCheck.Checked)
                        {
                            binarizer = new Binarizer(ScreenDector.ScreenShot(Range));
                            binarizer.UpDateThreshold(trackBar1.Value, GetHsvRgb(), ColorInversion.Checked);
                            pictureBox1.Image?.Dispose();

                            if (ColorFilter.Checked)
                                pictureBox1.Image = binarizer.ColorFilted();
                            else
                                pictureBox1.Image = binarizer.ColorBinarized();
                            binarizer?.Dispose();
                            pictureBox1.Refresh();

                            textBox1.Text = textBox2.Text = trackBar1.Value.ToString();
                            textBox1.Update();
                            textBox2.Update();
                        }

                        if (RangerCheck.Checked)
                        {
                            binarizer?.Dispose();
                            binarizer = new Binarizer(ScreenDector.ScreenShot(Range));
                            binarizer.UpDateFilter(trackBar1.Value, trackBar2.Value, GetHsvRgb(), ColorInversion.Checked);
                            if (ColorFilter.Checked)
                                pictureBox1.Image = binarizer.ColorFilted();
                            else
                                pictureBox1.Image = binarizer.ColorBinarized();
                            binarizer?.Dispose();
                            pictureBox1.Refresh();
                            if (trackBar1.Value <= trackBar2.Value)
                            {
                                textBox1.Text = trackBar1.Value.ToString();
                                textBox2.Text = trackBar2.Value.ToString();
                            }
                            else
                            {
                                textBox1.Text = trackBar2.Value.ToString();
                                textBox2.Text = trackBar1.Value.ToString();
                            }
                            textBox1.Update();
                            textBox2.Update();
                        }
                        frames++;
                    }
                    nextframe += wait;
                }

                double end = Environment.TickCount;
                if (end >= start + 1000)
                {
                    label1.Text = (1000 * frames / (end - start)).ToString("N0") + "FPS";
                    label1.Update();
                    frames = 0;
                    start += 1000;
                }
                Application.DoEvents();

            }
        }

        private FastBitmapLib.HsvRgb GetHsvRgb()
        {
            if (HueCheck.Checked)
                return FastBitmapLib.HsvRgb.Hue;
            else if (SatCheck.Checked)
                return FastBitmapLib.HsvRgb.Saturation;
            else if (ValCheck.Checked)
                return FastBitmapLib.HsvRgb.Value;
            else if (RedCheck.Checked)
                return FastBitmapLib.HsvRgb.Red;
            else if (GreenCheck.Checked)
                return FastBitmapLib.HsvRgb.Green;
            else if (BlueCheck.Checked)
                return FastBitmapLib.HsvRgb.Blue;
            else
                return FastBitmapLib.HsvRgb.Brightness;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CaptureFlag = false;
        }

        private void OnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = OnTop.Checked;
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            CaptureFlag = false;
        }

        private bool ChangeLock = false;
        private void ChannelCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (ChangeLock) return;
            ChangeLock = true;
            if (HueCheck.Checked)
            {
                trackBar1.Maximum = 360;
                trackBar2.Maximum = 360;
            }
            else
            {
                if (trackBar1.Value > 255)
                    trackBar1.Value = 255;
                trackBar1.Maximum = 255;
                if (trackBar2.Value > 255)
                    trackBar2.Value = 255;
                trackBar2.Maximum = 255;
            }
            if (HueCheck.Checked)
                sqbp.UpColorLine((Bitmap)ColorLine.Image, HsvRgb.Hue, true);
            if (SatCheck.Checked)
                sqbp.UpColorLine((Bitmap)ColorLine.Image, HsvRgb.Saturation, true);
            if (ValCheck.Checked)
                sqbp.UpColorLine((Bitmap)ColorLine.Image, HsvRgb.Value, true);
            if (BtnCheck.Checked)
                sqbp.UpColorLine((Bitmap)ColorLine.Image, HsvRgb.Value, true);
            if (RedCheck.Checked)
                sqbp.UpColorLine((Bitmap)ColorLine.Image, HsvRgb.Red, true);
            if (GreenCheck.Checked)
                sqbp.UpColorLine((Bitmap)ColorLine.Image, HsvRgb.Green, true);
            if (BlueCheck.Checked)
                sqbp.UpColorLine((Bitmap)ColorLine.Image, HsvRgb.Blue, true);
            ColorLine.Refresh();

            ChangeLock = false;
        }
    }
}
