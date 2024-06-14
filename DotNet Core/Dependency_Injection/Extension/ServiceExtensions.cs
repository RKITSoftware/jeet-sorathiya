using Dependency_Injection.BL;
using Dependency_Injection.Interface;

namespace Dependency_Injection.Extension
{
    /// <summary>
    /// Adds services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    public static class ServiceExtensions
    {
        #region Public Methods
        /// <summary>
        /// This AddService method add services into startup file
        /// </summary>
        /// <param name="services"></param>
        public static void AddService(this IServiceCollection services)
        {
            services.AddSingleton<ITaskAssignment, TaskAssignment>();
            services.AddSingleton<IEmployeeManagement, EmployeeManagement>();
            services.AddSingleton<ITaskManagement, TaskManagement>();
        } 
        #endregion
    }
}
