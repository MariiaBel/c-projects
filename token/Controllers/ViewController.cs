using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Token.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ViewController : Controller
    {
        [Authorize]
        [Route("getlogin")]
        public IActionResult GetLogin()
        {
            return Ok($"Login: {User.Identity.Name}");
        }

        [Authorize(Roles = "admin")]
        [Route("getrole")]
        public IActionResult GetRoleAdmin()
        {
            return Ok($"Role: Admin");
        }

        [Authorize(Roles = "hr")]
        [Route("getrole")]
        public IActionResult GetRoleHR()
        {
            return Ok($"Role: HR");
        }

        [Authorize(Roles = "teacher")]
        [Route("getrole")]
        public IActionResult GetRoleTeacher()
        {
            return Ok($"Role: Teacher");
        }
    }
}