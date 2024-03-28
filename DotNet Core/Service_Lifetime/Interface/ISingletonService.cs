namespace Service_Lifetime.Interface
{
    /// <summary>
    /// Interface for singleton services.
    /// </summary>
    public interface ISingletonService
    {
        /// <summary>
        /// Gets the instance ID of the singleton service.
        /// </summary>
        /// <returns>The instance ID as a string.</returns>
        string GetInstanceId();
    }
}
