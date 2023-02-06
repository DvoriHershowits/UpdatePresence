using Microsoft.Extensions.DependencyInjection;
using Repositories.Entity;
using Repositories.Interface;
using Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public static class ServiceCollectionExtentionRepository
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDataRepository<StudyGroup>, StudyGroupRepository>();
            services.AddScoped<IDataRepository<Course>, CourseRepository>();
            services.AddScoped<IDataRepository<GroupOfCourse>, GroupOfCourseRepository>();
            services.AddScoped<IDataRepository<Student>, StudentRepository>();
            services.AddScoped<IDataRepository<StudentInGroupOfCourse>, StudentInGroupOfCourseRepository>();
            services.AddScoped<IDataRepository<Track>, TrackRepository>();
            return services;

        }


    }
}
