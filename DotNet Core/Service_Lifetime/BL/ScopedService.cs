using Service_Lifetime.Interface;

namespace Service_Lifetime.BL
{
    /// <summary>
    /// Represents a scoped service.
    /// </summary>
    public class ScopedService : IScopedService
    {
        private readonly Guid _instanceId;

        /// <summary>
        /// Initializes a new instance of the ScopedService class.
        /// </summary>
        public ScopedService()
        {
            _instanceId = Guid.NewGuid();
        }

        /// <summary>
        /// Gets the instance ID.
        /// </summary>
        /// <returns>The instance ID as a string.</returns>
        public string GetInstanceId()
        {
            return _instanceId.ToString();
        }
    }
}
