using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("public")]
        public IActionResult PublicEndpoint()
        {
            return Ok(new { message = "Burası herkese açık" });
        }

        [HttpGet("test")]
        [Authorize]
        public IActionResult ProtectedEndpoint()
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email)?.Value;

            return Ok(new
            {
                message = "Korumalı alana giriş yaptınız",
                userEmail = userEmail
            });
        }

    }
}
