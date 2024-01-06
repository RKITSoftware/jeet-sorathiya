using System;

namespace _14_Scope_Accessibility_modifier
{
    #region PublicClass
    /// <summary>
    /// Public class
    /// </summary>
    public class PublicClass
    {

        #region field
        /// <summary>
        /// Public member accessible anywhere in the program.
        /// </summary>
        public int PublicMember = 10;
        #endregion

        #region method
        /// <summary>
        /// Public method accessible anywhere in the program.
        /// </summary>
        public void PublicMethod()
        {
            Console.WriteLine("Public method");
        }
        #endregion
    }
    #endregion

    #region PrivateClass
    /// <summary>
    /// Privateclass
    /// </summary>
    public class PrivateClass
    {
        #region field
        /// <summary>
        /// Private member accessible only within the class.
        /// </summary>
        private int PrivateMember = 20;
        #endregion

        #region method
        /// <summary>
        /// Private method accessible only within the class.
        /// </summary>
        private void PrivateMethod()
        {
            Console.WriteLine("Private method");
        }

        /// <summary>
        /// Public method that accesses private member and method.
        /// </summary>
        public void AccessPrivate()
        {
            Console.WriteLine($"Accessing private member: {PrivateMember}");
            PrivateMethod();
        }
        #endregion
    }
    #endregion

    #region ProtectedBase
    /// <summary>
    /// Base class with protected member and method.
    /// </summary>
    public class ProtectedBase
    {

        #region field
        /// <summary>
        /// Protected member accessible within the class and its derived classes.
        /// </summary>
        protected int ProtectedMember = 30;
        #endregion

        #region method
        /// <summary>
        /// Protected method accessible within the class and its derived classes.
        /// </summary>
        protected void ProtectedMethod()
        {
            Console.WriteLine("Protected method");
        }
        #endregion
    }
    #endregion

    #region DerivedClass
    /// <summary>
    /// Derived class that inherits from ProtectedBase
    /// </summary>
    public class DerivedClass : ProtectedBase
    {

        #region AccessProtected
        /// <summary>
        /// Public method that accesses protected member and method from the base class.
        /// </summary>
        public void AccessProtected()
        {
            Console.WriteLine($"Accessing protected member: {ProtectedMember}");
            ProtectedMethod();
        }
        #endregion
    }
    #endregion

    #region InternalClass
    /// <summary>
    /// Internal class
    /// </summary>
    internal class InternalClass
    {
        #region field
        /// <summary>
        /// Internal member accessible within the same assembly.
        /// </summary>
        internal int InternalMember = 40;
        #endregion

        #region method
        /// <summary>
        /// Internal method accessible within the same assembly.
        /// </summary>
        internal void InternalMethod()
        {
            Console.WriteLine("Internal method");
        }
        #endregion
    }
    #endregion

    #region ProtectedInternalClass
    /// <summary>
    /// Class ProtectedInternalClass
    /// </summary>
    public class ProtectedInternalClass
    {
        #region field
        /// <summary>
        /// Protected internal member accessible within the same assembly and from derived classes.
        /// </summary>
        protected internal int ProtectedInternalMember = 50;
        #endregion

        #region method
        /// <summary>
        /// Protected internal method accessible within the same assembly and from derived classes.
        /// </summary>
        protected internal void ProtectedInternalMethod()
        {
            Console.WriteLine("Protected Internal method");
        }
        #endregion
    }
    #endregion

    #region class Program
    /// <summary>
    /// program class
    /// </summary>
    internal class Program
    {
        #region method
        /// <summary>
        /// main method
        /// </summary>
        static void Main()
        {
            PublicClass publicClass = new PublicClass();
            Console.WriteLine($"Public member: {publicClass.PublicMember}");
            publicClass.PublicMethod();

            PrivateClass privateClass = new PrivateClass();
            privateClass.AccessPrivate();

            DerivedClass derivedClass = new DerivedClass();
            derivedClass.AccessProtected();

            InternalClass internalClass = new InternalClass();
            Console.WriteLine($"Internal member: {internalClass.InternalMember}");
            internalClass.InternalMethod();

            ProtectedInternalClass protectedInternalClass = new ProtectedInternalClass();
            Console.WriteLine($"Protected Internal member: {protectedInternalClass.ProtectedInternalMember}");
            protectedInternalClass.ProtectedInternalMethod();
        }
        #endregion
    }
    #endregion

}
