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
    public class StudyGroupServices :IDataServices<GroupDto>
    {

        private readonly IDataRepository<StudyGroup> dataRepository;
        private readonly IMapper mapper;

        public StudyGroupServices(IDataRepository<StudyGroup> dataRepository, IMapper mapper)
        {
            this.dataRepository = dataRepository;
            this.mapper = mapper;
        }

        public async Task<GroupDto> AddDataAsync(GroupDto entity)
        {
            StudyGroup e = mapper.Map<StudyGroup>(entity);
            return  mapper.Map<GroupDto>(await dataRepository.AddDataAsync(e));
        }

        public async Task DeleteDataAsync(int id)
        {
           await dataRepository.DeleteDataAsync(id);
        }

        public async Task<List<GroupDto>> GetAllAsync()
        {
            return  mapper.Map<List<GroupDto>>(await dataRepository.GetAllAsync());

        }

        public async Task<GroupDto> GetDataByIdAsync(int id)
        {
            return  mapper.Map<GroupDto>(await dataRepository.GetDataByIdAsync(id));
        }

        public async Task<GroupDto> UpdateDataAsync(GroupDto entity)
        {
            StudyGroup e = mapper.Map<StudyGroup>(entity);
            return  mapper.Map<GroupDto>(await dataRepository.UpdateDataAsync(e));
        }
    }
}
