
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

        //Used by the hosting platform to check if API is responding.
        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok(new
            {
                status = "health"
            });
        }
    }
}
