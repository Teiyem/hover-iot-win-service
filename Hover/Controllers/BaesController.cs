using Hover.Results;
using Microsoft.AspNetCore.Mvc;

namespace Hover.Controllers
{
    /// <summary>
    /// A base class for all controllers that provides a logger, a security provider and a couple of methods for creating API responses.
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// The logger used to log to console.
        /// </summary>
        private protected readonly ILogger<BaseController> mLogger;


        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="logger">The logger that is is injected into the controller.</param>
        protected BaseController(ILogger<BaseController> logger)
        {
            mLogger = logger;
        }

        /// <summary>
        /// Creates a <see cref="ResponseResult"/> object with a status code of 200 and the data passed in as a parameter response.
        /// </summary>
        /// <param name="data">The response data</param>
        /// <returns>The created <see cref="ResponseResult"/> for the response.</returns>
        [NonAction]
        public virtual ResponseResult SuccessResult(object data = null!)
            => new(200) { Data = data };

        /// <summary>
        /// Creates a <see cref="ResponseResult"/> object with the specified code and error message response.
        /// </summary>
        /// <param name="code">The HTTP status code to return.</param>
        /// <param name="error">The error message of the response</param>
        /// <returns>The created <see cref="ResponseResult"/> for the response.</returns>
        [NonAction]
        public virtual ResponseResult ErrorResult(int code, string error = "")
            => new(code) { Error = error };
    }
}
