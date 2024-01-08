using System;
using System.Data;

namespace _18_Data_Table
{
    internal class Program
    {
        static void Main()
        {
            // Creating a DataTable
            DataTable myDataTable = new DataTable("EmployeeTable");

            // Adding columns to the DataTable
            myDataTable.Columns.Add("EmployeeID", typeof(int));
            myDataTable.Columns.Add("FirstName", typeof(string));
            myDataTable.Columns.Add("LastName", typeof(string));
            myDataTable.Columns.Add("BirthDate", typeof(DateTime));

            // Adding rows to the DataTable
            DataRow row1 = myDataTable.NewRow();
            row1["EmployeeID"] = 369;
            row1["FirstName"] = "Jeet";
            row1["LastName"] = "Sorathiya";
            row1["BirthDate"] = new DateTime(2003, 5, 22);
            myDataTable.Rows.Add(row1);

            DataRow row2 = myDataTable.NewRow();
            row2["EmployeeID"] = 368;
            row2["FirstName"] = "Prince";
            row2["LastName"] = "Goswami";
            row2["BirthDate"] = new DateTime(2003, 8, 22);
            myDataTable.Rows.Add(row2);

            // Displaying the DataTable
            Console.WriteLine("Employee Table:");
            DisplayDataTable(myDataTable);

            // Modifying a value in the DataTable
            Console.WriteLine("Modifying a value in the DataTable:");
            row1["FirstName"] = "JEET";
            DisplayDataTable(myDataTable);

            // Deleting a row from the DataTable
            Console.WriteLine("Deleting a row from the DataTable:");
            myDataTable.Rows.Remove(row2);
            DisplayDataTable(myDataTable);
        }

        /// <summary>
        /// Displays the contents of a DataTable.
        /// </summary>
        /// <param name="dataTable">The DataTable to display.</param>
        static void DisplayDataTable(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    Console.Write($"{column.ColumnName}: {row[column]}   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

}
