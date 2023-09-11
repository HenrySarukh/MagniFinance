using MagniFinanceTest.Application.Contracts;
using MagniFinanceTest.Application.DTOs;
using MagniFinanceTest.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MagniFinanceTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await this.studentService.ListAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("Info")]
        public async Task<ActionResult> GetStudentsInformation()
        {
            var result = await this.studentService.GetStudentsInformation();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Add(StudentDTO student)
        {
            var result = await this.studentService.Add(student);
            if(result == null)
            {
                return BadRequest("Error caused when trying to add the student");
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(int id, StudentDTO student)
        {
            var result = await this.studentService.Update(id, student);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await this.studentService.Delete(id);

            return Ok(result);
        }
    }
}
