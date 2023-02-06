using AutoMapper;
using Common.DTO_s;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly IDataServices<TrackDto> dataServices;
        public TrackController(IDataServices<TrackDto> dataServices)
        {
            this.dataServices = dataServices;
        }

        // GET: api/<TrackController>
        [HttpGet]
        public async Task<List<PostModelTrack>> GetDataAsync()
        {
            List<TrackDto> lst = await dataServices.GetAllAsync();
            List<PostModelTrack> data = new List<PostModelTrack>();
            for (int i = 0; i < lst.Count; i++)
            {
                PostModelTrack t = new PostModelTrack();
                t.NameTrack = lst[i].NameTrack;
                data.Add(t);
            }
            return data;
        }

        // GET api/<TrackController>/5
        [HttpGet("{id}")]
        public async Task<PostModelTrack> GetDataByIdAsync(int id)
        {
            TrackDto track = await dataServices.GetDataByIdAsync(id);
            PostModelTrack data = new PostModelTrack();
            data.NameTrack = track.NameTrack;
            return data;
        }

        // POST api/<TrackController>
        [HttpPost]
        public async Task<PostModelTrack> AddDataAsync([FromBody] PostModelTrack value)
        {
            TrackDto track = new TrackDto();
            track.NameTrack = value.NameTrack;
            await dataServices.AddDataAsync(track);
            return value;
        }

        // PUT api/<TrackController>/5
        [HttpPut]
        public async Task<PostModelTrack> UpdateDataAsync(int id,[FromBody] PostModelTrack value)
        {
            TrackDto track = new TrackDto();
            track.NameTrack = value.NameTrack;
            track.TrackId = id; 

            await dataServices.UpdateDataAsync(track);
            return value;
        }
        // DELETE api/<TrackController>/5
        [HttpDelete("{id}")]
        public async Task DeleteDataByIdAsync(int id)
        {
            await dataServices.DeleteDataAsync(id);
        }
    }
}
