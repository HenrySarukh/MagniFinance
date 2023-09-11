using System.Reflection;
using MagniFinanceTest.Application.Contracts;
using MagniFinanceTest.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace SC.ValueChain.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<ICoursesService, CourseService>();


            return services;
        }
    }
}
