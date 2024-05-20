namespace Test_of_web_development_training.Models.Enum
{
    /// <summary>
    /// Represents the different roles available in the system.
    /// </summary>
    public enum EnmRole
    {
        /// <summary>
        /// user with administrative privileges.
        /// </summary>
        Admin,
        /// <summary>
        /// user who has subscribed to the service.
        /// </summary>
        Subscriber,
        /// <summary>
        /// user who has not subscribed to the service.
        /// </summary>
        NonSubscriber,

        /// <summary>
        /// user with superhero status.
        /// </summary>
        Superhero,

        /// <summary>
        /// user with villain status.
        /// </summary>
        Villain
    }
}