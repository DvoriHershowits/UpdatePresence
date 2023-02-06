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
    public class GroupOfCourseServices : IDataServices<GroupOfCourseDto>
    {
        private readonly IDataRepository<GroupOfCourse> dataRepository;
        private readonly IMapper mapper;

        public GroupOfCourseServices(IDataRepository<GroupOfCourse> dataRepository, IMapper mapper)
        {
            this.dataRepository = dataRepository;
            this.mapper = mapper;
        }

        public async Task<GroupOfCourseDto> AddDataAsync(GroupOfCourseDto entity)
        {
            GroupOfCourse e = mapper.Map<GroupOfCourse>(entity);
            return  mapper.Map<GroupOfCourseDto>(await dataRepository.AddDataAsync(e));
        }

        public async Task DeleteDataAsync(int id)
        {
            await dataRepository.DeleteDataAsync(id);
        }

        public async Task<List<GroupOfCourseDto>> GetAllAsync()
        {
            return  mapper.Map<List<GroupOfCourseDto>>(await dataRepository.GetAllAsync());
        }

        public async Task<GroupOfCourseDto> GetDataByIdAsync(int id)
        {
            return  mapper.Map<GroupOfCourseDto>(await dataRepository.GetDataByIdAsync(id));
        }

        public async Task<GroupOfCourseDto> UpdateDataAsync(GroupOfCourseDto entity)
        {
           GroupOfCourse e=mapper.Map<GroupOfCourse>(entity);
            return  mapper.Map<GroupOfCourseDto>(await dataRepository.UpdateDataAsync(e));
        }
    }
}
