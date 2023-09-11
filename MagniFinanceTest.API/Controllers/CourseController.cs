using MagniFinanceTest.Application.Contracts;
using MagniFinanceTest.Application.DTOs;
using MagniFinanceTest.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MagniFinanceTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICoursesService coursesService;

        public CourseController(ICoursesService coursesService)
        {
            this.coursesService = coursesService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await this.coursesService.ListAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("Info")]
        public async Task<ActionResult> GetCourseInformations()
        {
            var result = await this.coursesService.GetCourseInformation();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Add(CourseDTO course)
        {
            var result = await this.coursesService.Add(course);
            if(result == null)
            {
                return BadRequest("Error caused when trying to add the course");
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(int id, CourseDTO course)
        {
            var result = await this.coursesService.Update(id, course);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await this.coursesService.Delete(id);

            return Ok(result);
        }
    }
}
