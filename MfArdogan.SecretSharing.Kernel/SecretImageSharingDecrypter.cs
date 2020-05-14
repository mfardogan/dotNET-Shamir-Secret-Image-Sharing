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


        public int Decrypt(IEnumerable<(int x, int y)> encrypted)
        {
            var dictionary = new Dictionary<BigInteger, BigInteger>();
            foreach (var item in encrypted)
            {
                dictionary.Add(item.x, item.y);
            }
            return (int)DeShamir(dictionary, 255);
        }

        public override Bitmap Decrypt()
        {
            var start = Sharing.ElementAt(0);
            var width = start.value.Width;
            var height = start.value.Height;

            var result = new Bitmap(width, height);

            List<KeyValuePair<int, int[,]>> matirces = Sharing.Select(
               x => new KeyValuePair<int, int[,]>(x.number, x.value.ToGrayScaleImage()
                    .ToMultiDiemensionalArray())
                ).ToList();

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    var vss = new List<(int x, int y)>();
                    foreach (var item in matirces)
                    {
                        vss.Add((item.Key, item.Value[x, y]));
                    }

                    var detect = KeyEncrypter == default ? Decrypt(vss) :
                        KeyEncrypter.Decrypt(Decrypt(vss));
                    result.SetPixel(x, y, Color.FromArgb(detect, detect, detect));
                }
            }

            return result;
        }
    }
}
