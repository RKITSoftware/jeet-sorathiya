using System;

namespace _10_Abstraction
{
    /// <summary>
    /// abstract class shape, method to CalculateArea.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Calculates the area of the shape.
        /// </summary>
        /// <returns>The calculated area.</returns>
        public abstract double CalculateArea();

        /// <summary>
        /// Displays information about the shape
        /// </summary>
        public void DisplayInfo()
        {
            Console.WriteLine($"Area: {CalculateArea()}");
        }
    }

    /// <summary>
    /// class circle, radius property and CalculateArea method.
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Gets or sets the radius of the circle.
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="radius">radius of the circle.</param>
        public Circle(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// calculate area of Circle
        /// <retrurn></retrurn>
        /// </summary>
        /// <returns>Area of Circle</returns>
        public override double CalculateArea()
        {
            Console.WriteLine("Area of Circle");
            return Math.PI * Math.Pow(Radius, 2);
        }
    }

    /// <summary>
    /// class rectangle, width and height properties,CalculateArea method.
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Gets or sets the width of the rectangle.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the rectangle.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        ///  Constructor method
        /// </summary>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// calculate area of Rectangle
        /// <retrurn></retrurn>
        /// </summary>
        /// <returns>Area of Rectangle</returns>
        public override double CalculateArea()
        {
            Console.WriteLine("Area of Rectangle");
            return Width * Height;
        }
    }

    /// <summary>
    /// class Program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// main method.
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Enter Circle Radius");
            int circleRadius = int.Parse(Console.ReadLine());
            Circle objofCircle = new Circle(circleRadius);

            Console.WriteLine("Enter Rectangle Width & Height");
            double rectangleWidth = double.Parse(Console.ReadLine());
            double rectangleHeight = double.Parse(Console.ReadLine());
            Rectangle objofRectangle = new Rectangle(rectangleWidth, rectangleHeight);

            DisplayShapeInfo(objofCircle);
            DisplayShapeInfo(objofRectangle);
        }
        static void DisplayShapeInfo(Shape shape)
        {
            shape.DisplayInfo();
            Console.WriteLine();
        }
    }


}
