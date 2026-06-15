using BasketIQ.API.Interfaces.CompanyData;
using Microsoft.AspNetCore.Mvc;

namespace BasketIQ.API.Controllers.CompanyData
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeInterface _employeeService;

        public EmployeeController(IEmployeeInterface employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("EmployeeDetails")]
        public IActionResult GetEmployeeDetails(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Employee Id is required.");

            var result = _employeeService.GetEmployeeDetails(id);

            if (result == null)
                return NotFound($"Employee with Id '{id}' not found.");

            return Ok(result);
        }
    }
}