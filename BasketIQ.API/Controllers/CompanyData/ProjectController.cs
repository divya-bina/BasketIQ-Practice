using BasketIQ.API.Interfaces.CompanyData;
using BasketIQ.API.Models.CompanyData;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BasketIQ.API.Controllers.CompanyData
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectInterface _projectService;
        private int? a;

        public ProjectController(IProjectInterface projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]

        public IActionResult GetAllProjects()
        {
            var result = _projectService.GetAllProjects();  
            return Ok(result);
        }

        [HttpGet("PrjectById")]
        public IActionResult GetProjectById(string id)
        {
            var result = _projectService.GetProjectById(id);  
            

            if (result == null)
                return NotFound($"Project with id {id} not found");

            return Ok(result);
        }


        [HttpPost("update")]
        public IActionResult UpdateProject([FromBody] Project request)
        {
            var result = _projectService.UpdateProject(request);

            if (result == null)
                return NotFound($"Project with id {request.Id} not found");

            return Ok(result);
        }


        [HttpPost("add")]
        public IActionResult AddProject([FromBody] Project request)
        {
            var result = _projectService.AddProject(request);

            if (result == null)
                return BadRequest($"Project with Id '{request.Id}' already exists.");

            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteProject([FromBody] Project request)
        {
            var result = _projectService.DeleteProject(request);

            if (result == null)
                return NotFound($"Project with Id '{request.Id}' not found.");

            return Ok(result);
        }



        [HttpGet("ActiveProjects")]
        public IActionResult GetAllActiveStatusProjects()
        {
            var result = _projectService.GetAllActiveStatusProjects();

            if (result == null)
                return NotFound("No Active Projects found.");

            return Ok(result);
        }

        [HttpGet("ProjectsWithEmployeeCount")]
        public IActionResult GetProjectsWithEmployeeCount()
        {
            var result = _projectService.GetProjectsWithEmployeeCount();

            if (result == null)
                return NotFound("No projects found.");

            return Ok(result);
        }


        [HttpGet("HighBudgetProjects")]
        public IActionResult GetHighBudgetProject()
        {
            var result = _projectService.GetHighBudgetProject();
            if (result == null)
                return NotFound("No High Budget Projects found.");
            return Ok(result);
        }

        [HttpGet("MaintenanceProjects")]
        public IActionResult GetMaintenanceProjects()
        {
            var result = _projectService.GetMaintenanceProjects();
            if (result == null)
                return NotFound("No Maintenance Projects found.");
            return Ok(result);
        }

        [HttpPost("UpdateStatus")]
        public IActionResult UpdateProjectStatus(string id, string status)
        {
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(status))
                return BadRequest("Project Id and Status are required.");

            var result = _projectService.UpdateProjectStatus(id, status);

            if (result == null)
                return NotFound($"Project with Id '{id}' not found.");

            return Ok(result);
        }


        [HttpPost("UpdateProjectName")]
        public IActionResult UpadateProjectName(string id, string name)
        {
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name))
                return BadRequest("Project Id and Name are required.");
            var result = _projectService.UpdateProjectName(id, name);
            if (result == null)
                return NotFound($"Project with Id '{id}' not found.");
            return Ok(result);
        }

    }
}
