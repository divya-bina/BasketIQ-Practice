using BasketIQ.API.Interfaces.CompanyData;
using BasketIQ.API.Models.CompanyData;
using Microsoft.AspNetCore.Mvc;

namespace BasketIQ.API.Controllers.CompanyData
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentInterface _departmentService;

        public DepartmentController(IDepartmentInterface departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            var result = _departmentService.GetAllDepartments();
            return Ok(result);
        }

        [HttpGet("DepartmentById")]
        public IActionResult GetDepartmentById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Department Id is required.");

            var result = _departmentService.GetDepartmentById(id);

            if (result == null)
                return NotFound($"Department with Id '{id}' not found.");

            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult AddDepartment([FromBody] Department request)
        {
            var result = _departmentService.AddDepartment(request);

            if (result == null)
                return BadRequest($"Department with Id '{request.Id}' already exists.");

            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult UpdateDepartment([FromBody] Department request)
        {
            if (string.IsNullOrWhiteSpace(request.Id))
                return BadRequest("Department Id is required.");

            var result = _departmentService.UpdateDepartment(request);

            if (result == null)
                return BadRequest($"Department with Id '{request.Id}' not found.");

            return Ok(result);
        }

     
        [HttpDelete("delete")]
        public IActionResult DeleteDepartment([FromBody] Department request)
        {
            if (string.IsNullOrWhiteSpace(request.Id))
                return BadRequest("Department Id is required.");

            var result = _departmentService.DeleteDepartment(request);

            if (result == null)
                return NotFound($"Department with Id '{request.Id}' not found.");

            return Ok(result);
        }

        [HttpGet("HighBudgetDepartments")]
        public IActionResult GetHighBudgetDepartments()
        {
            var result = _departmentService.GetHighBudgetDepartments();

            if (result == null)
                return NotFound("No departments found with budget greater than 500000.");

            return Ok(result);
        }

    }
}
