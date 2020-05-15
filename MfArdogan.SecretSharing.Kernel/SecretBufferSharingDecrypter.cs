using System.Collections.Generic;
using System.Linq;

namespace MfArdogan.SecretSharing.Kernel
{
    public class SecretBufferSharingDecrypter : DecrypterKernel<byte[]>
    {
        public SecretBufferSharingDecrypter(Sharing<byte[]> sharing) : base(sharing)
        {
        }

        public SecretBufferSharingDecrypter(IKeyEncrypter keyEncrypter, Sharing<byte[]> sharing) : base(keyEncrypter, sharing)
        {
        }

        private int Decrypt(IEnumerable<(int x, int y)> encrypted)
        {
            var dictionary = new Dictionary<int, int>();
            foreach (var item in encrypted)
            {
                dictionary.Add(item.x, item.y);
            }
            return Lagrance(dictionary, 251);
        }

        public override byte[] Decrypt()
        {
            var buffer = new byte[Sharing.ElementAt(0).value.Length];
            var keyValues = Sharing.Select(
               x => new KeyValuePair<int, byte[]>
                       (x.number, x.value)).ToList();

            var vss = new List<(int x, int y)>();
            for (var y = 0; y < buffer.Length; y++)
            {
                vss.Clear();
                vss.AddRange(keyValues.Select(t => (x: t.Key, y: (int)t.Value[y])));

                var detect = KeyEncrypter == default ? Decrypt(vss) :
                    KeyEncrypter.Decrypt(Decrypt(vss));
                buffer[y] = (byte)detect;
            }

            return buffer;
        }
    }
}
