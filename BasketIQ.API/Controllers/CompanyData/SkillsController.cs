using BasketIQ.API.Interfaces.CompanyData;
using Microsoft.AspNetCore.Mvc;

namespace BasketIQ.API.Controllers.CompanyData
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillsInterface _skillsService;

        public SkillsController(ISkillsInterface skillsService)
        {
            _skillsService = skillsService;
        }

        [HttpGet("BackendSkills")]
        public IActionResult GetBackendSkills()
        {
            var result = _skillsService.GetBackendSkills();

            if (result == null)
                return NotFound("No Backend skills found.");

            return Ok(result);
        }
    }
}
