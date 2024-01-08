using System;
using System.Collections;

namespace _16._2_Non_Generic_collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region ArrayList
            // Creating an ArrayList
            ArrayList myArrayList = new ArrayList();

            // Adding elements
            myArrayList.Add(10);
            myArrayList.Add("Hello");
            myArrayList.Add(3.14);

            // Accessing elements
            Console.WriteLine("Elements in the ArrayList:");
            foreach (var item in myArrayList)
            {
                Console.WriteLine(item);
            }

            // Inserting an element at a specific index
            myArrayList.Insert(1, "InsertedElement");

            // Accessing elements after insertion
            Console.WriteLine("Elements after insertion:");
            foreach (var item in myArrayList)
            {
                Console.WriteLine(item);
            }

            // Checking if an element exists
            bool containsHello = myArrayList.Contains("Hello");
            Console.WriteLine($"ArrayList contains 'Hello': {containsHello}");

            // Finding the index of an element
            int indexHello = myArrayList.IndexOf("Hello");
            Console.WriteLine($"Index of 'Hello': {indexHello}");

            // Removing an element
            myArrayList.Remove(3.14);

            // Accessing elements after removal
            Console.WriteLine("Elements after removal:");
            foreach (var item in myArrayList)
            {
                Console.WriteLine(item);
            }

            // Clearing the ArrayList
            myArrayList.Clear();

            // Displaying the count after clearing
            Console.WriteLine("ArrayList cleared. Count: " + myArrayList.Count);
            #endregion

            #region Hashtable
            // Creating a Hashtable
            Hashtable myHashtable = new Hashtable();

            // Adding key/value pairs
            myHashtable.Add("Key1", 42);
            myHashtable.Add("Key2", "Hello");
            myHashtable.Add("Key3", 3.14);

            // Accessing values by key
            Console.WriteLine("Values in the Hashtable:");
            foreach (var key in myHashtable.Keys)
            {
                Console.WriteLine($"Key: {key}, Value: {myHashtable[key]}");
            }

            // Checking if a key exists
            bool containsKey = myHashtable.ContainsKey("Key2");
            Console.WriteLine($"Hashtable contains key 'Key2': {containsKey}");

            // Checking if a value exists
            bool containsValue = myHashtable.ContainsValue(3.14);
            Console.WriteLine($"Hashtable contains value 3.14: {containsValue}");

            // Removing a key/value pair
            myHashtable.Remove("Key1");

            // Accessing values after removal
            Console.WriteLine("Values after removal:");
            foreach (var key in myHashtable.Keys)
            {
                Console.WriteLine($"Key: {key}, Value: {myHashtable[key]}");
            }

            // Clearing the Hashtable
            myHashtable.Clear();

            // Displaying the count after clearing
            Console.WriteLine("Hashtable cleared. Count: " + myHashtable.Count);
            #endregion

            #region Queue
            // Creating a Queue
            Queue myQueue = new Queue();

            // Enqueuing elements
            myQueue.Enqueue("Element1");
            myQueue.Enqueue(42);
            myQueue.Enqueue(3.14);

            // Dequeuing elements
            Console.WriteLine("Dequeueing elements from the Queue:");
            while (myQueue.Count > 0)
            {
                Console.WriteLine(myQueue.Dequeue());
            }

            // Enqueuing more elements
            myQueue.Enqueue("NewElement");
            myQueue.Enqueue(99);

            // Peeking at the front element without dequeuing
            Console.WriteLine("Peek at the front element without dequeuing:");
            Console.WriteLine(myQueue.Peek());

            // Dequeuing elements again
            Console.WriteLine("Dequeueing elements from the Queue:");
            while (myQueue.Count > 0)
            {
                Console.WriteLine(myQueue.Dequeue());
            }

            // Displaying the count after operations
            Console.WriteLine("Queue cleared. Count: " + myQueue.Count);
            #endregion

            #region Stack
            // Creating a Stack
            Stack myStack = new Stack();

            // Pushing elements onto the Stack
            myStack.Push("Element1");
            myStack.Push(42);
            myStack.Push(3.14);

            // Popping elements from the Stack
            Console.WriteLine("Popping elements from the Stack:");
            while (myStack.Count > 0)
            {
                Console.WriteLine(myStack.Pop());
            }

            // Pushing more elements
            myStack.Push("NewElement");
            myStack.Push(99);

            // Peeking at the top element without popping
            Console.WriteLine("Peek at the top element without popping:");
            Console.WriteLine(myStack.Peek());

            // Popping elements again
            Console.WriteLine("Popping elements from the Stack:");
            while (myStack.Count > 0)
            {
                Console.WriteLine(myStack.Pop());
            }

            // Displaying the count after operations
            Console.WriteLine("Stack cleared. Count: " + myStack.Count);
            #endregion

            #region SortedList
            // Creating a SortedList
            SortedList mySortedList = new SortedList();

            // Adding key/value pairs
            mySortedList.Add("Key3", 42);
            mySortedList.Add("Key1", "Hello");
            mySortedList.Add("Key2", 3.14);

            // Iterating over key-value pairs (sorted by key)
            Console.WriteLine("Iterating over key-value pairs:");
            foreach (DictionaryEntry entry in mySortedList)
            {
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }

            // Accessing values by key (casting required)
            Console.WriteLine("Accessing values by key:");
            foreach (var key in mySortedList.Keys)
            {
                Console.WriteLine($"Key: {key}, Value: {mySortedList[key]}");
            }

            // Checking if a key exists
            containsKey = mySortedList.ContainsKey("Key2");
            Console.WriteLine($"SortedList contains key 'Key2': {containsKey}");

            // Removing a key/value pair
            mySortedList.Remove("Key1");

            // Iterating over key-value pairs after removal
            Console.WriteLine("Iterating over key-value pairs after removal:");
            foreach (DictionaryEntry entry in mySortedList)
            {
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }

            // Clearing the SortedList
            mySortedList.Clear();

            // Displaying the count after clearing
            Console.WriteLine("SortedList cleared. Count: " + mySortedList.Count);
            #endregion

        }
    }
}
