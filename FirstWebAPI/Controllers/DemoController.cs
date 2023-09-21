using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet("Demo/add")]
        public int Add(int x, int y)
        {
            return x + y + 5000;
        }
    }
}