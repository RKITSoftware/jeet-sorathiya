using System.Web.Caching;

namespace Test_of_web_development_training.BL.Common
{
    /// <summary>
    /// Provides a static cache object for caching data across the application.
    /// </summary>
    public static class BLCache
    {
        #region Public Property
        /// <summary>
        /// Gets or sets the static cache instance used for storing cached data.
        /// </summary>
        public static Cache ServerCache { get; set; } = new Cache(); 
        #endregion
    }
}