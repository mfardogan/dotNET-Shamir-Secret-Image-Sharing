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
            var inputArrayAsMatrix = Image.ToGrayScaleMatrix();
            var sharing = Sharing<Bitmap>.CreateSharingDictionary(
                Enumerable.Range(1, NValue).Select(
                             x => new Bitmap(Image.Width, Image.Height)
                        ));

            for (var x = 0; x < Image.Width; x++)
            {
                for (var y = 0; y < Image.Height; y++)
                {
                    var secret = inputArrayAsMatrix[x, y];

                    IEnumerable<(int number, int value)> injector = ShamirsAlgorithm(secret,251)
                         .Select(next =>
                               (number: next.Key, value: next.Value)
                         );

                    foreach (var (number, value) in injector)
                    {
                        var pass = KeyEncrypter == default ? value
                            : KeyEncrypter.Encrypt(value);

                        sharing.GetByKey(number).SetPixel(x, y,
                           Color.FromArgb(255, pass, pass, pass)
                        );
                    }
                }
            }

            return sharing;
        }
    }
}
