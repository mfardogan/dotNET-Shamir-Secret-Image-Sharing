using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MfArdogan.SecretSharing.Kernel
{
    public class SharingIterator<T> : IEnumerator<(int number, T data)>
    {
        private int x = 0;
        private readonly Dictionary<int, T> dict;
        public SharingIterator(Dictionary<int, T> dict)
        {
            this.dict = dict;
        }

        public (int number, T data) Current
        {
            get
            {
                var next = dict.ElementAt(x++);
                return (number: next.Key, data: next.Value);
            }
        }

        public void Dispose()
        {
        }
        object IEnumerator.Current => Current;
        public bool MoveNext() => x < dict.Count;
        public void Reset() => x = default;
    }
}
