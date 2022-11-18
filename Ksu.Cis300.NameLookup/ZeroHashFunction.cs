/*ZeroHashFunction.cs
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
    /// The ZeroHashFunction class
    /// </summary>
    [Serializable]
    public class ZeroHashFunction : IHashFunction
    {
        /// <summary>
        /// The method to compute a hash function of 0 given a string
        /// </summary>
        /// <param name="s">The string</param>
        /// <returns>0</returns>
        public int Hash(string s)
        {
            return 0;
        }
    }
}
