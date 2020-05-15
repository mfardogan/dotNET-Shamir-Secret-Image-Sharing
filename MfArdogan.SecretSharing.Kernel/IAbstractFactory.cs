namespace MfArdogan.SecretSharing.Kernel
{
    public abstract class AbstractFactory<T>
    {
        public abstract SecretSharing<T> GetEncrypter(T data, int n, int k, IKeyEncrypter key);
        public abstract DecrypterKernel<T> GetDecrypter(Sharing<T> shares, IKeyEncrypter key);
    }
}
