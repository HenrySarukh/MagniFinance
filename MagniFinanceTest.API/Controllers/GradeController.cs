using MagniFinanceTest.Application.Contracts;
using MagniFinanceTest.Application.DTOs;
using MagniFinanceTest.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MagniFinanceTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService gradeService;

        public GradeController(IGradeService gradeService)
        {
            this.gradeService = gradeService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await this.gradeService.ListAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Add(GradeDTO grade)
        {
            var result = await this.gradeService.Add(grade);
            if(result == null)
            {
                return BadRequest("Error caused when trying to add the grade");
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(int id, GradeDTO grade)
        {
            var result = await this.gradeService.Update(id, grade);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await this.gradeService.Delete(id);

            return Ok(result);
        }
    }
}
