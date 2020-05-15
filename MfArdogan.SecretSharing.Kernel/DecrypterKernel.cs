using System;
using System.Collections.Generic;

namespace MfArdogan.SecretSharing.Kernel
{
    public abstract class DecrypterKernel<T>
    {
        protected DecrypterKernel(Sharing<T> sharing)
           => Sharing = sharing;

        protected DecrypterKernel(IKeyEncrypter keyEncrypter, Sharing<T> sharing)
        {
            KeyEncrypter = keyEncrypter;
            Sharing = sharing;
        }

        public IKeyEncrypter KeyEncrypter { get; set; }
        public Sharing<T> Sharing { get; set; }

        /// <summary>
        /// Decrypt secret data with K part as T data type.
        /// </summary>
        /// <returns></returns>
        public abstract T Decrypt();

        protected int Lagrance(Dictionary<int, int> keyValuePairs, int mod)
        {
            Func<int, int, int> abs = (a, b) => (Math.Abs(a * b) + a) % b;

            Func<int, int, ValueTriple> triple = (a, b) =>
            {
                var left = new ValueTriple(a, 1, 0);
                var right = new ValueTriple(b, 0, 1);
                var reel = new ValueTriple(0, 0, 0);
                while (right.x != 0)
                {
                    int q = left.x / right.x;
                    reel.x = abs(left.x, right.x);

                    reel.y = left.y - q * right.y;
                    reel.z = left.z - q * right.z;

                    left.set(right);
                    right.set(reel);
                }

                return left;
            };

            int secret = 0, x = 1, y = 1;
            foreach (KeyValuePair<int, int> part in keyValuePairs)
            {
                foreach (KeyValuePair<int, int> other in keyValuePairs)
                {
                    if (part.Key != other.Key)
                    {
                        x = x * (-1) * other.Key;
                        y = y * (part.Key - other.Key);
                    }
                }

                ValueTriple temp = triple(y, mod);

                y = abs(temp.y, mod);
                x = abs(x * y, mod);

                secret += x * part.Value;
                x = 1;
                y = 1;
            }

            return abs(secret, mod);
        }
    }
}
