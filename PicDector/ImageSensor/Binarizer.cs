using FastBitmapLib;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageSensor
{
    /// <summary>
    /// 2值化专用
    /// </summary>
    class Binarizer : IDisposable
    {
        private readonly Bitmap DumpPic;
        private bool[] Binarizes;
        public int Width;
        public int Height;

        public Binarizer(Bitmap bmpBase)
        {
            Width = bmpBase.Width;
            Height = bmpBase.Height;
            Binarizes = new bool[Width * Height];
            DumpPic = bmpBase.Clone(new Rectangle(0, 0, Width, Height), PixelFormat.Format32bppArgb);
        }

        public void Dispose()
        {
            DumpPic?.Dispose();
            Binarizes = null;
        }


        #region Threshold
        /// <summary>
        /// 更新图像信息
        /// </summary>
        /// <param name="threshold">阈值</param>
        /// <param name="parameter">判断阈值的参数</param>
        /// <param name="ColorInversion">颜色反转：<br/>true时参数小于阈值为黑<br/>false时参数大于阈值为黑</param>
        public void UpDateThreshold(int threshold, HsvRgb parameter, bool ColorInversion)
        {
            switch (parameter)
            {
                case HsvRgb.Hue:
                    UpDateThreshold(threshold, (color, t) => HueThreshold(color, t), ColorInversion);
                    break;
                case HsvRgb.Saturation:
                    UpDateThreshold(threshold, (color, t) => SaturationThreshold(color, t), ColorInversion);
                    break;
                case HsvRgb.Value:
                    UpDateThreshold(threshold, (color, t) => ValueThreshold(color, t), ColorInversion);
                    break;
                case HsvRgb.Brightness:
                    UpDateThreshold(threshold, (color, t) => BrightnessThreshold(color, t), ColorInversion);
                    break;
                case HsvRgb.Red:
                    UpDateThreshold(threshold, (color, t) => RedThreshold(color, t), ColorInversion);
                    break;
                case HsvRgb.Green:
                    UpDateThreshold(threshold, (color, t) => GreenThreshold(color, t), ColorInversion);
                    break;
                case HsvRgb.Blue:
                    UpDateThreshold(threshold, (color, t) => BlueThreshold(color, t), ColorInversion);
                    break;
            }
        }
        private void UpDateThreshold(int threshold, Func<int, int, bool> func, bool flag)
        {
            using (FastBitmap fb = DumpPic.FastLock())
            {
                int[] DataArray = fb.DataArray;
                fb.Unlock();
                for (int i = 0; i < Width; i++)
                {
                    for (int j = 0; j < Height; j++)
                    {
                        Binarizes[i + j * Width] |= func(DataArray[i + j * Width], threshold) ^ flag;
                    }
                }
            }
        }
        public bool HueThreshold(int color, int threshold)
        {
            return HSV.HueOnly(color) > threshold;
        }
        public bool SaturationThreshold(int color, int threshold)
        {
            return HSV.SaturationOnly(color) > threshold;
        }
        public bool ValueThreshold(int color, int threshold)
        {
            return HSV.ValueOnly(color) > threshold;
        }
        public bool BrightnessThreshold(int color, int threshold)
        {
            return HSV.BrightnessOnly(color) > threshold;
        }
        public bool RedThreshold(int color, int threshold)
        {
            return (byte)(color >> 16) > threshold;
        }
        public bool GreenThreshold(int color, int threshold)
        {
            return (byte)(color >> 8) > threshold;
        }
        public bool BlueThreshold(int color, int threshold)
        {
            return (byte)color > threshold;
        }
        #endregion

        #region Range
        /// <summary>
        /// 更新图像信息
        /// </summary>
        /// <param name="RangeL">阈值左</param>
        /// <param name="RangeR">阈值右</param>
        /// <param name="parameter">判断阈值的参数</param>
        /// <param name="ColorInversion">颜色反转：<br/>true时参数小于阈值为黑<br/>false时参数大于阈值为黑</param>
        public void UpDateFilter(int RangeL, int RangeR, HsvRgb parameter, bool ColorInversion)
        {
            if (RangeR < RangeL)
            { int d = RangeL; RangeL = RangeR; RangeR = d; }

            switch (parameter)
            {
                case HsvRgb.Hue:
                    UpDateFilter(RangeL, RangeR, (color, L, R) => HueFilter(color, L, R), ColorInversion);
                    break;
                case HsvRgb.Saturation:
                    UpDateFilter(RangeL, RangeR, (color, L, R) => SaturationFilter(color, L, R), ColorInversion);
                    break;
                case HsvRgb.Value:
                    UpDateFilter(RangeL, RangeR, (color, L, R) => ValueFilter(color, L, R), ColorInversion);
                    break;
                case HsvRgb.Brightness:
                    UpDateFilter(RangeL, RangeR, (color, L, R) => BrightnessFilter(color, L, R), ColorInversion);
                    break;
                case HsvRgb.Red:
                    UpDateFilter(RangeL, RangeR, (color, L, R) => RedFilter(color, L, R), ColorInversion);
                    break;
                case HsvRgb.Green:
                    UpDateFilter(RangeL, RangeR, (color, L, R) => GreenFilter(color, L, R), ColorInversion);
                    break;
                case HsvRgb.Blue:
                    UpDateFilter(RangeL, RangeR, (color, L, R) => BlueFilter(color, L, R), ColorInversion);
                    break;
            }
        }

        private void UpDateFilter(int RangeL, int RangeR, Func<int, int, int, bool> func, bool flag)
        {
            using (FastBitmap fb = DumpPic.FastLock())
            {
                int[] DataArray = fb.DataArray;
                fb.Unlock();
                for (int i = 0; i < Width; i++)
                {
                    for (int j = 0; j < Height; j++)
                    {
                        Binarizes[i + j * Width] |= func(DataArray[i + j * Width], RangeL, RangeR) ^ flag;
                    }
                }
            }
        }
        public bool HueFilter(int color, int RangeL, int RangeR)
        {
            int c = HSV.HueOnly(color);
            return c >= RangeL && c <= RangeR;
        }
        public bool SaturationFilter(int color, int RangeL, int RangeR)
        {
            int c = HSV.SaturationOnly(color);
            return c >= RangeL && c <= RangeR;
        }
        public bool ValueFilter(int color, int RangeL, int RangeR)
        {
            int c = HSV.ValueOnly(color);
            return c >= RangeL && c <= RangeR;
        }
        public bool BrightnessFilter(int color, int RangeL, int RangeR)
        {
            int c = HSV.BrightnessOnly(color);
            return c >= RangeL && c <= RangeR;
        }
        public bool RedFilter(int color, int RangeL, int RangeR)
        {
            int c = (byte)(color >> 16);
            return c >= RangeL && c <= RangeR;
        }
        public bool GreenFilter(int color, int RangeL, int RangeR)
        {
            int c = (byte)(color >> 8);
            return c >= RangeL && c <= RangeR;
        }
        public bool BlueFilter(int color, int RangeL, int RangeR)
        {
            int c = (byte)color;
            return c >= RangeL && c <= RangeR;
        }

        #endregion


        public bool ColorFilter(int color, int Range)
        {
            return color == Range;
        }

        public Bitmap ColorBinarized()
        {
            int[] DataArray = new int[Width * Height];
            int Black = Color.Black.ToArgb();
            int White = Color.White.ToArgb();
            Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (Binarizes[i + j * Width])
                        DataArray[i + j * Width] = Black;
                    else
                        DataArray[i + j * Width] = White;
                }
            }
            using (FastBitmap fb = bitmap.FastLock())
            {
                fb.CopyFromArray(DataArray);
            }

            return bitmap;
        }

        public Bitmap ColorFilted()
        {
            int[] DataArray = new int[Width * Height];
            int White = Color.White.ToArgb();
            Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);

            int[] OriginalArray;
            using (FastBitmap fb = DumpPic.FastLock())
            {
                OriginalArray = fb.DataArray;
            }

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (Binarizes[i + j * Width])
                        DataArray[i + j * Width] = OriginalArray[i + j * Width];
                    else
                        DataArray[i + j * Width] = White;
                }
            }
            using (FastBitmap fb = bitmap.FastLock())
            {
                fb.CopyFromArray(DataArray);
            }

            return bitmap;
        }



    }
}
