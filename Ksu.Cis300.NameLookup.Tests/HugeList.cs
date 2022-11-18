/* HugeList.cs
 * Author: Rod Howell
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.NameLookup.Tests
{
    /// <summary>
    /// Mimics a list of key-value-pairs containing Int32.MaxValue / 2 + 1 elements
    /// in a space-efficient way.
    /// </summary>
    public class HugeList : IList<KeyValuePair<string, int>>
    {
        /// <summary>
        /// Gets the pair at the given index. The set accessor is not implemented.
        /// </summary>
        /// <param name="index">The index from which to retrieve the pair.</param>
        /// <returns>The pair at the given indes.</returns>
        public KeyValuePair<string, int> this[int index] { get => new KeyValuePair<string, int>(index.ToString(), index); 
            set => throw new NotImplementedException(); }

        /// <summary>
        /// The number of elements in the list.
        /// </summary>
        public int Count => Int32.MaxValue / 2 + 1;

        /// <summary>
        /// Gets whether this list is read-only (it is).
        /// </summary>
        public bool IsReadOnly => true;

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="item"></param>
        public void Add(KeyValuePair<string, int> item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public void Clear()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns whether the list contains the given pair.
        /// </summary>
        /// <param name="item">The pair to look for.</param>
        /// <returns>Whether the list contains item.</returns>
        public bool Contains(KeyValuePair<string, int> item)
        {
            return item.Key == item.Value.ToString();
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(KeyValuePair<string, int>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an enumerator for this list.
        /// </summary>
        /// <returns>An enumerator for this list.</returns>
        public IEnumerator<KeyValuePair<string, int>> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return new KeyValuePair<string, int>(i.ToString(), i);
            }
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(KeyValuePair<string, int> item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, KeyValuePair<string, int> item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(KeyValuePair<string, int> item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an enumerator for this list.
        /// </summary>
        /// <returns>An enumerator for this list.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
