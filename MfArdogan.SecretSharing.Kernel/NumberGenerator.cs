using System;

namespace MfArdogan.SecretSharing.Kernel
{
    internal class NumberGenerator : RandomNumberGenerator
    {
        public override int Generate(int lenght)
        {
            var random = new Random();
            return random.Next();
        }
    }
}
