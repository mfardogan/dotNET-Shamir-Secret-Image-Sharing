using System;
using System.Numerics;

namespace MfArdogan.SecretSharing.Kernel
{
    internal class NumberGenerator : RandomNumberGenerator
    {
        public override int Generate(int lenght)
        {
            Random random = new Random();
            random.Next();
            byte[] data = new byte[lenght];
            random.NextBytes(data);
            return (int)new BigInteger(data);
        }
    }
}
