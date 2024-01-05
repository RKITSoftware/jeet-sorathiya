using System;

namespace _7._3_Abstract_Class
{

    /// <summary>
    /// class Shap
    ///     type : abstract
    ///     
    ///     CalculateArea()
    ///         type : abstract
    ///         <return>double</return>
    ///  class Circle
    ///       perent : Shape
    ///       Circle()
    ///         type : constructor
    ///       CalculateArea()
    ///         type : override
    ///         <return>double</return>
    /// </summary>

    #region  Abstract Class
    // Abstract Class
    public abstract class Shape
    {
        public abstract double CalculateArea();
    }

    // Derived Class from the Abstract Class
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
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

            Shape circle = new Circle(radius);
            double area = circle.CalculateArea();
            Console.WriteLine($"Circle Area: {area}");
            #endregion
        }
    }
}
