using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetToken()
        {
            User user = new()
            {
                Id = 1,
                Username = "ashwor",
                Email = "kerimhassan81@gmail.com",
                Name = "Kerim Hasan Yildirim"
            };
            string token = JwtHelper.CreateJwtToken(user);
            return Ok(token);
        }
    }
}
