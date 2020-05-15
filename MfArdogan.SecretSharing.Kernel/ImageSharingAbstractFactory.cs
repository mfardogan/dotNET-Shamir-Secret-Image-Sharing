using System.Drawing;

namespace MfArdogan.SecretSharing.Kernel
{
    public class ImageSharingAbstractFactory : AbstractFactory<Bitmap>
    {
        public override DecrypterKernel<Bitmap> GetDecrypter(Sharing<Bitmap> shares, IKeyEncrypter key)
        {
            return new SecretImageSharingDecrypter(key, shares);
        }

        public override SecretSharing<Bitmap> GetEncrypter(Bitmap data, int n, int k, IKeyEncrypter key)
        {
            return new SecretImageSharing(data, n, k, key);
        }
    }
}
