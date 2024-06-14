using Service_Lifetime.Interface;

namespace Service_Lifetime.BL
{
    /// <summary>
    /// Represents a singleton service.
    /// </summary>
    public class SingletonService : ISingletonService
    {
        #region Private Field
        private readonly Guid _instanceId;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the SingletonService class.
        /// </summary>
        public SingletonService()
        {
            _instanceId = Guid.NewGuid();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Gets the instance ID.
        /// </summary>
        /// <returns>The instance ID as a string.</returns>
        public string GetInstanceId()
        {
            return _instanceId.ToString();
        } 
        #endregion
    }
}
