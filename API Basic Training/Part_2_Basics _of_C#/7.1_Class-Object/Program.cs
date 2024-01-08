using System;

namespace _7._1_Class_Object
{

    /// <summary>
    /// Demonstrates the use of a regular class in C#
    /// </summary>
    #region Regular Class

    // Regular Class
    public class Person
    {
        #region private Fields
        // Fields
        private string firstName;
        private string lastName;
        #endregion

        #region public Properties
        // Properties
        /// <summary>
        /// Gets or sets the first name, last name
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="firstName">The first name of the person.</param>
        /// <param name="lastName">The last name of the person.</param>
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        #endregion

        #region public Method
        // Method
        /// <summary>
        /// Displays the full name of the person.
        /// </summary>
        public void DisplayFullName()
        {
            Console.WriteLine($"Full Name: {FirstName} {LastName}");
        }
        #endregion
    }

    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Regular Class

            // Regular Class
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();

            Person objofPerson = new Person(firstName, lastName);
            objofPerson.DisplayFullName();

            #endregion
        }
    }

}
