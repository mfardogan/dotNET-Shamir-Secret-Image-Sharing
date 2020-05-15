using System.Drawing;

namespace MfArdogan.SecretSharing.Kernel
{
    internal static class Matrix
    {
        /// <summary>
        /// Convert a bitmap to array as gray scale.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static int[,] ToGrayScaleMatrix(this Bitmap bitmap)
        {
            var width = bitmap.Width;
            var height = bitmap.Height;
            var matrix = new int[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var p = bitmap.GetPixel(i, j);
                    matrix[i, j] = (p.R + p.G + p.B) / 3;
                }
            }
            return matrix;
        }
       
        /// <summary>
        /// Convert an array to Bitmap as gray scale.
        /// </summary>
        /// <param name="vs"></param>
        /// <returns></returns>
        public static Bitmap ToGrayScaleBitmap(this int[,] vs)
        {
            var width = vs.GetLength(0);
            var height = vs.GetLength(1);
            var image = new Bitmap(width, height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var gray = vs[i, j];
                    image.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            return image;
        }
    }
}
