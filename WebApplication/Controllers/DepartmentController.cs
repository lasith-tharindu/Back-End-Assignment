using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Common.Models;
using WebApplication.Services;
using WebApplication.Services.Interfaces;

namespace WebApplication.Controllers
{
    [Route("api/v1/department")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _departmentServices;
        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentServices departmentServices, IHttpContextAccessor httpContextAccessor)
        {
            _departmentServices = departmentServices;
        }

        [HttpGet]
        public ActionResult GetDepartmentByDepartmentId(long Id)
        {
            var records = _departmentServices.GetDepartmentByDepartmentId(Id);

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
        public ActionResult GetAllDepartment()
        {
            var records = _departmentServices.GetAllDepartment();

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
        public ActionResult SaveDepartment([FromBody] DepartmentModal departmentModal)
        {

            var result = _departmentServices.SaveDepartment(departmentModal);
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
        public ActionResult EditDepartment([FromBody] DepartmentModal departmentModal)
        {

            var result = _departmentServices.EditDepartment(departmentModal);
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
        public ActionResult DeleteDepartmentByDepartmentId(long Id)
        {
            var records = _departmentServices.DeleteDepartmentByDepartmentId(Id);

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
