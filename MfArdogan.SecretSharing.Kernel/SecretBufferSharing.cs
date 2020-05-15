using System.Collections.Generic;
using System.Linq;

namespace MfArdogan.SecretSharing.Kernel
{
    public class SecretBufferSharing : SecretSharing<byte[]>
    {
        public byte[] Buffer { get; }
        public SecretBufferSharing(byte[] buffer, int n, int k) : base(n, k)
        {
            Buffer = buffer;
        }

        public SecretBufferSharing(byte[] buffer, int n, int k, IKeyEncrypter keyEncrypter) : base(n, k, keyEncrypter)
        {
            Buffer = buffer;
        }

        public override Sharing<byte[]> Share()
        {
            Sharing<byte[]> shares = Sharing<byte[]>.CreateSharingDictionary(
                   Enumerable.Range(0, NValue).Select(x => new byte[Buffer.Length])
                   );

            for (int i = 0; i < Buffer.Length; i++)
            {
                var nextValue = Buffer[i];
                foreach (KeyValuePair<int, int> pair in ShamirsAlgorithm(nextValue, 255))
                {
                    shares.GetByKey(pair.Key)[i] = (byte)pair.Value;
                }
            }

            return shares;
        }
    }
}
