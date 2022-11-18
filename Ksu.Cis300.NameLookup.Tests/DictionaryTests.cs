/* DictionaryTests.cs
 * Author: Rod Howell, Josh Weese
 */
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ksu.Cis300.NameLookup.Tests
{
    /// <summary>
    /// Unit tests for the Dictionary class.
    /// </summary>
    [TestFixture]
    public class DictionaryTests
    {
        /// <summary>
        /// A list containing the data from names-short.txt
        /// </summary>
        private IList<KeyValuePair<string, FrequencyAndRank>> _pairs = new KeyValuePair<string, FrequencyAndRank>[5]
            {
                new KeyValuePair<string, FrequencyAndRank>("ABRAMS", new FrequencyAndRank(0.009f, 1369)),
                new KeyValuePair<string, FrequencyAndRank>("BERGEN", new FrequencyAndRank(0.002f, 5319)),
                new KeyValuePair<string, FrequencyAndRank>("CLIVE", new FrequencyAndRank(0f, 44242)),
                new KeyValuePair<string, FrequencyAndRank>("DION", new FrequencyAndRank(0.004f, 3315)),
                new KeyValuePair<string, FrequencyAndRank>("EPSTEIN", new FrequencyAndRank(0.004f, 3264))
            };

        /// <summary>
        /// Tries to construct a RandomHashFunction with a negative table length.
        /// This should throw an ArgumentException.
        /// </summary>
        [Category("A-RandomHash")]
        [Test, Timeout(1000)]
        public void TestARandomHashNegativeLength()
        {
            Exception e = null;
            try
            {
                IHashFunction h = new RandomHashFunction(-1, 5);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.That(e, Is.Not.Null.And.TypeOf(typeof(ArgumentException)));
        }

        /// <summary>
        /// Tries to construct a RandomHashFunction with a table length of 0.
        /// This should throw an ArgumentException.
        /// </summary>
        [Category("A-RandomHash")]
        [Test, Timeout(1000)]
        public void TestARandomHashZeroLength()
        {
            Exception e = null;
            try
            {
                IHashFunction h = new RandomHashFunction(0, 5);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.That(e, Is.Not.Null.And.TypeOf(typeof(ArgumentException)));
        }

        /// <summary>
        /// Checks that a random hash function produces zero on a key longer than
        /// its max.
        /// </summary>
        [Category("A-RandomHash")]
        [Test, Timeout(1000)]
        public void TestARandomHashLongKey()
        {
            Assert.That(new RandomHashFunction(1000, 2).Hash("abc"), Is.Zero);
        }

        /// <summary>
        /// Tests that a ZeroHashFunction returns 0.
        /// </summary>
        [Category("B-ZeroHash")]
        [Test, Timeout(1000)]
        public void TestBZeroHashFunctionReturnsZero()
        {
            Assert.That(new ZeroHashFunction().Hash("abcde"), Is.Zero);
        }

        /// <summary>
        /// Tries to construct a dictionary with a null list of pairs.
        /// This should throw an ArgumentNullException.
        /// </summary>
        [Category("C-Errors")]
        [Test, Timeout(1000)]
        public void TestCNullList()
        {
            Exception e = null;
            try
            {
                Dictionary<int> d = new Dictionary<int>(null);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.That(e, Is.Not.Null.And.TypeOf(typeof(ArgumentNullException)));
        }

        /// <summary>
        /// Tries to construct a dictionary from a list containing a null key.
        /// This should throw an ArgumentException.
        /// </summary>
        [Category("C-Errors")]
        [Test, Timeout(1000)]
        public void TestCListContainsNullKey()
        {
            IList<KeyValuePair<string, FrequencyAndRank>> list = _pairs.ToList();
            list[3] = new KeyValuePair<string, FrequencyAndRank>(null, new FrequencyAndRank());
            Exception e = null;
            try
            {
                Dictionary<FrequencyAndRank> d = new Dictionary<FrequencyAndRank>(list);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.That(e, Is.Not.Null.And.TypeOf(typeof(ArgumentException)));
        }

        /// <summary>
        /// Tries to construct a dictionary using a list that is too long.
        /// This should throw an ArgumentException with the message:
        /// "The dictionary has too many elements."
        /// </summary>
        [Category("C-Errors")]
        [Test, Timeout(1000)]
        public void TestCHugeList()
        {
            Exception e = null;
            try
            {
                Dictionary<int> d = new Dictionary<int>(new HugeList());
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.Multiple(() =>
            {
                Assert.That(e, Is.Not.Null.And.TypeOf(typeof(ArgumentException)));
                Assert.That(e.Message, Is.EqualTo("The dictionary has too many elements."));
            });
        }

        /// <summary>
        /// Tries to construct a dictionary using a list that is too long.
        /// This should throw an ArgumentException with the message:
        /// "A key is longer than 65535."
        /// </summary>
        [Category("C-Errors")]
        [Test, Timeout(1000)]
        public void TestCTooLongKey()
        {
            Exception e = null;
            List<KeyValuePair<string, FrequencyAndRank>> list = new List<KeyValuePair<string, FrequencyAndRank>>();
            list.Add(new KeyValuePair<string, FrequencyAndRank>(new string('W', 65536), new FrequencyAndRank(1, 1)));
            try
            {
                Dictionary<FrequencyAndRank> d = new Dictionary<FrequencyAndRank>(list);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.Multiple(() =>
            {
                Assert.That(e, Is.Not.Null.And.TypeOf(typeof(ArgumentException)));
                Assert.That(e.Message, Is.EqualTo("A key is longer than 65535."));
            });
        }

        /// <summary>
        /// Checks that if a pair of duplicate keys is given to the dictionary constructor,
        /// the proper exception is thrown.
        /// </summary>
        [Category("C-Errors")]
        [Test, Timeout(1000)]
        public void TestC2DuplicateKeys()
        {
            IList<KeyValuePair<string, FrequencyAndRank>> list = _pairs.ToList();
            list[4] = new KeyValuePair<string, FrequencyAndRank>(list[1].Key, list[4].Value);
            Exception e = null;
            try
            {
                Dictionary<FrequencyAndRank> d = new Dictionary<FrequencyAndRank>(list);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.That(e, Is.Not.Null.And.TypeOf(typeof(ArgumentException)));
        }

        /// <summary>
        /// Checks that if the dictionary constructor is given the same key 3 times, the 
        /// proper exception is thrown.
        /// </summary>
        [Category("C-Errors")]
        [Test, Timeout(1000)]
        public void TestC3DuplicateKeys()
        {
            IList<KeyValuePair<string, FrequencyAndRank>> list = _pairs.ToList();
            list[3] = new KeyValuePair<string, FrequencyAndRank>(list[1].Key, list[3].Value);
            list[4] = new KeyValuePair<string, FrequencyAndRank>(list[1].Key, list[4].Value);
            Exception e = null;
            try
            {
                Dictionary<FrequencyAndRank> d = new Dictionary<FrequencyAndRank>(list);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.That(e, Is.Not.Null.And.TypeOf(typeof(ArgumentException)));
        }



        /// <summary>
        /// Constructs an empty dictionary and tries to look up a key.
        /// </summary>
        [Category("D-Lookup")]
        [Test, Timeout(1000)]
        public void TestDLookUpEmpty()
        {
            Dictionary<int> d = new Dictionary<int>(new List<KeyValuePair<string, int>>());
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue("Name", out int v), Is.False);
                Assert.That(v, Is.Zero);
            });
        }

        /// <summary>
        /// Constructs an empty dictionary and tries to look up a key.
        /// </summary>
        [Category("D-Lookup"), Category("C-Errors")]
        [Test, Timeout(1000)]
        public void TestDLookUpNull()
        {
            Dictionary<int> d = new Dictionary<int>(new List<KeyValuePair<string, int>>());
            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentNullException>(() => d.TryGetValue(null, out int v));
            });
        }

        /// <summary>
        /// Tests the Count property.
        /// </summary>
        [Category("D-Lookup")]
        [Test, Timeout(1000)]
        public void TestD1Count()
        {
            Assert.That(new Dictionary<FrequencyAndRank>(_pairs).Count, Is.EqualTo(5));
        }

        /// <summary>
        /// Builds a dictionary containing the data from names-short.txt, 
        /// then looks up each one and one that isn't present.
        /// </summary>
        [Category("D-Lookup")]
        [Test, Timeout(1000)]
        public void TestDLookUp5()
        {
            Dictionary<FrequencyAndRank> d = new Dictionary<FrequencyAndRank>(_pairs);
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(_pairs[0].Key, out FrequencyAndRank v), Is.True);
                Assert.That(v, Is.EqualTo(_pairs[0].Value));
                Assert.That(d.TryGetValue(_pairs[1].Key, out v), Is.True);
                Assert.That(v, Is.EqualTo(_pairs[1].Value));
                Assert.That(d.TryGetValue(_pairs[2].Key, out v), Is.True);
                Assert.That(v, Is.EqualTo(_pairs[2].Value));
                Assert.That(d.TryGetValue(_pairs[3].Key, out v), Is.True);
                Assert.That(v, Is.EqualTo(_pairs[3].Value));
                Assert.That(d.TryGetValue(_pairs[4].Key, out v), Is.True);
                Assert.That(v, Is.EqualTo(_pairs[4].Value));
                Assert.That(d.TryGetValue("MISSING", out v), Is.False);
                Assert.That(v, Is.EqualTo(new FrequencyAndRank()));
            });
        }

        /// <summary>
        /// Builds a dictionary from the data in names-short.txt 100 times.
        /// For each dictionary, checks that its secondary hash table length is
        /// either 5, 7, or 9, and that each key is present.
        /// </summary>
        [Category("D-Lookup")]
        [Test, Timeout(1000)]
        public void TestDRepeatedConstructLookup()
        {
            string msg = null;
            for (int i = 0; msg == null && i < 100; i++)
            {
                Dictionary<FrequencyAndRank> d = new Dictionary<FrequencyAndRank>(_pairs);
                if (d.SecondaryHashTableLength != 5 && d.SecondaryHashTableLength != 7 && d.SecondaryHashTableLength != 9)
                {
                    msg = "Secondary hash table length of " + d.SecondaryHashTableLength;
                    break;
                }
                foreach (KeyValuePair<string, FrequencyAndRank> p in _pairs)
                {
                    if (!d.TryGetValue(p.Key, out FrequencyAndRank v))
                    {
                        msg = "Couldn't find " + p.Key;
                        break;
                    }
                }
            }
            Assert.That(msg, Is.Null);
        }

        /// <summary>
        /// Constructs dictionaries from names-short.txt until a secondary hash table
        /// length of 5 is achieved.
        /// </summary>
        [Category("E-SecondaryHash")]
        [Test, Timeout(1000)]
        public void TestESecondaryHashTableLength5()
        {
            Dictionary<FrequencyAndRank> d;
            do
            {
                d = new Dictionary<FrequencyAndRank>(_pairs);
            } while (d.SecondaryHashTableLength != 5);
            Assert.Pass();
        }

        /// <summary>
        /// Constructs dictionaries from names-short.txt until a secondary hash table
        /// length of 7 is achieved.
        /// </summary>
        [Category("E-SecondaryHash")]
        [Test, Timeout(1000)]
        public void TestESecondaryHashTableLength7()
        {
            Dictionary<FrequencyAndRank> d;
            do
            {
                d = new Dictionary<FrequencyAndRank>(_pairs);
            } while (d.SecondaryHashTableLength != 7);
            Assert.Pass();
        }

        /// <summary>
        /// Constructs dictionaries from names-short.txt until a secondary hash table
        /// length of 9 is achieved.
        /// </summary>
        [Category("E-SecondaryHash")]
        [Test, Timeout(1000)]
        public void TestESecondaryHashTableLength9()
        {
            Dictionary<FrequencyAndRank> d;
            do
            {
                d = new Dictionary<FrequencyAndRank>(_pairs);
            } while (d.SecondaryHashTableLength != 5);
            Assert.Pass();
        }
    }
}