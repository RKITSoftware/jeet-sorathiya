using Newtonsoft.Json;
using System.Data;

namespace CPContestRegistration.Extentions
{
    public static class ConvertExtention
    {
        public static string ToJson(this DataTable dataTable)
        {
            // Convert DataTable to JSON
            return JsonConvert.SerializeObject(dataTable, Formatting.Indented);
        }
    }
}
