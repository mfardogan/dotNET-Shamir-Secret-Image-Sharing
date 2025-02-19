﻿using System.Drawing;

namespace MfArdogan.SecretSharing.Kernel.Factories
{
    public class ImageSharingAbstractFactory : AbstractFactory<Bitmap>
    {
        public override DecrypterKernel<Bitmap> GetDecrypter(Sharing<Bitmap> shares, IKeyEncrypter key)
        {
            return new SecretImageSharingDecrypter(shares, key);
        }

        public override SecretSharing<Bitmap> GetEncrypter(Bitmap data, int n, int k, IKeyEncrypter key)
        {
            return new SecretImageSharing(data, n, k, key);
        }
    }
}
