using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

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


        public static BigInteger MathMod(BigInteger a, BigInteger b)
        {
            return (BigInteger.Abs(a * b) + a) % b;
        }

        public BigInteger getRandom(int length)
        {
            Random random = new Random();
            random.Next();
            byte[] data = new byte[length];
            random.NextBytes(data);
            return new BigInteger(data);
        }
        const int p = 251;

        protected Dictionary<BigInteger, BigInteger> ShamirsAlgorithm(BigInteger secret)
        {
            BigInteger[] Koeff = new BigInteger[K - 1];
            BigInteger[] rand_x = new BigInteger[N];

            Dictionary<BigInteger, BigInteger> total_keys = new Dictionary<BigInteger, BigInteger>();

            for (int i = 0; i < K - 1; i++)
                Koeff[i] = MathMod(BigInteger.Abs(getRandom((i + 1) * 2)), p);

            for (int i = 0; i < N; i++)
                rand_x[i] = MathMod((i + 1), p);

            BigInteger result = new BigInteger();
            BigInteger powered = new BigInteger();

            for (int i = 0; i < N; i++)
            {
                result = result + secret;

                for (int j = 1; j < K; j++)
                {
                    powered = BigInteger.Pow(rand_x[i], K - j);
                    result += Koeff[j - 1] * powered;
                }

                result = MathMod(result, p);

                if (!total_keys.ContainsKey(rand_x[i]))
                    total_keys.Add(rand_x[i], result);

                result = 0;
            }
            return total_keys;
        }
    }
}
