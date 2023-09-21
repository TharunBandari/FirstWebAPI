using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculaterController : ControllerBase
    {
        // api/calculater/add?x=10&y=20
        [HttpGet("/addCalculater")]
        public int Add(int x, int y)
        {
            return x + y;
        }
        [HttpGet("/sum")]
        public int Sum(int x, int y)
        {
            return x + y + 1000;
        }
        // api/calculater/subtract?x=200&y=100
        [HttpPost]
        public int Subtract(int x, int y)
        {
            return x - y;
        }
        // api/calculater/multiply?x=10&y=20
        [HttpPut]
        public int Multiply(int x, int y)
        {
            return x * y;
        }
        // api/calculater/divide?x=10&y=20
        [HttpDelete]
        public int Divide(int x, int y)
        {
            return x / y;
        }
    }
}