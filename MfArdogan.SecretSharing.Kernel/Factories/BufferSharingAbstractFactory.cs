namespace MfArdogan.SecretSharing.Kernel.Factories
{
    public class BufferSharingAbstractFactory : AbstractFactory<byte[]>
    {
        public override DecrypterKernel<byte[]> GetDecrypter(Sharing<byte[]> shares, IKeyEncrypter key)
        {
            return new SecretBufferSharingDecrypter(shares, key);
        }

        public override SecretSharing<byte[]> GetEncrypter(byte[] data, int n, int k, IKeyEncrypter key)
        {
            return new SecretBufferSharing(data, n, k, key);
        }
    }
}
