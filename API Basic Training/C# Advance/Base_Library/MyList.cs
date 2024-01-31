using System.Collections.Generic;

namespace MyList
{
    /// <summary>
    /// Represents a custom list that extends the functionality of the generic List class
    /// </summary>
    /// <typeparam name="T">The type of elements in the list</typeparam>
    public class MyList<T> : List<T>
    {
        /// <summary>
        /// Initializes a new instance of the MyList class
        /// </summary>
        public MyList() : base() { }

        /// <summary>
        /// Adds an item to the list
        /// </summary>
        /// <param name="item">The item to be added</param>
        public void AddToList(T item)
        {
            base.Add(item);
        }

        /// <summary>
        /// Removes an item from the list
        /// </summary>
        /// <param name="item">The item to be removed</param>
        public void RemoveToList(T item)
        {
            base.Remove(item);
        }
    }
}
