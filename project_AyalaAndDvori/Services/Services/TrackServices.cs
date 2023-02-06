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
    public class TrackServices: IDataServices<TrackDto>
    {

        private readonly IDataRepository<Track> dataRepository;
        private readonly IMapper mapper;
        public TrackServices(IDataRepository<Track> dataRepository, IMapper mapper)
        {
            this.dataRepository = dataRepository;
            this.mapper = mapper;
        }

        public async Task<TrackDto> AddDataAsync(TrackDto entity)
        {
            Track e = mapper.Map<Track>(entity);
            return  mapper.Map<TrackDto>(await dataRepository.AddDataAsync(e));
        }

        public async Task DeleteDataAsync(int id)
        {
            await dataRepository.DeleteDataAsync(id);

        }

        public async Task<List<TrackDto>> GetAllAsync()
        {
            return  mapper.Map<List<TrackDto>>(await dataRepository.GetAllAsync());
        }

        public async Task<TrackDto> GetDataByIdAsync(int id)
        {
            return  mapper.Map<TrackDto>(await dataRepository.GetDataByIdAsync(id));
        }

        public async Task<TrackDto> UpdateDataAsync(TrackDto entity)
        {
            Track e = mapper.Map<Track>(entity);
            return  mapper.Map<TrackDto>(await dataRepository.UpdateDataAsync(e));
        }
    }
}
