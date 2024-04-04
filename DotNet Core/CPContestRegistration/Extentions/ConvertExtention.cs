using Newtonsoft.Json;
using System.Data;

namespace CPContestRegistration.Extentions
{
    /// <summary>
    /// Extension methods for converting DataTable to JSON.
    /// </summary>
    public static class ConvertExtention
    {
        /// <summary>
        /// Converts a DataTable to JSON string.
        /// </summary>
        /// <param name="dataTable">The DataTable to convert.</param>
        /// <returns>A JSON representation of the DataTable.</returns>
        public static string ToJson(this DataTable dataTable)
        {
            // Convert DataTable to JSON
            return JsonConvert.SerializeObject(dataTable, Formatting.Indented);
        }
    }
}
