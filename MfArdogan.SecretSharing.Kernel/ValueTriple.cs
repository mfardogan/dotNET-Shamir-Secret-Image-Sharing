using System.Numerics;

namespace MfArdogan.SecretSharing.Kernel
{
    public class iVector
    {
        public BigInteger x;
        public BigInteger y;
        public BigInteger z;

        public iVector()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public void set(iVector sec)
        {
            this.x = sec.x;
            this.y = sec.y;
            this.z = sec.z;
        }

        public iVector(BigInteger nx, BigInteger ny, BigInteger nz)
        {
            x = nx; y = ny; z = nz;
        }

        public iVector(int nx, int ny, int nz)
        {
            x = nx; y = ny; z = nz;
        }

        public string toString()
        {
            return "(" + x + ", " + y + ", " + z + ")";
        }
    }
}
