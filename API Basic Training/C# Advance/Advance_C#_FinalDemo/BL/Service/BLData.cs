using Advance_C__FinalDemo.Models.POCO;
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
    [LoggingExceptionFilter]
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
                string backup = HttpContext.Current.Server.MapPath("~/Backup");
                if (!backup.DirectoryExists())
                {
                    Directory.CreateDirectory(backup);
                }
                string pathOfBackup = Path.Combine(backup, "backupData.xlsx");

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (ExcelPackage package = new ExcelPackage())
                {
                    // Write Category Data into Excel
                    ExcelWorksheet categorySheet = package.Workbook.Worksheets.Add("Category");                   
                    BLCategory objOfBLCategory = new BLCategory();
                    DataTable categoryData = objOfBLCategory.GetAll();
                    categorySheet.Cells.LoadFromDataTable(categoryData, true);

                    // Write Director Data into Excel
                    ExcelWorksheet directorSheet = package.Workbook.Worksheets.Add("Director");
                    BLDirector objOfBLDirector = new BLDirector();
                    DataTable directorData = objOfBLDirector.GetAll();
                    directorSheet.Cells.LoadFromDataTable(directorData, true);

                    // Write Movie Data into Excel
                    ExcelWorksheet movieSheet = package.Workbook.Worksheets.Add("Movie");
                    BLMovies objOfBLMovies = new BLMovies();
                    List<MOV01> movieData = objOfBLMovies.GetData();
                    movieSheet.Cells.LoadFromCollection(movieData, true);

                    // Save Excel File with PasswordProtection
                    package.SaveAs(new FileInfo(pathOfBackup),"Jeet");                 
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
