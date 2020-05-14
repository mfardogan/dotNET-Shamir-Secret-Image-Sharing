namespace MfArdogan.SecretSharing.Kernel
{
    public interface IKeyEncrypter
    {
        int Encrypt(int plain);
        int Decrypt(int secret);
    }
}
