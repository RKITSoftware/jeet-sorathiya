using System;
using System.Collections.Generic;

namespace _16_Generic_Collections
{
    internal class Program
    {
        static void Main()
        {
            #region Dictionary<TKey, TValue>
            // Dictionary<TKey, TValue>
            Console.WriteLine("Dictionary<TKey, TValue>");
            Dictionary<string, int> myDictionary = new Dictionary<string, int>();
            myDictionary.Add("One", 1);
            myDictionary.Add("Two", 2);
            myDictionary.Add("Three", 3);

            // Accessing values using keys
            Console.WriteLine("Value for key 'Two': " + myDictionary["Two"]);

            // Checking if a key or value exists
            Console.WriteLine($"Contains key 'Two': {myDictionary.ContainsKey("Two")}");
            Console.WriteLine($"Contains value 3: {myDictionary.ContainsValue(3)}");

            // Iterating over key-value pairs
            Console.WriteLine("\nIterating over key-value pairs:");
            foreach (var kvp in myDictionary)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            // Count property
            Console.WriteLine($"Number of key-value pairs: {myDictionary.Count}");

            // Keys and Values properties
            Console.WriteLine("Keys in the dictionary:");
            foreach (string key in myDictionary.Keys)
            {
                Console.WriteLine(key);
            }

            Console.WriteLine("Values in the dictionary:");
            foreach (int val in myDictionary.Values)
            {
                Console.WriteLine(val);
            }

            // Remove a key
            string keyToRemove = "Two";
            if (myDictionary.ContainsKey(keyToRemove))
            {
                myDictionary.Remove(keyToRemove);
                Console.WriteLine($"Key '{keyToRemove}' removed from the dictionary.");
            }
            else
            {
                Console.WriteLine($"Key '{keyToRemove}' not found in the dictionary.");
            }

            // Clear the dictionary
            myDictionary.Clear();
            Console.WriteLine("Dictionary cleared. Count: " + myDictionary.Count);
            #endregion

            #region List<T>
            // List<T>
            Console.WriteLine("List<T>");
            List<string> myList = new List<string>();
            myList.Add("Apple");
            myList.Add("Banana");
            myList.Add("Orange");

            Console.WriteLine("Items in the list:");
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }

            // Count property
            Console.WriteLine($"Number of items in the list: {myList.Count}");

            // Insert at a specific index
            myList.Insert(1, "Grapes");
            Console.WriteLine("After inserting 'Grapes' at index 1:");
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }

