using BasketIQ.API.Interfaces.CompanyData;
using BasketIQ.API.Services.CompanyData;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

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

        [HttpGet("EmployeeDetailsById")]
        public IActionResult GetEmployeeDetailsById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Employee Id is required.");

            var result = _employeeService.GetEmployeeDetailsById(id);

            if (result == null)
                return NotFound($"Employee with Id '{id}' not found.");

            return Ok(result);
        }

        [HttpGet("EmployeeDetails")]

        public IActionResult GetEmployeeDetails()
        {
            var result = _employeeService.GetEmployeeDetails();

            if (result == null || result.Count == 0)
                return NotFound("No employees found.");

            return Ok(result);
        }


        [HttpGet("AllEmployeesWithCategory")]
        public IActionResult GetAllEmployeesWithCategory()
        {
            var result = _employeeService.GetAllEmployeesWithCategory();

            if (result == null || result.Count == 0)
                return NotFound("No employees found.");

            return Ok(result);
        }


        [HttpGet("AllEmployeesWithProject")]
        public IActionResult GetAllEmployeesWithProject()
        {
            var result = _employeeService.GetAllEmployeesWithProject();

            if (result == null || result.Count == 0)
                return NotFound("No employees found.");

            return Ok(result);
        }



        [HttpGet("RemoteEmployees")]
        public IActionResult GetRemoteEmployees()
        {
            var result = _employeeService.GetRemoteEmployees();

            if (result == null)
                return NotFound("No remote employees found.");

            return Ok(result);
        }

        [HttpGet("SeattleEmployees")]
        public IActionResult GetSeattleEmployees()
        {
            var result = _employeeService.GetSeattleEmployees();
            if (result == null)
                return NotFound("No Seattle employees found.");
            return Ok(result);
        }

        [HttpGet("EmployeeWithHighSalary")]
        public IActionResult GetEmployeeWithHighSalary()
        {
            var result = _employeeService.GetEmployeeWithHighSalary();
            if (result == null)
                return NotFound("No Employees found with salary greater than 100000.");
            return Ok(result);
        }

        [HttpGet("EmployeesJoinedAfter2022")]
        public IActionResult GetEmployeesJoinedAfter2022()
        {
            var result = _employeeService.GetEmployeesJoinedAfter2022();
            if (result == null)
                return NotFound("No Employees found who joined after 2022.");
            return Ok(result);
        }

        [HttpGet("ExperiencedEmployees")]

        public IActionResult GetExperiencedEmployees()
        {
            var result = _employeeService.GetExperiencedEmployees();
            if (result == null)
                return NotFound("No Experienced Employees found.");
            return Ok(result);
        }

        [HttpGet("HighestPaidEmployeePerDepartment")]
        public IActionResult GetHighestPaidEmployeePerDepartment()
        {
            var result = _employeeService.GetHighestPaidEmployeePerDepartment();

            if (result == null)
                return NotFound("No employees found.");

            return Ok(result);
        }

        [HttpGet("EmployeesSortedBySalary")]
        public IActionResult GetEmployeesSortedBySalary()
        {
            var result = _employeeService.GetEmployeesSortedBySalary();
            if (result == null || result.Count == 0)
                return NotFound("No employees found.");
            return Ok(result);
        }


    }
}