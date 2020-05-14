using System;
using System.Collections.Generic;
using System.Linq;

namespace MfArdogan.SecretSharing.Kernel
{
    public abstract class SecretSharing<T>
    {
        protected SecretSharing(int n, int k)
        {
            N = n; K = k;
        }
        protected SecretSharing(int n, int k, IKeyEncrypter keyEncrypter) : this(n, k)
           => KeyEncrypter = keyEncrypter;

        public int N { get; }
        public int K { get; }
        public IKeyEncrypter KeyEncrypter { get; set; } 
        internal RandomNumberGenerator Random { get; set; } = new NumberGenerator();

        public abstract Sharing<T> Share();

        protected virtual Dictionary<int, int> Encrypt(int secret, int mod)
        {
            var dictionary = new Dictionary<int, int>();

            Func<int, int, int> modul = (a, b) => (Math.Abs(a * b) + a) % b;

            var xs = Enumerable.Range(0, K)
                .Select(i => modul(Math.Abs(Random.Generate((i + 1) * 2)), mod))
                .ToArray();

            var vs = Enumerable.Range(0, N)
                .Select(i => modul((i + 1), mod))
                .ToArray();

            int x = 0, p;
            for (var i = 0; i < N; i++)
            {
                x = x + secret;

                for (int j = 1; j < K; j++)
                {
                    p = (int)Math.Pow(vs[i], K - j);
                    x += xs[j - 1] * p;
                }

                x = modul(x, mod);

                dictionary.Add(vs[i], x);

                x = 0;
            }
            return dictionary;
        }
    }
}
