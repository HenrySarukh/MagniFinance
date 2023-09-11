using AutoMapper;
using MagniFinanceTest.Application.DTOs;
using MagniFinanceTest.Domain.Entities;

namespace MagniFinanceTest.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Teacher, TeacherDTO>().
                ReverseMap();

            this.CreateMap<Student, StudentDTO>().
                ReverseMap();

            this.CreateMap<Course, CourseDTO>().
                ReverseMap();

            this.CreateMap<Subject, SubjectDTO>().
                ReverseMap();

            this.CreateMap<Grade, GradeDTO>().
                ReverseMap();
        }
    }
}
