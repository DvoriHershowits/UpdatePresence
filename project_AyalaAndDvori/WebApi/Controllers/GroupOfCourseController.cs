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
    public class GroupOfCourseController : ControllerBase
    {
        private readonly IDataServices<GroupOfCourseDto> dataServices;
        public GroupOfCourseController(IDataServices<GroupOfCourseDto> dataServices)
        {
            this.dataServices = dataServices;
        }

        // GET: api/<GroupOfCourseController>
        [HttpGet]
        public async Task<List<PostModelGroupOfCourse>> GetDataAsync()
        {
            List<GroupOfCourseDto> lst = await dataServices.GetAllAsync();
            List<PostModelGroupOfCourse> data = new List<PostModelGroupOfCourse>();
            for (int i = 0; i < lst.Count; i++)
            {
                PostModelGroupOfCourse gOc = new PostModelGroupOfCourse();
                gOc.CourseId = lst[i].CourseId;
                gOc.GroupId = lst[i].GroupId;
                gOc.NumActualHours = lst[i].NumActualHours;
                data.Add(gOc);
            }
            return data;
        }

        // GET api/<GroupOfCourseController>/5
        [HttpGet("{id}")]
        public async Task<PostModelGroupOfCourse> GetDataByIdAsync(int id)
        {
            GroupOfCourseDto gOc = await dataServices.GetDataByIdAsync(id);
            PostModelGroupOfCourse data = new PostModelGroupOfCourse();
            data.CourseId = gOc.CourseId;
            data.GroupId = gOc.GroupId;
            data.NumActualHours = gOc.NumActualHours;
            return data;
        }
        // POST api/<GroupOfCourseController>
        [HttpPost]
        public async Task<PostModelGroupOfCourse> AddDataAsync([FromBody] PostModelGroupOfCourse value)
        {
            GroupOfCourseDto gOc = new GroupOfCourseDto();
            gOc.CourseId = value.CourseId;
            gOc.GroupId = value.GroupId;
            gOc.NumActualHours = value.NumActualHours;
            await dataServices.AddDataAsync(gOc);
            return value;
        }
        // PUT api/<GroupOfCourseController>/5
        [HttpPut]
        public async Task<PostModelGroupOfCourse> UpdateDataAsync(int id,[FromBody] PostModelGroupOfCourse value)
        {
            GroupOfCourseDto gOc = new GroupOfCourseDto();
            gOc.CourseId = value.CourseId;
            gOc.GroupId = value.GroupId;
            gOc.NumActualHours = value.NumActualHours;
            gOc.GroupOfCourseDtoId = id;
            await dataServices.UpdateDataAsync(gOc);
            return value;
        }

        // DELETE api/<GroupOfCourseController>/5
        [HttpDelete("{id}")]
        public async Task DeleteDataByIdAsync(int id)
        {
            await dataServices.DeleteDataAsync(id);
        }
    }
}