            // Remove item
            myList.Remove("Banana");
            Console.WriteLine("After removing 'Banana':");
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }

            // Clear the list
            myList.Clear();
            Console.WriteLine("\nList cleared. Count: " + myList.Count);

            #endregion

            #region Queue<T>
            // Queue<T>
            Console.WriteLine("\nQueue<T>");
            Queue<int> myQueue = new Queue<int>();
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);

            Console.WriteLine("Dequeue items from the queue:");
            while (myQueue.Count > 0)
            {
                Console.WriteLine(myQueue.Dequeue());
            }

            // Count property
            Console.WriteLine($"Number of items in the queue: {myQueue.Count}");

            // Enqueue more items
            myQueue.Enqueue(4);
            myQueue.Enqueue(5);

            // Peek at the front item without removing
            Console.WriteLine("Peek at the front item without removing:");
            Console.WriteLine(myQueue.Peek());

            // Dequeue again
            Console.WriteLine("Dequeue items from the queue:");
            while (myQueue.Count > 0)
            {
                Console.WriteLine(myQueue.Dequeue());
            }

            // Clear the queue
            myQueue.Clear();
            Console.WriteLine("\nQueue cleared. Count: " + myQueue.Count);

            #endregion

            #region SortedList<TKey, TValue>

            // SortedList<TKey, TValue>
            Console.WriteLine("SortedList<TKey, TValue>");
            SortedList<string, int> mySortedList = new SortedList<string, int>();
            mySortedList.Add("One", 1);
            mySortedList.Add("Three", 3);
            mySortedList.Add("Two", 2);

            Console.WriteLine("Items in the sorted list:");
            foreach (var kvp in mySortedList)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
            // Count property
            Console.WriteLine($"Number of key-value pairs: {mySortedList.Count}");

            // Remove a key
            keyToRemove = "Two";
            if (mySortedList.ContainsKey(keyToRemove))
            {
                mySortedList.Remove(keyToRemove);
                Console.WriteLine($"\nKey '{keyToRemove}' removed from the sorted list.");
            }
            else
            {
                Console.WriteLine($"\nKey '{keyToRemove}' not found in the sorted list.");
            }

            // Clear the sorted list
            mySortedList.Clear();
            Console.WriteLine("\nSortedList cleared. Count: " + mySortedList.Count);

            #endregion

            #region Stack<T>
            // Stack<T>
            Console.WriteLine("Stack<T>");
            Stack<string> myStack = new Stack<string>();
            myStack.Push("First");
            myStack.Push("Second");
            myStack.Push("Third");

            Console.WriteLine("Pop items from the stack:");
            while (myStack.Count > 0)
            {
                Console.WriteLine(myStack.Pop());
            }

            // Count property
            Console.WriteLine($"Number of items in the stack: {myStack.Count}");

            // Push more items
            myStack.Push("Fourth");
            myStack.Push("Fifth");

            // Peek at the top item without removing
            Console.WriteLine("Peek at the top item without removing:");
            Console.WriteLine(myStack.Peek());

            // Pop again
            Console.WriteLine("Pop items from the stack:");
            while (myStack.Count > 0)
            {
                Console.WriteLine(myStack.Pop());
            }

            // Clear the stack
            myStack.Clear();
            Console.WriteLine("\nStack cleared. Count: " + myStack.Count);

            #endregion

            #region  HashSet<T>
            // HashSet<T>
            Console.WriteLine("HashSet<T>");
            HashSet<int> myHashSet = new HashSet<int>();
            myHashSet.Add(1);
            myHashSet.Add(2);
            myHashSet.Add(3);
            myHashSet.Add(2); // Duplicate will be ignored

            Console.WriteLine("Items in the hash set:");
            foreach (var item in myHashSet)
            {
                Console.WriteLine(item);
            }

            // Count property
            Console.WriteLine($"Number of items in the hash set: {myHashSet.Count}");

            // Remove an item
            int itemToRemove = 2;
            if (myHashSet.Contains(itemToRemove))
            {
                myHashSet.Remove(itemToRemove);
                Console.WriteLine($"Item '{itemToRemove}' removed from the hash set.");
            }
            else
            {
                Console.WriteLine($"Item '{itemToRemove}' not found in the hash set.");
            }

            // Clear the hash set
            myHashSet.Clear();
            Console.WriteLine("HashSet cleared. Count: " + myHashSet.Count);

            #endregion

            #region LinkedList<T>
            // LinkedList<T>
            Console.WriteLine("LinkedList<T>");
            LinkedList<int> myLinkedList = new LinkedList<int>();
            myLinkedList.AddLast(1);
            myLinkedList.AddLast(2);
            myLinkedList.AddLast(3);

            Console.WriteLine("Items in the linked list:");
            foreach (var item in myLinkedList)
            {
                Console.WriteLine(item);
            }
            // Count property
            Console.WriteLine($"Number of items in the linked list: {myLinkedList.Count}");

            // Add items to the beginning of the linked list
            myLinkedList.AddFirst(0);
            myLinkedList.AddFirst(-1);

            Console.WriteLine("\nAfter adding items to the beginning:");
            foreach (var item in myLinkedList)
            {
                Console.WriteLine(item);
            }

            // Remove an item from the linked list
            itemToRemove = 2;
            var nodeToRemove = myLinkedList.Find(itemToRemove);
            if (nodeToRemove != null)
            {
                myLinkedList.Remove(nodeToRemove);
                Console.WriteLine($"\nItem '{itemToRemove}' removed from the linked list.");
            }
            else
            {
                Console.WriteLine($"\nItem '{itemToRemove}' not found in the linked list.");
            }

            // Clear the linked list
            myLinkedList.Clear();
            Console.WriteLine("\nLinkedList cleared. Count: " + myLinkedList.Count);

            #endregion
        }
    }
}


