using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT.BL
{
    /// <summary>
    /// Business logic class for handling JWT token generation and verification
    /// </summary>
    public class BLJWTToken
    {
        // Secret key used for signing and validating the JWT token
        private static readonly string _secretKey = "jeet@okkoefbhuijmkl@ik#%^jik890#jopjfm8!)(&*ffg@JEET";

        /// <summary>
        /// Generates a JWT token for the specified username
        /// </summary>
        /// <param name="username">The username to include in the token</param>
        /// <returns>The generated JWT token</returns>
        public string GenerateToken(string username)
        {
            // Issuer of the token
            string issuer = "https://localhost:64752";
            // Create a symmetric security key using the secret key
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            // Create signing credentials using the security key and the HMAC SHA256 algorithm
            SigningCredentials credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            // List of claims to be included in the token
            List<Claim> lstClaims = new List<Claim>();
            lstClaims.Add(new Claim("username", username));
            // Create a JWT token with specified parameters
            JwtSecurityToken token = new JwtSecurityToken(issuer,
                           issuer,
                           lstClaims,
                           expires: DateTime.Now.AddSeconds(30),
                           signingCredentials: credentials);
            // Write the token to a string
            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }

        /// <summary>
        /// Verifies and extracts the username from a given JWT token.
        /// </summary>
        /// <param name="token">The JWT token to be verified.</param>
        /// <returns>The username extracted from the token, or null if verification fails.</returns>

        public string VerifyToken(string token)
        {
            // Create a symmetric security key using the secret key
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            // Token validation parameters
            TokenValidationParameters validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true, // Enable lifetime validation
                ClockSkew = TimeSpan.Zero, // Set zero to ensure the token is not considered valid even a few seconds after expiry
                ValidateIssuerSigningKey = true,
                ValidIssuer = "https://localhost:64752",
                IssuerSigningKey = symmetricSecurityKey
            };

            // Create a JWT token handler
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            try
            {
                // Validate the token and extract claims
                ClaimsPrincipal principal = handler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                // Return the value of the "username" claim
                return principal.FindFirst("username")?.Value;
            }
            catch (Exception)
            {
                // Return null if token validation fails
                return null;
            }

        }
    }
}