using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Common.Models;
using WebApplication.Services.Interfaces;

namespace WebApplication.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        public UserController(ILogger<UserController> logger, IUserServices userServices, IHttpContextAccessor httpContextAccessor)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public ActionResult GetUserByUserId(long userId)
        {
            var records = _userServices.GetUserByUserId(userId);

            if (records != null)
            {
                return Ok(records);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet("all")]
        public ActionResult GetAllUser()
        {
            var records = _userServices.GetAllUser();

            if (records != null)
            {
                return Ok(records);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost("add")]
        public ActionResult SaveUser([FromBody] UserModal userModal)
        {

            var result = _userServices.SaveUser(userModal);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("edit")]
        public ActionResult EditUser([FromBody] UserModal userModal)
        {

            var result = _userServices.EditUser(userModal);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete]
        public ActionResult DeleteUserByUserId(long userId)
        {
            var records = _userServices.DeleteUserByUserId(userId);

            if (records != null)
            {
                return Ok(records);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
