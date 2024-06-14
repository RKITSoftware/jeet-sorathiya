using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Advance_C__FinalDemo.Attribute
{
    /// <summary>
    /// Attribute for validating the model state before an action method is executed.
    /// </summary>
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        #region Public Methods
        /// <summary>
        /// Called before the action method is executed, performs model state validation.
        /// </summary>
        /// <param name="actionContext">The context for the action.</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, actionContext.ModelState);
            }
        } 
        #endregion
    }
}