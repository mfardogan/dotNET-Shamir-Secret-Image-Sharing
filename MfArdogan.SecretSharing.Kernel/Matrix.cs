using System.Drawing;

namespace MfArdogan.SecretSharing.Kernel
{
    internal static class Matrix
    {
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
       

        public static Bitmap AsGrayScaleBitmap(this int[,] vs)
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
