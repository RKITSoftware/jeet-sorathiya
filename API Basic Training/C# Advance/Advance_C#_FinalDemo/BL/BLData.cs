using Advance_C__FinalDemo.Models;
using OfficeOpenXml;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;

namespace Advance_C__FinalDemo.BL
{
    /// <summary>
    /// backing up data to an Excel file.
    /// </summary>
    [LoggingExceptionFilterAttribute]
    public class BLData
    {
        /// <summary>
        /// Creates a backup of category, director, and movie data to an Excel file.
        /// </summary>
        /// <returns>True if the backup is successful; otherwise, false.</returns>
        public bool Backup()
        {
            try
            {
                // Specify the backup directory
                string backup = HttpContext.Current.Server.MapPath("~/Backup");

                // Create the backup directory if it doesn't exist
                if (!backup.DirectoryExists())
                {
                    Directory.CreateDirectory(backup);
                }

                // Define the path for the backup Excel file
                string pathOfBackup = Path.Combine(backup, "backupData.xlsx");

                // Set the ExcelPackage license context
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                // Create a new ExcelPackage
                using (var package = new ExcelPackage())
                {
                    // Add a worksheet for category data
                    var categorySheet = package.Workbook.Worksheets.Add("Category");

                    // Retrieve category data from the database
                    BLCategory objOfBLCategory = new BLCategory();
                    DataTable categoryData = objOfBLCategory.GetAll();

                    // Load category data into the worksheet
                    categorySheet.Cells.LoadFromDataTable(categoryData, true);

                    // Add a worksheet for director data
                    var directorSheet = package.Workbook.Worksheets.Add("Director");

                    // Retrieve director data from the database
                    BLDirector objOfBLDirector = new BLDirector();
                    DataTable directorData = objOfBLDirector.GetAll();

                    // Load director data into the worksheet
                    directorSheet.Cells.LoadFromDataTable(directorData, true);

                    // Add a worksheet for movie data
                    var movieSheet = package.Workbook.Worksheets.Add("Movie");

                    // Retrieve movie data from the database
                    BLMovies objOfBLMovies = new BLMovies();
                    List<MOV01> movieData = objOfBLMovies.GetData();

                    // Load movie data into the worksheet
                    movieSheet.Cells.LoadFromCollection(movieData, true);

                    // Save the ExcelPackage as the backup file
                    if (!File.Exists(pathOfBackup))
                    {
                        package.SaveAs(new FileInfo(pathOfBackup));
                    }
                    else
                    {
                        File.Delete(pathOfBackup);
                        package.SaveAs(new FileInfo(pathOfBackup));
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                // Handle and rethrow exception with additional information
                throw new Exception(ex.Message);
            }

        }
    }
}
