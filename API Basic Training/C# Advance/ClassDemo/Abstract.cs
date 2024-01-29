using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemo
{
    #region abstract class Tesla
    /// <summary>
    /// Abstract base class representing a Tesla vehicle.
    /// </summary>
    public abstract class Tesla
    {
        /// <summary>
        /// Constructor for Tesla class.
        /// </summary>
        public Tesla()
        {
            Console.WriteLine("Obj of Tesla Created");
        }

        /// <summary>
        /// Abstract method to start the Tesla vehicle.
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// Abstract method to stop the Tesla vehicle.
        /// </summary>
        public abstract void Stop();

        /// <summary>
        /// Abstract method to update the Tesla vehicle.
        /// </summary>
        public abstract void Update();

    }
    #endregion

    #region class Car
    /// <summary>
    /// Concrete class representing a Tesla car, inheriting from the Tesla base class.
    /// </summary>
    public class Car : Tesla
    {
        /// <summary>
        /// Constructor for Car class.
        /// </summary>
        public Car()
        {
            Console.WriteLine("Obj of Car Created");
        }

        /// <summary>
        /// Implementation of the Start method for a Tesla car.
        /// </summary>
        public override void Start()
        {
            Console.WriteLine("Tesla Start");
        }

        /// <summary>
        /// Implementation of the Stop method for a Tesla car.
        /// </summary>
        public override void Stop()
        {
            Console.WriteLine("Tesla Stop");
        }

        /// <summary>
        /// Implementation of the Update method for a Tesla car.
        /// </summary>
        public override void Update()
        {
            Console.WriteLine("Tesla Update");
        }

        /// <summary>
        /// Additional method specific to the Car class.
        /// </summary>
        public void Info()
        {
            Console.WriteLine("Info");
        }
    }
    #endregion

    #region class Abstract
    /// <summary>
    //  class Abstract have method to test the abstract classes.
    /// </summary>
    public class Abstract
    {
        public static void AbstractClassTest(string[] args)
        {
            // Creating an instance of the Car class
            Car objofCar = new Car();
            objofCar.Start();
            objofCar.Stop();
            objofCar.Update();
            objofCar.Info();

            // Creating an instance of the Tesla class
            Tesla objofTesla = new Car();
            objofTesla.Start();
            objofTesla.Stop();
            objofTesla.Update();

        }

    }
    #endregion
}
