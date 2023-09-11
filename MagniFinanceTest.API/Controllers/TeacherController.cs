using MagniFinanceTest.Application.Contracts;
using MagniFinanceTest.Application.DTOs;
using MagniFinanceTest.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;

namespace MagniFinanceTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await this.teacherService.ListAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Add(TeacherDTO teacher)
        {
            var result = await this.teacherService.Add(teacher);
            if(result == null)
            {
                return BadRequest("Error caused when trying to add the teacher");
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(int id, TeacherDTO teacher)
        {
            var result = await this.teacherService.Update(id, teacher);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await this.teacherService.Delete(id);

            return Ok(result);
        }
    }
}
