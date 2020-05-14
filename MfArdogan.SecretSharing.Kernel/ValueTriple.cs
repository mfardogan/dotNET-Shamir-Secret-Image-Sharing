namespace MfArdogan.SecretSharing.Kernel
{
    internal class ValueTriple
    {
        public int x;
        public int y;
        public int z;

        public ValueTriple()
        { }

        public ValueTriple(int nx, int ny, int nz)
        {
            x = nx;
            y = ny;
            z = nz;
        }


        public void set(ValueTriple sec)
        {
            x = sec.x;
            y = sec.y;
            z = sec.z;
        }
    }
}
