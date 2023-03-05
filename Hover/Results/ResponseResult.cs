using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Hover.Results
{
    /// <summary>
    /// A wrapper for an object that can be returned from an API call.
    /// </summary>
    public class ResponseResult : IActionResult
    {
        /// <summary>
        /// Gets a value indicating whether the api call was successful.
        /// </summary>
        public bool Success => Error == null;

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string? Error { get; set; }

        /// <summary>
        /// Gets or sets the response object.
        /// </summary>
        public object Data { get; set; } = default!;

        /// <summary>
        /// Gets the status HTTP status code of the response.
        /// </summary>
        [JsonIgnore]
        public int StatusCode { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseResult"/> class.
        /// </summary>
        /// <param name="statusCode">The HTTP status code of the response.</param>
        public ResponseResult(int statusCode) => StatusCode = statusCode;

        /// <summary>
        /// Executes the result operation of the action method asynchronously.
        /// Wraps it in an this class in an <see cref="ObjectResult"/> with the appropriate status code.
        /// </summary>
        /// <param name="context">The context of the action that is executing.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous execute operation.</returns>
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var result = new ObjectResult(this)
            {
                StatusCode = StatusCode,
            };

            await result.ExecuteResultAsync(context);
        }
    }
}
