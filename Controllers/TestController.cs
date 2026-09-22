using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudyFlowApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        //Simple endpoint used to confirm the StudyFlow API is running
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                message = "StudyFlow API is running!",
                status = "success"
            });
        }
    }
}
