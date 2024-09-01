using ForeignApplicationsCollector.Models;
using ForeignApplicationsCollector.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForeignApplicationsCollector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly ApplicationsService _applicationsService;

        public ApplicationsController(ApplicationsService applicationsService)
        {
            _applicationsService = applicationsService;
        }

        [HttpPost("AddApplication")]
        public IActionResult AddApplication([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                _applicationsService.AddApplication(user);
                return Ok(new { message = "Application added successfully." });
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetApplications")]
        public IActionResult GetApplications()
        {
            var applications = _applicationsService.GetApplications();
            return Ok(applications);
        }

        [HttpPut("UpdateApplication/{id}")]
        public IActionResult UpdateApplication(int id, [FromBody] UpdatingUser updatedUser)
        {
            if (ModelState.IsValid)
            {
                var updated = _applicationsService.UpdateApplication(id, updatedUser);
                if (updated)
                {
                    return Ok(new { message = "Application updated successfully." });
                }
                return NotFound(new { message = "Application not found." });
            }
            return BadRequest(ModelState);
        }
    }
}
