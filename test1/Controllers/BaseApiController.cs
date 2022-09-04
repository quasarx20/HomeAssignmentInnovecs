using Microsoft.AspNetCore.Mvc;
using test1.Utilities;

namespace test1.Controllers
{

    /// <summary>
    /// BaseController with success and error action method
    /// </summary>
    public class BaseApiController : ControllerBase
    {
        /// <summary>
        /// Action method with success response
        /// </summary>
        /// <returns>The created success response</returns>
        protected new IActionResult Ok()
        {
            return base.Ok(Envelope.Ok());
        }

        /// <summary>
        /// Action method with success response with specified type
        /// </summary>
        /// <typeparam name="T">object/message</typeparam>
        /// <param name="result">Any specified type</param>
        /// <returns>The created success ObjectResult for the response</returns>
        protected IActionResult Ok<T>(T result)
        {
            return base.Ok(Envelope.Ok(result));
        }



        /// <summary>
        /// Action method with error messages
        /// </summary>
        /// <param name="errorMessage">string</param>
        /// <returns>The created error response></returns>
        protected IActionResult Error(string errorMessage)
        {
            return BadRequest(Envelope.ErrorMessage(errorMessage));
        }

    }
}

