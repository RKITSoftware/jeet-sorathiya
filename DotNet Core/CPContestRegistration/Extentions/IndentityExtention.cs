using System.Security.Claims;

namespace CPContestRegistration.Extentions
{
    /// <summary>
    /// Extension methods for ClaimsPrincipal to retrieve user role and ID.
    /// </summary>
    public static class IndentityExtention
    {
        #region Public Methods
        /// <summary>
        /// Gets the role claim value from the ClaimsPrincipal.
        /// </summary>
        /// <param name="claimsPrincipal">The ClaimsPrincipal instance.</param>
        /// <returns>The role claim value.</returns>
        public static string GetRole(this ClaimsPrincipal claimsPrincipal) =>
            claimsPrincipal.FindFirst(ClaimTypes.Role).Value;

        /// <summary>
        /// Gets the user ID claim value from the ClaimsPrincipal.
        /// </summary>
        /// <param name="claimsPrincipal">The ClaimsPrincipal instance.</param>
        /// <returns>The user ID claim value.</returns>
        public static int GetId(this ClaimsPrincipal claimsPrincipal) =>
            Convert.ToInt32(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value); 
        #endregion
    }
}
