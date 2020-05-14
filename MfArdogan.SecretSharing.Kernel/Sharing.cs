using System.Collections;
using System.Collections.Generic;

namespace MfArdogan.SecretSharing.Kernel
{
    public class Sharing<T> : IEnumerable<(int number, T value)>
    {
        private Dictionary<int, T> dictionary;
        public Sharing()
        {
            dictionary = new Dictionary<int, T>();
        }
        public Sharing(Dictionary<int, T> dictionary)
           => this.dictionary = dictionary;

        public static Sharing<T> CreateSharingDictionary(IEnumerable<T> ts)
        {
            var key = 0;
            var dictionary = new Dictionary<int, T>();
            foreach (var item in ts)
            {
                dictionary.Add(++key, item);
            }
            return new Sharing<T>(dictionary);
        }
        public bool IsEmpty => dictionary.Count == 0;
        internal T GetByKey(int key) => dictionary[key];
        internal void Add(int key, T share) => dictionary.Add(key, share);

        public IEnumerator<(int number, T value)> GetEnumerator()
        {
            foreach (var item in dictionary)
            {
                yield return (
                    number: item.Key,
                    value: item.Value
                 );
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
