namespace MfArdogan.SecretSharing.Kernel.Encrypters
{
    public class BasicRSAKeyEncrypter : IKeyEncrypter
    {
        public int Decrypt(int secret)
        {
            return secret;
        }

        public int Encrypt(int plain)
        {
            return plain;
        }
    }
}
