using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reactivities.Application.Photos;

namespace Reactivities.API.Controllers
{
    public class PhotosController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult> Add([FromForm] Add.Command command)
        {
            return HandleResult(await Mediator.Send(command));
        }        
    }
}
