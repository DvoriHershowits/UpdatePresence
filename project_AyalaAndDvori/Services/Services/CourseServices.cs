using AutoMapper;
using Common.DTO_s;
using Microsoft.Extensions.Logging;
using Repositories.Entity;
using Repositories.Interface;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CourseServices : IDataServices<CourseDto>
    {

        private readonly IDataRepository<Course> dataRepository;
        private readonly IMapper mapper;

        public CourseServices(IDataRepository<Course> dataRepository, IMapper mappar)
        {
            this.dataRepository = dataRepository;
            this.mapper = mappar;
        }

        public async Task<CourseDto> AddDataAsync(CourseDto entity)
        {
            Course e = mapper.Map<Course>(entity);
            return  mapper.Map<CourseDto>(await dataRepository.AddDataAsync(e));
        }

        public async Task DeleteDataAsync(int id)
        {
            await dataRepository.DeleteDataAsync(id);
        }
        public async Task<List<CourseDto>> GetAllAsync()
        {
            return  mapper.Map<List<CourseDto>>(await dataRepository.GetAllAsync());
        }

        public async Task<CourseDto> GetDataByIdAsync(int id)
        {
            return  mapper.Map<CourseDto>(await dataRepository.GetDataByIdAsync(id));
        }

        public async Task<CourseDto> UpdateDataAsync(CourseDto entity)
        {
            Course e = mapper.Map<Course>(entity);
            return  mapper.Map<CourseDto>(await dataRepository.UpdateDataAsync(e));
        }
    }
}
