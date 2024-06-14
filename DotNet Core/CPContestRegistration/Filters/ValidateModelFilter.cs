using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CPContestRegistration.Filters
{
    /// <summary>
    /// Filter for validating the model state before executing an action.
    /// </summary>
    public class ValidateModelFilter : IAsyncActionFilter
    {
        #region Public Methods
        /// <summary>
        /// Called asynchronously before the action method is invoked to validate the model state.
        /// </summary>
        /// <param name="context">The context for the action execution.</param>
        /// <param name="next">The delegate to execute the next action filter</param>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Check if the model state is not valid
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestResult();
                return;
            }
            await next();
        } 
        #endregion
    }
}
