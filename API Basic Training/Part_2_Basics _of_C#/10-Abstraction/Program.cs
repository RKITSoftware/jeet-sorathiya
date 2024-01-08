using System;

namespace _10_Abstraction
{
    #region abstract class Shape
    /// <summary>
    /// abstract class shape, method to CalculateArea.
    /// </summary>
    public abstract class Shape
    {
        #region method
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
        #endregion
    }
    #endregion

    #region  public class Circle
    /// <summary>
    /// class circle, radius property and CalculateArea method.
    /// </summary>
    public class Circle : Shape
    {
        #region public Proparty
        /// <summary>
        /// Gets or sets the radius of the circle.
        /// </summary>
        public double Radius { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="radius">radius of the circle.</param>
        public Circle(double radius)
        {
            Radius = radius;
        }
        #endregion

        #region public method
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
        #endregion
    }
    #endregion

    #region public class Rectangle
    /// <summary>
    /// class rectangle, width and height properties,CalculateArea method.
    /// </summary>
    public class Rectangle : Shape
    {
        #region public proparty
        /// <summary>
        /// Gets or sets the width of the rectangle.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the rectangle.
        /// </summary>
        public double Height { get; set; }
        #endregion

        #region Constructor
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
        #endregion

        #region public method
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
        #endregion
    }
    #endregion

    #region internal class Program
    /// <summary>
    /// class Program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// main method
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
    #endregion

}
