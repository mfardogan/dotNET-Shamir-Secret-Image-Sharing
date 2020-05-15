namespace MfArdogan.SecretSharing.Kernel.Factories
{
    public class FactoryDirector<T>
    {
        private readonly AbstractFactory<T> factory;
        public FactoryDirector(AbstractFactory<T> secretSharingAbstractFactory)
        {
            factory = secretSharingAbstractFactory;
        }

        public SecretSharing<T> GetEncrypter(T data, int n, int k, IKeyEncrypter keyEncrypter) => factory.GetEncrypter(data, n, k, keyEncrypter);
        public DecrypterKernel<T> GetDecrypter(Sharing<T> shares, IKeyEncrypter keyEncrypter) => factory.GetDecrypter(shares, keyEncrypter);
    }
}
