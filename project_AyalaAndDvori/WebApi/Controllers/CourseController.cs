using AutoMapper;
using Common.DTO_s;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IDataServices<CourseDto> dataServices;
        public CourseController(IDataServices<CourseDto> dataServices)
        {
            this.dataServices = dataServices;
        }

        // GET: api/<CourseController>
        [HttpGet]
        public async Task<List<PostModelCourse>> GetDataAsync()
        {

            List<CourseDto> lst = await dataServices.GetAllAsync();
            List<PostModelCourse> data = new List<PostModelCourse>();
            for (int i = 0; i < lst.Count; i++)
            {
                PostModelCourse c = new PostModelCourse();
                c.TrackId = lst[i].TrackId;
                c.NumHours = lst[i].NumHours;
                c.FullName = lst[i].FullName;
                data.Add(c);
            }
            return data;
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<PostModelCourse> GetDataByIdAsync(int id)
        {
            CourseDto course = await dataServices.GetDataByIdAsync(id);
            PostModelCourse data = new PostModelCourse();
            data.TrackId = course.TrackId;
            data.NumHours = course.NumHours;
            data.FullName = course.FullName;
            return data;
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<PostModelCourse> AddDataAsync([FromBody] PostModelCourse value)
        {
            CourseDto course = new CourseDto();
            course.TrackId = value.TrackId;
            course.NumHours = value.NumHours;
            course.FullName = value.FullName;
            await dataServices.AddDataAsync(course);
            return value;
        }

        // PUT api/<CourseController>/5
        [HttpPut]
        public async Task<PostModelCourse> UpdateDataAsync(int id,[FromBody] PostModelCourse value)
        {
            CourseDto course = new CourseDto();
            course.TrackId = value.TrackId;
            course.NumHours = value.NumHours;
            course.FullName = value.FullName;
            course.CourseId = id;
            await dataServices.UpdateDataAsync(course);
            return value;
        }
        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task DeleteDataByIdAsync(int id)
        {
            await dataServices.DeleteDataAsync(id);
        }
    }
}
