/* RandomHashFunction.cs
 * Author: Ian Flores
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.NameLookup
{
    /// <summary>
    /// The class for RandomHashFunction
    /// </summary>
    [Serializable]
    public class RandomHashFunction : IHashFunction
    {
        /// <summary>
        /// Creates a random number
        /// </summary>
        private static Random _random = new Random();

        /// <summary>
        /// The size of the hash table
        /// </summary>
        private int _tableSize;

        /// <summary>
        /// a0
        /// </summary>
        private int _addedValue;

        /// <summary>
        /// a1
        /// </summary>
        private int _lengthMultiplier;

        /// <summary>
        /// b0-bX
        /// </summary>
        private int[] _multipliers;

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="tableSize">The number of elements in the hash table</param>
        /// <param name="maxLengthKey">The longest key in the hash table</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public RandomHashFunction(int tableSize, int maxLengthKey)
        {
            if (tableSize < 1)
            {
                throw new ArgumentException();
            }
            _tableSize = tableSize;
            int p = Int32.MaxValue;
            _addedValue = _random.Next(p);
            _lengthMultiplier = _random.Next(p);
            _multipliers = new int[maxLengthKey];
            for (int i = 0; i < maxLengthKey; i++)
            {
                _multipliers[i] = _random.Next(p);
            }
        }


        /// <summary>
        /// Computes a hash function for a given key
        /// </summary>
        /// <param name="s">the key</param>
        /// <returns></returns>
        public int Hash(string s)
        {
            int p = Int32.MaxValue;
            long sum = _addedValue + (long)_lengthMultiplier * s.Length;

            if (s.Length > _multipliers.Length)
            {
                return 0;
            }
            for (int i = 0; i < s.Length; i++)
            {
                sum += _multipliers[i] * (long)s[i];
            }
            sum %= p;
            sum %= _tableSize;
            return (int)sum;
        }
    }
}
