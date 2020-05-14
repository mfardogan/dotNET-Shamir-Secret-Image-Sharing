using System;
using System.Collections.Generic;
using System.Linq;

namespace MfArdogan.SecretSharing.Kernel
{
    public abstract class SecretSharing<T>
    {
        protected SecretSharing(int n, int k)
        {
            NValue = n; KValue = k;
        }
        protected SecretSharing(int n, int k, IKeyEncrypter keyEncrypter) : this(n, k)
           => KeyEncrypter = keyEncrypter;

        public int NValue { get; }
        public int KValue { get; }
        public IKeyEncrypter KeyEncrypter { get; set; }
        internal RandomNumberGenerator Random { get; set; } = new NumberGenerator();

        public abstract Sharing<T> Share();
        protected Dictionary<int, int> ShamirsAlgorithm(int secret, int mod)
        {
            int abs(int a, int b)
            {
                return (Math.Abs(a * b) + a) % b;
            }

            var keyValuePairs = new Dictionary<int, int>();


            var indexes = Enumerable.Range(0, NValue)
                      .Select(s => abs(s + 1, mod))
                            .ToArray();

            var combines = Enumerable.Range(0, KValue - 1)
                     .Select(s => abs(Math.Abs(Random.Generate((s + 1) * 2)), mod))
                            .ToArray();

            var x = 0;
            for (var i = 0; i < NValue; i++)
            {
                x += secret;

                for (var j = 1; j < KValue; j++)
                {
                    x += combines[j - 1] * (int)Math.Pow(indexes[i], KValue - j);
                }

                keyValuePairs.Add(indexes[i], abs(x, mod));

                x = default;
            }

            return keyValuePairs;
        }
    }
}
