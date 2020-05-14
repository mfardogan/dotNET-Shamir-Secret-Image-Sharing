using System.Collections.Generic;
using System.Numerics;

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

        public abstract T Decrypt();

        static BigInteger MathMod(BigInteger a, BigInteger b)
        {
            return (BigInteger.Abs(a * b) + a) % b;
        }

        iVector Evklid(BigInteger a, BigInteger b)
        {
            iVector u = new iVector(a, 1, 0);
            iVector v = new iVector(b, 0, 1);
            iVector T = new iVector(0, 0, 0);
            BigInteger q = 0;

            while (v.x != 0)
            {
                q = u.x / v.x;

                T.x = MathMod(u.x, v.x);

                T.y = u.y - q * v.y;
                T.z = u.z - q * v.z;

                u.set(v); 
                v.set(T); 
            }

            return u;
        }

        public BigInteger DeShamir(Dictionary<BigInteger, BigInteger> pairs ,int p)
        {
            int k = pairs.Count;

            BigInteger secret = new BigInteger(0);
            BigInteger high_part = new BigInteger(1);
            BigInteger low_part = new BigInteger(1);

            foreach (KeyValuePair<BigInteger, BigInteger> first_kv in pairs)
            {
                foreach (KeyValuePair<BigInteger, BigInteger> second_kv in pairs)
                {
                    if (first_kv.Key != second_kv.Key)
                    {
                        high_part = high_part * ((-1) * second_kv.Key);
                        low_part = low_part * (first_kv.Key - second_kv.Key);
                    }
                }


                iVector temp = Evklid(low_part, p);

                low_part = MathMod(temp.y, p);

                high_part = MathMod((high_part * low_part), p); // let high part temporary storage all lart of 'li' (see lagrange interpolation)

                secret += high_part * first_kv.Value; // summ_all( y * li )
                high_part = 1;
                low_part = 1;
            }
            secret = MathMod(secret, p); // Let restrict out sercet by out square. 
            return secret; // Done. You are delicious ^_^
        }

    }
}
