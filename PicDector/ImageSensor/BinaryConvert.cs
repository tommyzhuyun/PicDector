using FastBitmapLib;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageSensor
{
    /// <summary>
    /// Based on this site https://nakatsudotnet.blog.fc2.com/blog-entry-19.html
    /// Single -> int  
    /// FastBitmap Lock: Byte[] -> int[]
    /// </summary>
    class BinaryConvert
    {

        /// <summary>
        /// 2値化画像に変換(固定閾値法)
        /// </summary>
        /// <param name="bmpBase">画像データ</param>
        /// <param name="threshold">2値化閾値</param>
        /// <returns>画像データ</returns>
        public static Bitmap ToBinaryByFixed(Bitmap bmpBase, Int32 threshold)
        {
            // 指定の閾値を使用して2値化を行う
            return ConvertBinary(bmpBase, threshold,
                                (rgb, th, sz, st) => BinaryFixedConvert(rgb, th, sz, st));
        }

        /// <summary>
        /// 2値化画像に変換(オーダー法)
        /// </summary>
        /// <param name="bmpBase">元となる画像</param>
        /// <returns>画像データ</returns>
        public static Bitmap ToBinaryByOrdered(Bitmap bmpBase)
        {
            return ConvertBinary(bmpBase, 0,
                                 (rgb, th, sz, st) => BinaryOrderedConvert(rgb, sz, st));
        }

        /// <summary>
        /// 2値化画像に変換(差分法)
        /// </summary>
        /// <param name="bmpBase">元となる画像</param>
        /// <param name="threshold">閾値</param>
        /// <returns>画像データ</returns>
        public static Bitmap ToBinaryByDiff(Bitmap bmpBase, Int32 threshold)
        {
            return ConvertBinary(bmpBase, threshold,
                                 (rgb, th, sz, st) => BinaryDiffConvert(rgb, th, sz, st));
        }

        /// <summary>
        /// 2値化用変換関数
        /// </summary>
        /// <param name="bmpBase">元となる画像</param>
        /// <param name="threshold">閾値</param>
        /// <param name="converter">変換式</param>
        /// <returns></returns>
        private static Bitmap ConvertBinary(Bitmap bmpBase, Int32 threshold,
                                            Func<int[], Int32, Size, Int32, byte[]> converter)
        {
            Rectangle rect = new Rectangle(0, 0, bmpBase.Width, bmpBase.Height);
            Bitmap result = new Bitmap(bmpBase.Width, bmpBase.Height, PixelFormat.Format1bppIndexed);

            int[] rgbValues;
            int Stride;
            using (Bitmap bmp = bmpBase.Clone(rect, PixelFormat.Format32bppArgb))
            using (FastBitmap fb = bmp.FastLock())
            {
                rgbValues = fb.DataArray;
                Stride = fb.Stride;
            }

            BitmapData bmpResultData = result.LockBits(rect, ImageLockMode.WriteOnly, result.PixelFormat);
            byte[] resultValues = converter(rgbValues, threshold, result.Size, bmpResultData.Stride);
            System.Runtime.InteropServices.Marshal.Copy(resultValues, 0, bmpResultData.Scan0, resultValues.Length);
            result.UnlockBits(bmpResultData);


            return result;
        }


        /// <summary>
        /// 固定閾値法の変換処理
        /// </summary>
        /// <param name="rgbValues">色データ</param>
        /// <param name="threshold">閾値</param>
        /// <param name="bmpSize">画像サイズ</param>
        /// <param name="stride">画像読み込み幅</param>
        /// <returns>変換色データ</returns>
        private static byte[] BinaryFixedConvert(int[] rgbValues, Int32 threshold,
                                                 Size bmpSize, Int32 stride)
        {
            byte[] result = new byte[stride * bmpSize.Height];

            for (int y = 0; y < bmpSize.Height; y++)
            {
                for (int x = 0; x < bmpSize.Width; x++)
                {
                    int brightness = HSV.BrightnessOnly(rgbValues[x + y * bmpSize.Width]);
                    // 閾値チェック
                    if (threshold < brightness)
                    {
                        //ピクセルデータの位置
                        int pos = (x >> 3) + stride * y;
                        //白くする
                        result[pos] |= (Byte)(0x80 >> (x & 0x7));
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// オーダードディザリングの変換処理
        /// </summary>
        /// <param name="rgbValues">色データ</param>
        /// <param name="bmpSize">画像サイズ</param>
        /// <param name="stride">画像読み込み幅</param>
        /// <returns>変換色データ</returns>
        private static byte[] BinaryOrderedConvert(int[] rgbValues, Size bmpSize, Int32 stride)
        {

            // 閾値マップを作成する
            var thMap = new byte[4][]
            {
                new byte[4] {1, 9, 3, 11},
                new byte[4] {13, 5, 15, 7},
                new byte[4] {4, 12, 2, 10},
                new byte[4] {16, 8, 14, 6 },
            };

            var result = new byte[stride * bmpSize.Height];

            for (int y = 0; y < bmpSize.Height; y++)
            {
                for (int x = 0; x < bmpSize.Width; x++)
                {
                    int br = HSV.BrightnessOnly(rgbValues[x + y * bmpSize.Width]);

                    if (thMap[y % 4][x % 4] * 255 / 17 <= br)
                    {
                        // 色設定
                        int pos = (x >> 3) + stride * y;
                        result[pos] |= (Byte)(0x80 >> (x & 0x7));
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 差分法の変換処理
        /// </summary>
        /// <param name="rgbValues">色データ</param>
        /// <param name="threshold">閾値</param>
        /// <param name="bmpSize">画像サイズ</param>
        /// <param name="stride">画像読み込み幅</param>
        /// <returns>変換色データ</returns>
        private static byte[] BinaryDiffConvert(int[] rgbValues, Int32 threshold,
                                                Size bmpSize, Int32 stride)
        {
            var result = new byte[stride * bmpSize.Height];
            //現在の行と次の行の誤差を記憶する配列
            var errors = new int[2][] {
                    new int[bmpSize.Width + 1],
                    new int[bmpSize.Width + 1]
                 };

            for (int r = 0; r < bmpSize.Height; r++)
            {
                for (int c = 0; c < bmpSize.Width; c++)
                {
                    int err = HSV.BrightnessOnly(rgbValues[c + r * bmpSize.Width]) + errors[0][c];
                    if (threshold <= err)
                    {
                        // 色設定
                        int pos = (c >> 3) + stride * r;
                        result[pos] |= (Byte)(0x80 >> (c & 0x7));
                        //誤差を計算（黒くした時の誤差はerr-0なので、そのまま）
                        err -= 255;
                    }

                    //誤差を振り分ける
                    errors[0][c + 1] += err * 7 / 16;
                    if (c > 0)
                    {
                        errors[1][c - 1] += err * 3 / 16;
                    }
                    errors[1][c] += err * 5 / 16;
                    errors[1][c + 1] += err * 1 / 16;
                }
                //誤差を記憶した配列を入れ替える
                errors[0] = errors[1];
                errors[1] = new int[errors[0].Length];
            }
            return result;
        }

    }
}
