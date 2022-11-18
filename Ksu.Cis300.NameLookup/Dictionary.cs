/* Dictionary.cs
 * Author: Rod Howell
 * 
 * Edited By: Ian Flores
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.NameLookup
{
    /// <summary>
    /// A generic dictionary in which keys must implement IComparable.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    [Serializable]
    public class Dictionary<TValue>
    {
        /// <summary>
        /// The max key length
        /// </summary>
        private const int _maxKeyLength = 65535;

        /// <summary>
        /// The Value of c + 1
        /// </summary>
        private const double _cPlus1 = 49.0 / 24.0;

        /// <summary>
        /// A hash function equal to zero
        /// </summary>
        private static IHashFunction _zeroHashFunction = new ZeroHashFunction();

        /// <summary>
        /// The primary hash function
        /// </summary>
        private IHashFunction _primaryHashFunction;

        /// <summary>
        /// The primary hash function
        /// </summary>
        private IHashFunction[] _primaryHashTable;

        /// <summary>
        /// The secondary hash table
        /// </summary>
        private KeyValuePair<string, TValue>[] _secondaryHashTables;

        /// <summary>
        /// Gives the offsets of the secondary hash table 
        /// </summary>
        private int[] _offsets;

        /// <summary>
        /// The number of keys in the primary hash table
        /// </summary>
        public int Count { get { return _primaryHashTable.Length; } }

        /// <summary>
        /// The number of keys in the secondary hash table 
        /// </summary>
        public int SecondaryHashTableLength { get; private set; }

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="list">The keys and values to be stored</param>
        public Dictionary(IList<KeyValuePair<string, TValue>> list)
        {
            //Error Checking Block
            if (list == null)
            {
                throw new ArgumentNullException();
            }
            if (list.Count > Int32.MaxValue / _cPlus1)
            {
                throw new ArgumentException("The dictionary has too many elements.");
            }
            foreach (KeyValuePair<string, TValue> pair in list)
            {
                if (pair.Key == null)
                {
                    throw new ArgumentException();
                }
            }

            //Finding the length of of the longest key
            int longestKey = LongestKey(list);


            //Initialize Primary Hash Function
            if (list.Count == 0)
            {
                _primaryHashFunction = new ZeroHashFunction();
                _primaryHashTable = new IHashFunction[1];
                return;
            }

            //Initialize array for temporary hash table
            List<KeyValuePair<string, TValue>>[] hashTableHolder = new List<KeyValuePair<string, TValue>>[list.Count];

            //Finding Primary Hash Function
            long sumOfSquares = 0;
            RandomHashFunction primaryHash = null;
            bool first = true;
            do
            {
                primaryHash = new RandomHashFunction(hashTableHolder.Length, longestKey);
                sumOfSquares = 0;
                for (int i = 0; i < hashTableHolder.Length; i++)
                {
                    hashTableHolder[i] = new List<KeyValuePair<string, TValue>>();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    int currentLocation = primaryHash.Hash(list[i].Key);
                    if (first == true && HasKey(list[i], hashTableHolder, currentLocation))
                    {
                        throw new ArgumentException();
                    }
                    hashTableHolder[currentLocation].Add(list[i]);
                }
                foreach (List<KeyValuePair<string, TValue>> listHolder in hashTableHolder)
                {
                    sumOfSquares += (listHolder.Count * listHolder.Count);
                }
                first = false;
            } while (sumOfSquares > _cPlus1 * list.Count);
            SecondaryHashTableLength = (int)sumOfSquares;
            _primaryHashFunction = primaryHash;

            //Initialize the arrays
            _primaryHashTable = new IHashFunction[list.Count];
            _secondaryHashTables = new KeyValuePair<string, TValue>[SecondaryHashTableLength];
            _offsets = new int[list.Count];

            //Populate arrays
            int sum = 0;
            for (int i = 0; i < hashTableHolder.Length; i++)
            {
                _offsets[i] = sum;

                if (hashTableHolder[i].Count >= 1)
                {
                    int length = hashTableHolder[i].Count * hashTableHolder[i].Count;


                    _primaryHashTable[i] = PopulateSecondHashTable(length, sum, hashTableHolder[i]);
                    sum += length;
                }

            }
        }

        /// <summary>
        /// Checks if a hash table contians a certain key at a certain location
        /// </summary>
        /// <param name="key">the key</param>
        /// <param name="hashTable">the hash table</param>
        /// <param name="location">the location</param>
        /// <returns>if the key is in the hash table</returns>
        private bool HasKey(KeyValuePair<string, TValue> pair, List<KeyValuePair<string, TValue>>[] hashTable, int location)
        {
            for (int i = 0; i < hashTable[location].Count; i++)
            {
                if (hashTable[location][i].Key == pair.Key)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Fills the second hash table
        /// </summary>
        /// <param name="location"></param>
        /// <param name="length"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        private IHashFunction PopulateSecondHashTable(int length, int location, IList<KeyValuePair<string, TValue>> list)
        {
            bool isPerfect = false;
            if (list.Count == 1)
            {
                _secondaryHashTables[location] = list[0];
                return _zeroHashFunction;
            }
            else
            {
                IHashFunction random = null;
                int longestKey = LongestKey(list);
                while(isPerfect == false)
                {
                    isPerfect = true;
                    random = new RandomHashFunction(length, longestKey);
                    foreach(KeyValuePair<string, TValue> pair in list)
                    {
                        int currentLocation = location + random.Hash(pair.Key);
                        if (_secondaryHashTables[currentLocation].Key != null)
                        {
                            isPerfect = false;
                            for(int j = location; j < location + length; j++)
                            {
                                _secondaryHashTables[j] = new KeyValuePair<string, TValue>();
                            }
                        }
                        else
                        {
                            _secondaryHashTables[currentLocation] = pair;
                        }

                    }
                }
                return random;
            }
        }

        /// <summary>
        /// Checks for a certain key and outputs its value
        /// </summary>
        /// <param name="key">the key</param>
        /// <param name="value">the value</param>
        /// <returns>if the key is found or not</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool TryGetValue(string key, out TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                int hashVal = _primaryHashFunction.Hash(key);
                IHashFunction secondaryHash = _primaryHashTable[hashVal];
                if (secondaryHash == null)
                {
                    value = default(TValue);
                    return false;
                }
                else
                {
                    int secondHashVal = secondaryHash.Hash(key);
                    secondHashVal = (secondHashVal + _offsets[hashVal]);
                    if (key == _secondaryHashTables[secondHashVal].Key)
                    {
                        value = _secondaryHashTables[secondHashVal].Value;
                        return true;
                    }
                    else
                    {
                        value = default(TValue);
                        return false;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Finds the longest key in a list
        /// </summary>
        /// <param name="list">The list</param>
        /// <returns>The longest key</returns>
        /// <exception cref="ArgumentException"></exception>
        private int LongestKey(IList<KeyValuePair<string, TValue>> list)
        {
            int longestKey = 0;
            foreach (KeyValuePair<string, TValue> pair in list)
            {
                if (pair.Key.Length > longestKey)
                {
                    longestKey = pair.Key.Length;
                }
            }
            if (longestKey > _maxKeyLength)
            {
                throw new ArgumentException("A key is longer than 65535.");
            }
            return longestKey;
        }
    }
}
