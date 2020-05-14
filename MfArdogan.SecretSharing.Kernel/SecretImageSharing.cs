using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MfArdogan.SecretSharing.Kernel
{
    public class SecretImageSharing : SecretSharing<Bitmap>
    {
        public SecretImageSharing(Bitmap bitmap, int n, int k)
            : base(n, k) => Image = bitmap;

        public SecretImageSharing(Bitmap bitmap, int n, int k, IKeyEncrypter keyEncrypter)
            : base(n, k, keyEncrypter) => Image = bitmap;

        public Bitmap Image { get; }
        public override Sharing<Bitmap> Share()
        {
            var matrix = Image.ToGrayScaleImage().ToMultiDiemensionalArray();
            var sharing = Sharing<Bitmap>.CreateSharingDictionary(
                Enumerable.Range(0, N).Select(x => new Bitmap(Image.Width, Image.Height))
                );

            for (var x = 0; x < Image.Width; x++)
            {
                for (var y = 0; y < Image.Height; y++)
                {
                    var next = matrix[x, y];
                    IEnumerable<(int number, int value)> objects = Encrypt(next, 255)
                        .Select(m => (number: m.Key, value: m.Value))
                        .OrderBy(m => m.number);

                    foreach (var (number, value) in objects)
                    {
                        var encry = KeyEncrypter == default ? value 
                            : KeyEncrypter.Encrypt(value);

                        sharing.GetByKey(number).SetPixel(x, y,
                             Color.FromArgb(255, encry, encry, encry)
                            );
                    }
                }
            }


            return sharing;
        }
    }
}
