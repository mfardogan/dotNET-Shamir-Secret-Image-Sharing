using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace MfArdogan.SecretSharing.Kernel
{
    public class SecretImageSharingDecrypter : DecrypterKernel<Bitmap>
    {
        public SecretImageSharingDecrypter(Sharing<Bitmap> sharing) : base(sharing)
        {
        }

        public SecretImageSharingDecrypter(IKeyEncrypter keyEncrypter, Sharing<Bitmap> sharing) : base(keyEncrypter, sharing)
        {
        }

        private int Decrypt(IEnumerable<(int x, int y)> encrypted)
        {
            var dictionary = new Dictionary<int, int>();
            foreach (var item in encrypted)
            {
                dictionary.Add(item.x, item.y);
            }
            return Lagrance(dictionary, 251);
        }

        public override Bitmap Decrypt()
        {
            var start = Sharing.ElementAt(0);
            var width = start.value.Width;
            var height = start.value.Height;

            var matrix = new int[width, height];

            List<KeyValuePair<int, int[,]>> matirces = Sharing.Select(
                x => new KeyValuePair<int, int[,]>
                        (x.number, x.value.ToGrayScaleMatrix())
                ).ToList();

            var vss = new List<(int x, int y)>();
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    vss.Clear();
                    vss.AddRange(matirces.Select(t => (x: t.Key, y: t.Value[x, y])));

                    var detect = KeyEncrypter == default ? Decrypt(vss) :
                        KeyEncrypter.Decrypt(Decrypt(vss));
                    matrix[x, y] = detect;
                }
            }

            return matrix.AsGrayScaleBitmap();
        }
    }
}
