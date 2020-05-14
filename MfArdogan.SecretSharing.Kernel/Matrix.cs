using System.Drawing;

namespace MfArdogan.SecretSharing.Kernel
{
    internal static class Matrix
    {
        public static Bitmap ToGrayScaleImage(this Bitmap bitmap)
        {
            int x = 0, y = 0;
            int width = bitmap.Width, height = bitmap.Height;
            var image = new Bitmap(bitmap.Width, bitmap.Height);
            for (; x < width; x++)
            {
                for (; y < height; y++)
                {
                    var next = bitmap.GetPixel(x, y);
                    var avg = (next.R + next.G + next.B) / 3;
                    image.SetPixel(x, y, Color.FromArgb(255, avg, avg, avg));
                }
            }
            return image;
        }
        public static int[,] ToMultiDiemensionalArray(this Bitmap bitmap)
        {
            int x = 0, y = 0;
            int width = bitmap.Width, height = bitmap.Height;

            var array = new int[width, height];
            for (; x < width; x++)
            {
                for (; y < height; y++)
                {
                    var next = bitmap.GetPixel(x, y);
                    array[x, y] = next.R;
                }
            }
            return array;
        }
    }
}
