using Microsoft.AspNetCore.Mvc;
using test1.Controllers;

namespace test1.Utilities
{

    /// <summary>
    /// Base Reponse class 
    /// </summary>
    public class BaseResponse : BaseApiController
    {
        protected IActionResult Error(object errorMessage)
        {
            return new BadRequestObjectResult(Envelope.ErrorMessage(errorMessage));
        }
    }
}

