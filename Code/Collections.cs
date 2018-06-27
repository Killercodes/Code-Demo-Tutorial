using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

namespace CollectionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //LegacyCollections();
            //LegacyDictionaries();
            //GenericCollections();
            //Sorting();
        }

        static void PrintCollection(IEnumerable list)
        {
            foreach (object o in list)
                Console.WriteLine(o);
        }

        static void LegacyCollections()
        {
            // ArrayList (like an array but dynamically resized)
            ArrayList arrayList = new ArrayList();
            arrayList.Add("ArrayList Two");
            arrayList.Add("ArrayList One");
            arrayList.Sort();

            foreach (object o in arrayList)
                Console.WriteLine(o);

            // StringCollection (like ArrayList but strongly typed to string)
            StringCollection stringCollection = new StringCollection();
            stringCollection.Add("stringCollection One");
            stringCollection.Add("stringCollection Two");

            foreach (string o in stringCollection)
                Console.WriteLine(o);

            // Queue (FIFO)
            Queue queue = new Queue();
            queue.Enqueue("Queue One");
            queue.Enqueue("Queue Two");

            for (int i = 0; i <= queue.Count; i++)
                Console.WriteLine(queue.Dequeue());

            // Stack (LIFO)
            Stack stack = new Stack();
            stack.Push("Stack One");
            stack.Push("Stack Two");

            for (int i = 0; i <= stack.Count; i++)
                Console.WriteLine(stack.Pop());

            // BitArray (unlimited array of bits)
            BitArray bitArray = new BitArray(2);
            bitArray[0] = false;
            bitArray[1] = true;

            for (int i = 0; i < bitArray.Count; i++)
                Console.WriteLine("BitArray {0}", bitArray[i]);
        }

        static void LegacyDictionaries()
        {
            // Hashtable (dictionary with unique keys)
            Hashtable hashtable = new Hashtable();
            hashtable.Add("Key1", "Hashtable 1");
            hashtable.Add("Key2", "Hashtable 2");
            
            foreach (DictionaryEntry item in hashtable)
                Console.WriteLine("{0}: {1}", item.Key, item.Value);

            // SortedList (sorted dictionary with unique keys)
            SortedList sortedList = new SortedList();
            sortedList.Add("Key2", "SortedList 2");
            sortedList.Add("Key1", "SortedList 1");

            foreach (DictionaryEntry item in sortedList)
                Console.WriteLine("{0}: {1}", item.Key, item.Value);

            // ListDictionary (dictionary with unique keys - optimized for a maximum of 10 items)
            ListDictionary listDictionary = new ListDictionary();
            listDictionary.Add("Key1", "ListDictionary 1");
            listDictionary.Add("Key2", "ListDictionary 2");

            foreach (DictionaryEntry item in listDictionary)
                Console.WriteLine("{0}: {1}", item.Key, item.Value);

            // HybridDictionary (dictionary with unique keys - starts as a ListDictionary,
            // transforms into a Hashtable upon the eleventh entry)
            HybridDictionary hybridDictionary = new HybridDictionary();
            hybridDictionary.Add("Key1", "HybridDictionary 1");
            hybridDictionary.Add("Key2", "HybridDictionary 2");

            foreach (DictionaryEntry item in hybridDictionary)
                Console.WriteLine("{0}: {1}", item.Key, item.Value);

            // NameValueCollection (dictionary with support for multiple keys)
            NameValueCollection nameValueCollection = new NameValueCollection();
            nameValueCollection.Add("Key1", "NameValueCollection 1");
            nameValueCollection.Add("Key2", "NameValueCollection 2");
            nameValueCollection.Add("Key2", "NameValueCollection 3");

            foreach (string key in nameValueCollection)
            {
                Console.WriteLine("{0}:", key);
                foreach (object item in nameValueCollection.GetValues(key))
                    Console.WriteLine("\t{0}", item);
            }
        }

        static void GenericCollections()
        {
            // List<T> (replaces ArrayList, StringCollection)
            List<string> list = new List<string>();
            list.Add("List<T> Two");
            list.Add("List<T> One");
            list.Sort();

            foreach (string s in list)
                Console.WriteLine(s);

            // Dictionary<T,U> (replaces all dictionaries)
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "Dictionary<T,U> 1");
            dictionary.Add(2, "Dictionary<T,U> 2");

            foreach (KeyValuePair<int, string> item in dictionary)
                Console.WriteLine("{0}: {1}", item.Key, item.Value);

            // Queue<T> (replaces Queue)
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Queue<T> One");
            queue.Enqueue("Queue<T> Two");

            for (int i = 0; i <= queue.Count; i++)
                Console.WriteLine(queue.Dequeue());

            // Stack<T> (replaces Stack)
            Stack<string> stack = new Stack<string>();
            stack.Push("Stack<T> One");
            stack.Push("Stack<T> Two");

            for (int i = 0; i <= stack.Count; i++)
                Console.WriteLine(stack.Pop());

            // SortedList<T, U> (replaces SortedList)
            SortedList<int, string> sortedList = new SortedList<int, string>();
            sortedList.Add(2, "Stack<T, U> Two");
            sortedList.Add(1, "Stack<T, U> One");

            foreach (KeyValuePair<int, string> item in sortedList)
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
        }

        static void Sorting()
        {
            List<string> list = new List<string>();
            list.Add("List<T> One");
            list.Add("List<T> Two");

            list.Sort(new DescendingComparer());

            foreach (string s in list)
                Console.WriteLine(s);
        }

        class DescendingComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return y.CompareTo(x);
            }
        }
    }
}
