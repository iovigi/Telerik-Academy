using System.Linq;

namespace BiDictionaryCollection
{
    using System;
    using System.Collections.Generic;

    public class BiDictionary<K1, K2, T>
    {
        private Dictionary<K1, List<T>> firstDictionary;
        private Dictionary<K2, List<T>> secondDictionary; 

        public BiDictionary()
        {
            this.firstDictionary = new Dictionary<K1, List<T>>();
            this.secondDictionary = new Dictionary<K2, List<T>>();
        }

        public void Add(K1 key1, K2 key2, T value)
        {
            List<T> firstValues;

            if (!this.firstDictionary.TryGetValue(key1, out firstValues))
            {
                firstValues = new List<T>();
                this.firstDictionary.Add(key1, firstValues);
            }

            firstValues.Add(value);

            List<T> secondValues;

            if (!this.secondDictionary.TryGetValue(key2, out secondValues))
            {
                secondValues = new List<T>();
                this.secondDictionary.Add(key2, secondValues);
            }

            secondValues.Add(value);
        }

        public IEnumerable<T> GetBy(K1 key)
        {
            return this.firstDictionary[key];
        }

        public IEnumerable<T> GetBy(K2 key)
        {
            return this.secondDictionary[key];
        }

        public IEnumerable<T> GetBy(K1 key1,K2 key2)
        {
            var valuesFirst = this.firstDictionary[key1];
            var valuesSecond = this.secondDictionary[key2];

            return valuesFirst.Where(x => valuesSecond.Contains(x));
        }
    }
}
