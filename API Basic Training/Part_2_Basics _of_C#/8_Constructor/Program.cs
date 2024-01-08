using System;

namespace _8_Constructor
{
    #region class Person
    /// <summary>
    /// Represents a person with name and age details
    /// </summary>
    public class Person
    {
        #region public Proparty
        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the age of the person.
        /// </summary>
        public int Age { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Person()
        {
            Console.WriteLine("Default Constructor Called");
        }

        /// <summary>
        /// Parameterized Constructor with name and age parameters.
        /// </summary>
        /// <param name="name">The name of the person.</param>
        /// <param name="age">The age of the person.</param>
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Console.WriteLine("Parameterized Constructor Called");
        }

        /// <summary>
        /// Copy Constructor to create a new object based on an existing Person object.
        /// </summary>
        /// <param name="original">The original Person object to copy from.</param>
        public Person(Person original)
        {
            Name = original.Name;
            Age = original.Age;
            Console.WriteLine("Simulated Copy Constructor Called");
        }
        #endregion

        #region public Method
        /// <summary>
        /// Displays the details of the person.
        /// </summary>
        public void Display()
        {
            Console.WriteLine($"Person Details: Name - {Name}, Age - {Age}");
        }
        #endregion
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating an object with the default constructor
            Person person1 = new Person();
            person1.Display();

            // Creating an object with the parameterized constructor
            Person person2 = new Person("jeet", 20);
            person2.Display();

            // Using the copy constructor to create a new object
            Person person3 = new Person(person2);
            person3.Display();
        }
    }

}
