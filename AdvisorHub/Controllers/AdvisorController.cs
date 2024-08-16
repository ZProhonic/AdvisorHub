using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdvisorHub.Models;
using AdvisorHub.DAL;

namespace AdvisorHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvisorController : ControllerBase
    {
        private readonly AdvisorRepository _advisorrepository;

        public AdvisorController(AdvisorRepository advisorRepository)
        {
            _advisorrepository = advisorRepository;
        }

        [HttpGet]
        public IActionResult GetAllAdvisors()
        {
            var advisors = _advisorrepository.GetAllAdvisors();
            return Ok(advisors);
        }

        [HttpGet("{id}")]
        public IActionResult GetAdvisorById(int id)
        {
            var advisors = _advisorrepository.GetAdvisorById(id);
            if (advisors == null)
            {
                return NotFound();
            }
            return Ok(advisors);    
        }

        [HttpPost]
        public IActionResult CreateAdvisor([FromBody] AdvisorCreationDto advisorCreationDto)
        {
            if (ModelState.IsValid)
            {
                var advisor = _advisorrepository.AddAdvisor(advisorCreationDto);
                return CreatedAtAction(nameof(GetAdvisorById), new { id = advisor.Id }, advisor);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAdvisor(int id, [FromBody] AdvisorUpdateDto advisorUpdateDto)
        {
            var advisor = _advisorrepository.GetAdvisorById(id);
            if(advisor == null)
            {
                return NotFound();
            }

            advisor.FirstName = advisorUpdateDto.FirstName;
            advisor.LastName = advisorUpdateDto.LastName;
            advisor.Address = advisorUpdateDto.Address;
            advisor.Phone = advisorUpdateDto.Phone;
            advisor.Licenses = advisorUpdateDto.Licenses;
            advisor.Crd = advisorUpdateDto.Crd;
            advisor.RepId = advisorUpdateDto.RepId;
            advisor.Osj = advisorUpdateDto.Osj;
            advisor.NonOsj = advisorUpdateDto.NonOsj;
            advisor.EmailAddress = advisorUpdateDto.EmailAddress;
            advisor.IsHybrid = advisorUpdateDto.IsHybrid;
            advisor.Last4Ssn = advisorUpdateDto.Last4Ssn;
            advisor.AdditionalRepIds = advisorUpdateDto.AdditionalRepIds;
            advisor.StateRegistrations = advisorUpdateDto.StateRegistrations;
            advisor.RiaId = advisorUpdateDto.RiaId;
            advisor.RiaName = advisorUpdateDto.RiaName;

            _advisorrepository.UpdateAdvisor(advisor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAdvisor(int id)
        {
            var advisor = _advisorrepository.GetAdvisorById(id);
            if (advisor == null)
            {
                return NotFound();
            }

            _advisorrepository.DeleteAdvisorById(id);
            return NoContent();
        }
    }
}
