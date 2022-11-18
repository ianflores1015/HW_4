/* IHashFunction.cs
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
    /// The interface for the IHashFunction
    /// </summary>
    public interface IHashFunction
    {
        /// <summary>
        /// Computes a hash function given a string
        /// </summary>
        /// <param name="s">The string</param>
        /// <returns>The hash function</returns>
        int Hash(String s);
    }
}
