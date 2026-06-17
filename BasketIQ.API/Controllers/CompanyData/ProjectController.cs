using BasketIQ.API.Interfaces.CompanyData;
using Microsoft.AspNetCore.Mvc;
using BasketIQ.API.Models.CompanyData;

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

    }
}
