using AutoMapper;
using Common.DTO_s;
using Microsoft.Extensions.Logging;
using Repositories.Entity;
using Repositories.Interface;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class StudentInGroupOfCourseServices : IDataServices<StudentInGroupOfCourseDto>
    {
        private readonly IDataRepository<StudentInGroupOfCourse> dataRepository;
        private readonly IMapper mapper;
        public StudentInGroupOfCourseServices(IDataRepository<StudentInGroupOfCourse> dataRepository, IMapper mapper)
        {
            this.dataRepository = dataRepository;
            this.mapper = mapper;
        }

        public async Task<StudentInGroupOfCourseDto> AddDataAsync(StudentInGroupOfCourseDto entity)
        {
            StudentInGroupOfCourse e = mapper.Map<StudentInGroupOfCourse>(entity);
            return  mapper.Map<StudentInGroupOfCourseDto>(await dataRepository.AddDataAsync(e));
        }

        public async Task DeleteDataAsync(int id)
        {
            await dataRepository.DeleteDataAsync(id);
        }

        public async Task<List<StudentInGroupOfCourseDto>> GetAllAsync()
        {
            return await mapper.Map<Task<List<StudentInGroupOfCourseDto>>>(dataRepository.GetAllAsync());               
        }

        public async Task<StudentInGroupOfCourseDto> GetDataByIdAsync(int id)
        {
            return  mapper.Map<StudentInGroupOfCourseDto>(await dataRepository.GetDataByIdAsync(id));
        }

        public async Task<StudentInGroupOfCourseDto> UpdateDataAsync(StudentInGroupOfCourseDto entity)
        {
            StudentInGroupOfCourse e = mapper.Map<StudentInGroupOfCourse>(entity);

            return  mapper.Map<StudentInGroupOfCourseDto>(await dataRepository.UpdateDataAsync(e));
        }
    }
}
