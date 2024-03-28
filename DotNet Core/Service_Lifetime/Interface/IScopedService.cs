namespace Service_Lifetime.Interface
{
    /// <summary>
    /// Interface for scoped services.
    /// </summary>
    public interface IScopedService
    {
        /// <summary>
        /// Gets the instance ID of the scoped service.
        /// </summary>
        /// <returns>The instance ID as a string.</returns>
        string GetInstanceId();        
    }
}
