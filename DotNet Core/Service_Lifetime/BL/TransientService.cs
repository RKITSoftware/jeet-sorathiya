using Service_Lifetime.Interface;

namespace Service_Lifetime.BL
{
    /// <summary>
    /// Represents a transient service.
    /// </summary>
    public class TransientService : ITransientService
    {
        private readonly Guid _instanceId;

        /// <summary>
        /// Initializes a new instance of the TransientService class.
        /// </summary>
        public TransientService()
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
