using Common.DTO_s;
using Context.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Repositories.Entity;
using Repositories.Interface;
using Services.Interfaces;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ServiceCollectionExtentionService
    {

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddScoped<IDataServices<CourseDto>, CourseServices>();
            services.AddScoped<IDataServices<GroupDto>, StudyGroupServices>();

            services.AddScoped<IDataServices<GroupOfCourseDto>, GroupOfCourseServices>();
            services.AddScoped<IDataServices<StudentInGroupOfCourseDto>, StudentInGroupOfCourseServices>();
            services.AddScoped<IDataServices<StudentDto>, StudentServices>();
            services.AddScoped<IDataServices<TrackDto>, TrackServices>();
            services.AddSingleton<IContext, DvoriAndayalaContext>();

            services.AddAutoMapper(typeof(MappingProfileServices));

            return services;
        }
        public static string ToStringProperty<T>(this T obj)
        {
            string str = "";
            string s;
            foreach (var item in obj.GetType().GetProperties())
            {
                var q = item.GetValue(item);
                str += item.Name;
                if (item.PropertyType.IsArray)
                {
                    s = String.Join(',', q as string[]);
                    str += "\n" + q;
                }
                else
                {
                    str += item.Name + ": " + item?.GetValue(item) + "\n";
                }
            }
            return str;
        }
    }
}
