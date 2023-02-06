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
    public class GroupController : ControllerBase
    {
        private readonly IDataServices<GroupDto> _dataServices;
        public GroupController(IDataServices<GroupDto> dataServices)
        {
            _dataServices = dataServices;
        }

        // GET: api/<GroupController>
        [HttpGet]
        public async Task<List<PostModelGroup>> GetDataAsync()
        {
            List<GroupDto> lst = await _dataServices.GetAllAsync();
            List<PostModelGroup> data = new List<PostModelGroup>();
            for (int i = 0; i < lst.Count; i++)
            {
                PostModelGroup g = new PostModelGroup();
                g.NameGroup = lst[i].NameGroup;
                g.NumStudents = lst[i].NumStudents;
                data.Add(g);
            }
            return data;
        }

        // GET api/<GroupController>/5
        [HttpGet("{id}")]
        public async Task<PostModelGroup> GetDataByIdAsync(int id)
        {
            GroupDto group = await _dataServices.GetDataByIdAsync(id);
            PostModelGroup data = new PostModelGroup();
            data.NameGroup = group.NameGroup;
            data.NumStudents = group.NumStudents;
            return data;
        }
        // POST api/<GroupController>
        [HttpPost]
        public async Task<PostModelGroup> AddDataAsync([FromBody] PostModelGroup value)
        {
            GroupDto group = new GroupDto();
            group.NameGroup = value.NameGroup;
            group.NumStudents = value.NumStudents;
            await _dataServices.AddDataAsync(group);
            return value;
        }

        // PUT api/<GroupController>/5
        [HttpPut]
        public async Task<PostModelGroup> UpdateDataAsync(int id,[FromBody] PostModelGroup value)
        {
            GroupDto group = new GroupDto();
            group.NameGroup = value.NameGroup;
            group.NumStudents = value.NumStudents;
            group.GroupDtoId = id;
            await _dataServices.UpdateDataAsync(group);
            return value;
        }

        // DELETE api/<GroupController>/5
        [HttpDelete("{id}")]
        public async Task DeleteDataByIdAsync(int id)
        {
            await _dataServices.DeleteDataAsync(id);
        }
    }
}
