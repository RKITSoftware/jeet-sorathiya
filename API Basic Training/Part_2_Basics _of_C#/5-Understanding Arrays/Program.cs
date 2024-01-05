using System;
using System.Linq;

namespace _5_Understanding_Arrays
{
    /// <summary>
    /// type of array 
    ///     1D array
    ///     2D array
    ///     jagged array
    /// 
    /// array methods
    ///     Length
    ///     sort
    ///     Linq namespace
    ///     Reverses
    ///     Get Value
    ///     Get Length
    ///     copy
    ///     clone
    ///     inedexof
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {

            #region array
            int[] id = { 1, 2, 3 }; // declare and initialize
            Console.WriteLine("id");
            for (int i = 0; i < id.Length; i++)
            {
                Console.WriteLine(id[i]);
            }

            char[] charArr; // declare but not initialize
            charArr = new char[] { 'a', 'b' }; // initialize
            Console.WriteLine("charArr");
            for (int i = 0; i < charArr.Length; i++)
            {

                Console.WriteLine(charArr[i]);
            }

            int[] intArr = new int[5]; // declare with new keyword size required
            intArr = new int[] { 5, 6 };
            intArr[0] = 1;
            Console.WriteLine("intArr");
            for (int i = 0; i < intArr.Length; i++)
            {

                Console.WriteLine(intArr[i]);
            }

            int[] arr = new int[] { 10, 56, 5, 7, 8 }; // without specifying size
            Console.WriteLine("arr");
            for (int i = 0; i < arr.Length; i++)
            {

                Console.WriteLine(arr[i]);
            }



            #endregion

            #region 2d array
            // 2d array
            int[,] marks = { { 5, 56, 10 }, { 6, 9, 37 } };
            Console.WriteLine("marks[0,1] " + marks[0, 1]);
            Console.WriteLine("Foreach on marks ");
            foreach (int i in marks)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Forloop on marks ");
            for (int i = 0; i < marks.GetLength(0); i++)
            {
                for (int j = 0; j < marks.GetLength(1); j++)
                {
                    Console.Write(marks[i, j] + "\t");
                }
                Console.WriteLine();
            }

            #endregion

            #region Jagged array

            Console.WriteLine("Jagged array");

            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[] { 1, 2, 3 };
            jaggedArray[1] = new int[] { 10, 80, 60, 90, 56 };
            jaggedArray[2] = new int[] { 136 };

            int[][] jaggedDemo = new int[][]
            {
                new int[] {58, 96, 46, 30},
                new int[] {10, 63, 0}
            };

            Console.WriteLine("Jagged array : foreach loop");
            foreach (int[] i in jaggedArray)
            {
                foreach (int j in i)
                {
                    Console.Write(j + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Jagged array : for loop");
            for (int i = 0; i < jaggedDemo.Length; i++)
            {
                for (int j = 0; j < jaggedDemo[i].Length; j++)
                {
                    Console.Write(jaggedDemo[i][j] + "\t");
                }
                Console.WriteLine();
            }


            #endregion

            #region methods

            // methods of array
            Console.WriteLine("methods of array");

            // sort
            Array.Sort(arr);
            Console.WriteLine("sort:arr");
            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }

            //Linq namespace
            Console.WriteLine("max : " + arr.Max());
            Console.WriteLine("min : " + arr.Min());
            Console.WriteLine("sum : " + arr.Sum());

            // Reverses the array
            int[] numbers = { 1, 2, 3, 4, 5 };
            Array.Reverse(numbers);
            Console.WriteLine("Reverses the array");
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }

            // Get Value
            int value = (int)id.GetValue(1); // return object
            Console.WriteLine("Get Value " + value);
            id.SetValue(11, 1);
            Console.WriteLine("SetValue " + id[1]);

            // Get Length in 2D array
            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 } };
            Console.WriteLine("rowCount " + matrix.GetLength(0)); // Returns 2 (number of rows)
            Console.WriteLine("colCount " + matrix.GetLength(1)); // Returns 3 (number of columns)

            // Copy
            int[] sourceArray = { 1, 2, 3 };
            int[] destinationArray = new int[3];
            sourceArray.CopyTo(destinationArray, 0); // 0 is destination array index
            Console.WriteLine("Copy");
            for (int i = 0; i < destinationArray.Length; i++)
            {
                Console.WriteLine(destinationArray[i]);
            }

            // clone
            int[] originalArray = { 1, 2, 3 };
            int[] clonedArray = (int[])originalArray.Clone(); //shallow copy
            Console.WriteLine("clone");
            for (int i = 0; i < clonedArray.Length; i++)
            {
                Console.WriteLine(clonedArray[i]);
            }

            // indexOf
            Console.WriteLine("Index : " + Array.IndexOf(clonedArray, 3)); // Returns 2
            #endregion

        }
    }
}
