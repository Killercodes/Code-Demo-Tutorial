using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnumeratorDemo
{
    class Program
    {
        /// <summary>
        /// Mains the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        static void Main(string[] args)
        {
            EnumerateGeneric(new MyManualCollection());
            EnumerateNonGeneric(new MyManualCollection());

            EnumerateGeneric(new MyIteratorCollection());
            EnumerateNonGeneric(new MyIteratorCollection());
        }

        static void EnumerateGeneric(IEnumerable<int> items)
        {
            foreach (var item in items)
                Console.WriteLine(item);
        }

        static void EnumerateNonGeneric(System.Collections.IEnumerable items)
        {
            foreach (var item in items)
                Console.WriteLine(item);
        }
    }

    // A manually implemented collection
    class MyManualCollection: IEnumerator<int>, IEnumerable<int>
    {
        int currentPos = -1;
        int[] data = new int[] {1, 2, 3};

        #region IEnumerator<T> members
        public int Current
        {
            get { return data[currentPos]; }
        }

        public void Dispose()
        {
            // Used very rarely (usable when iterating DB rows, files etc.)
        }

        object System.Collections.IEnumerator.Current
        {
            // Used when typed as the non-generic System.Collections.IEnumerable interface
            get { return Current; }
        }

        public bool MoveNext()
        {
            if (currentPos < data.Length - 1)
            {
                currentPos++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            currentPos = -1;
        }
        #endregion

        #region IEnumerator<T> members
        public IEnumerator<int> GetEnumerator()
        {
            return this;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            // Used when typed as the non-generic System.Collections.IEnumerable interface
            return GetEnumerator();
        }
        #endregion
    }

    // A collection implemented using an iterator
    class MyIteratorCollection : IEnumerable<int>
    {
        int[] data = new int[] { 1, 2, 3 };

        #region IEnumerator<T> members
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < data.Length; i++)
                yield return data[i];
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            // Used when typed as the non-generic System.Collections.IEnumerable interface            
            return GetEnumerator();
        }
        #endregion
    }
}
