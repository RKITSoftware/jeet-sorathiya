using System.Reflection;

namespace CPContestRegistration.Extentions
{
    /// <summary>
    /// Extension methods for converting DataTable to JSON.
    /// </summary>
    public static class ConvertExtention
    {
        #region Public Methods
        /// <summary>
        /// Converts the DTO model to POCO Model.
        /// </summary>
        /// <typeparam name="POCO">POCO model.</typeparam>
        /// <param name="dto">DTO model reference</param>
        /// <returns>Poco model.</returns>
        public static POCO Convert<POCO>(this object dto)
        {
            Type? pocoType = typeof(POCO) ?? throw new Exception();
            POCO? pocoInstance = (POCO)Activator.CreateInstance(type: pocoType);

            // Get properties
            PropertyInfo[] dtoProperties = dto.GetType().GetProperties();
            PropertyInfo[] pocoProperties = pocoType.GetProperties();

            foreach (PropertyInfo dtoProperty in dtoProperties)
            {
                PropertyInfo? pocoProperty = Array.Find(array: pocoProperties, p => p.Name == dtoProperty.Name);

                if (pocoProperty != null && dtoProperty.PropertyType == pocoProperty.PropertyType)
                {
                    object? value = dtoProperty.GetValue(dto);
                    pocoProperty.SetValue(pocoInstance, value);
                }
            }

            return pocoInstance != null ? pocoInstance : throw new Exception();
        } 
        #endregion
    }
}
