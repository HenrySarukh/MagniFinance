using MagniFinanceTest.Application.Contracts;
using MagniFinanceTest.Application.DTOs;
using MagniFinanceTest.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MagniFinanceTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await this.subjectService.ListAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("Info")]
        public async Task<ActionResult> GetSubjectsInformation()
        {
            var result = await this.subjectService.GetSubjectsInformation();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Add(SubjectDTO subject)
        {
            var result = await this.subjectService.Add(subject);
            if(result == null)
            {
                return BadRequest("Error caused when trying to add the subject");
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(int id, SubjectDTO subject)
        {
            var result = await this.subjectService.Update(id, subject);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await this.subjectService.Delete(id);

            return Ok(result);
        }
    }
}
