using System;

namespace _7._3_Abstract_Class
{
    /// <summary>
    /// Demonstrates the use of an abstract class
    #region Abstract Class Shape

    // Abstract Class
    public abstract class Shape
    {
        /// <summary>
        /// Abstract method to calculate the area of the shape.
        /// </summary>
        /// <returns>The calculated area as a double.</returns>
        public abstract double CalculateArea();
    }
    #endregion

    #region class circle
    // Derived Class from the Abstract Class
    public class Circle : Shape
    {
        #region public proparty
        /// <summary>
        /// Gets or sets the radius of the circle.
        /// </summary>
        public double Radius { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for the Circle class.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        public Circle(double radius)
        {
            Radius = radius;
        }
        #endregion

        #region method
        /// <summary>
        /// Overrides the CalculateArea method to calculate the area of the circle.
        /// </summary>
        /// <returns>The calculated area of the circle as a double.</returns>
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
        #endregion
    }

    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Abstract Class

            // Abstract Class
            Console.Write("Enter the radius of the circle: ");
            double radius = double.Parse(Console.ReadLine());

            // Create an instance of the Circle class
            Shape circle = new Circle(radius);
            double area = circle.CalculateArea();
            Console.WriteLine($"Circle Area: {area}");

            #endregion
        }
    }

}
