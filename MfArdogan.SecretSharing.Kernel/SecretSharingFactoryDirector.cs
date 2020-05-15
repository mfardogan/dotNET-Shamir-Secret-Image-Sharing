namespace MfArdogan.SecretSharing.Kernel
{
    public class SecretSharingFactoryDirector<T>
    {
        private readonly AbstractFactory<T> factory;
        public SecretSharingFactoryDirector(AbstractFactory<T> secretSharingAbstractFactory)
        {
            factory = secretSharingAbstractFactory;
        }

        public SecretSharing<T> GetEncrypter(T data, int n, int k, IKeyEncrypter keyEncrypter) => factory.GetEncrypter(data, n, k, keyEncrypter);
        public DecrypterKernel<T> GetDecrypter(Sharing<T> shares, IKeyEncrypter keyEncrypter) => factory.GetDecrypter(shares, keyEncrypter);
    }
}
