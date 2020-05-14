namespace MfArdogan.SecretSharing.Kernel
{
    public class XorKeyEncrypter : IKeyEncrypter
    {
        public XorKeyEncrypter()
        {
        }

        public XorKeyEncrypter(int xor)
          => Xor = xor;

        public int Xor { get; set; }
        public int Decrypt(int secret)
        {
            return secret ^ Xor;
        }

        public int Encrypt(int plain)
        {
            return plain ^ Xor;
        }
    }
}
