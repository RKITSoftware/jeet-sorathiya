using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_of_web_development_training.Models
{
    /// <summary>
    /// Response for the specific response during api request.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Gets or Sets the response according to the request.
        /// </summary>
        public dynamic Data { get; set; }

        /// <summary>
        /// Gets or Sets the error occur during request.
        /// </summary>
        public bool IsError { get; set; } = false;

        /// <summary>
        /// Gets or Sets the message according to the success or error response.
        /// </summary>
        public string Message { get; set; }
    }
}