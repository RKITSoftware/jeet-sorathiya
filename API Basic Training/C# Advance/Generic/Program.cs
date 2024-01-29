using System;

namespace Generic
{
    #region  public class MathFunctions<T>
    /// <summary>
    /// Generic class representing mathematical functions with values of type T.
    /// </summary>
    /// <typeparam name="T">Type parameter representing the data type of values.</typeparam>
    public class MathFunctions<T>
    {
        #region public property
        /// <summary>
        /// Gets or sets the first value.
        /// </summary>
        public T Value1 { get; set; }

        /// <summary>
        /// Gets or sets the second value.
        /// </summary>
        public T Value2 { get; set; }
        #endregion

        #region public method
        /// <summary>
        /// Constructor for MathFunctions class.
        /// </summary>
        /// <param name="value1">First value of type T.</param>
        /// <param name="value2">Second value of type T.</param>
        public MathFunctions(T value1, T value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        /// <summary>
        /// Display method to print the values of Value1 and Value2.
        /// </summary>
        public void Display()
        {
            Console.WriteLine($"value1 : {Value1}, value2 : {Value2}");
        }

        /// <summary>
        /// Display method overloaded with a generic type parameter to print a single value.
        /// </summary>
        /// <typeparam name="Type">Type parameter representing the data type of the value to display.</typeparam>
        /// <param name="value">Value of the specified type to display.</param>
        public void Display<Type>(Type value)
        {
            Console.WriteLine($"value : {value}");
        }
        #endregion
    }
    #endregion

    #region  public class Program
    public class Program
    {
        static void Main(string[] args)
        {  // Creating an instance of MathFunctions with int values
            MathFunctions<int> objofmathFunctions1 = new MathFunctions<int>(10, 20);
            objofmathFunctions1.Display();
            objofmathFunctions1.Display<int>(10);
            objofmathFunctions1.Display<string>("hii");

            // Creating an instance of MathFunctions with string values
            MathFunctions<string> objofmathFunctions2 = new MathFunctions<string>("Hi", "Hello");
            objofmathFunctions2.Display();

        }
    }
    #endregion
}
