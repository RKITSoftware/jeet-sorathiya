namespace Service_Lifetime.Interface
{
    /// <summary>
    /// Interface for transient services.
    /// </summary>
    public interface ITransientService
    {
        /// <summary>
        /// Gets the instance ID of the transient service.
        /// </summary>
        /// <returns>The instance ID as a string.</returns>
        string GetInstanceId();
    }
}
