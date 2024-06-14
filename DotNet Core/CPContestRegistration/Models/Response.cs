namespace CPContestRegistration.Models
{
    /// <summary>
    /// Represents the response returned by the API.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Gets or sets the data returned in the response.
        /// </summary>
        public dynamic? Data { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the response is an error.
        /// </summary>
        public bool IsError { get; set; } = false;

        /// <summary>
        /// Gets or sets the message associated with the response.
        /// </summary>
        public string? Message { get; set; }
    }
}
