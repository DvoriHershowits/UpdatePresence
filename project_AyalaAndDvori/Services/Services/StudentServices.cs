using AutoMapper;
using Common.DTO_s;
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
    public class StudentServices : IDataServices<StudentDto>
    {
        private readonly IDataRepository<Student> dataRepository;
        private readonly IMapper mapper;
        public StudentServices(IDataRepository<Student> dataRepository, IMapper mapper)
        {
            this.dataRepository = dataRepository;
            this.mapper = mapper;
        }

        public async Task<StudentDto> AddDataAsync(StudentDto entity)
        {
            Student e = mapper.Map<Student>(entity);
            return  mapper.Map<StudentDto>(await dataRepository.AddDataAsync(e));
        }

        public async Task DeleteDataAsync(int id)
        {
            await dataRepository.DeleteDataAsync(id);
        }

        public async Task<List<StudentDto>> GetAllAsync()
        {
            
            return  mapper.Map<List<StudentDto>>( await dataRepository.GetAllAsync());
        }

        public async Task<StudentDto> GetDataByIdAsync(int id)
        {
            return  mapper.Map<StudentDto>(await dataRepository.GetDataByIdAsync(id));
        }

        public async Task<StudentDto> UpdateDataAsync(StudentDto entity)
        {
            Student e = mapper.Map<Student>(entity);
            return  mapper.Map<StudentDto>(await dataRepository.UpdateDataAsync(e));
        }
    }
}
