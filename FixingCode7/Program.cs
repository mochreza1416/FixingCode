using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixingCode7
{
    class LRUCache<TKey, TValue>
    {
        private readonly int _capacity;
        private readonly LinkedList<TKey> _accessList = new LinkedList<TKey>();
        private readonly Dictionary<TKey, TValue> _cache = new Dictionary<TKey, TValue>();

        public LRUCache(int capacity)
        {
            _capacity = capacity;
        }

        public void Add(TKey key, TValue value)
        {
            if (_cache.ContainsKey(key))
            {
                _accessList.Remove(key); // Move the key to the end of the access list
            }
            else if (_cache.Count >= _capacity)
            {
                // Evict the least recently used item
                TKey leastRecentlyUsed = _accessList.First.Value;
                _accessList.RemoveFirst();
                _cache.Remove(leastRecentlyUsed);
            }

            _accessList.AddLast(key);
            _cache[key] = value;
        }

        public TValue Get(TKey key)
        {
            if (_cache.TryGetValue(key, out TValue value))
            {
                _accessList.Remove(key); // Move the key to the end of the access list
                _accessList.AddLast(key);
                return value;
            }
            throw new KeyNotFoundException($"Key '{key}' not found in the cache.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            LRUCache<int, object> cache = new LRUCache<int, object>(1000000);
            for (int i = 0; i < 1000000; i++)
            {
                cache.Add(i, new object());
            }
            Console.WriteLine("Cache populated");
            Console.ReadLine();
        }
    }
}
