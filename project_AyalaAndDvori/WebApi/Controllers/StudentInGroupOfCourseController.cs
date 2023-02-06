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
    public class StudentInGroupOfCourseController : ControllerBase
    {
        IDataServices<StudentInGroupOfCourseDto> dataServices;
        public StudentInGroupOfCourseController(IDataServices<StudentInGroupOfCourseDto> dataServices)
        {
            this.dataServices = dataServices;
        }

        // GET: api/<StudentInGroupOfCourseController>
        [HttpGet]
        public async Task<List<PostModelStudentInGroupOfCourse>> GetDataAsync()
        {
            List<StudentInGroupOfCourseDto> lst = await dataServices.GetAllAsync();
            List<PostModelStudentInGroupOfCourse> data = new List<PostModelStudentInGroupOfCourse>();
            for (int i = 0; i < lst.Count; i++)
            {
                PostModelStudentInGroupOfCourse s = new PostModelStudentInGroupOfCourse();
                s.StudentId = lst[i].StudentId;
                s.GroupOfCourseId = lst[i].GroupOfCourseId;
                s.NumAbsence = lst[i].NumAbsence;
                data.Add(s);
            }
            return data;

        }

        // GET api/<StudentInGroupOfCourseController>/5
        [HttpGet("{id}")]
        public async Task<PostModelStudentInGroupOfCourse> GetDataByIdAsync(int id)
        {
            StudentInGroupOfCourseDto track = await dataServices.GetDataByIdAsync(id);
            PostModelStudentInGroupOfCourse data = new PostModelStudentInGroupOfCourse();
            data.StudentId = track.StudentId;
            data.GroupOfCourseId = track.GroupOfCourseId;
            data.NumAbsence = track.NumAbsence;
            return data;
        }

        // POST api/<TrackController>
        [HttpPost]
        public async Task<PostModelStudentInGroupOfCourse> AddDataAsync([FromBody] PostModelStudentInGroupOfCourse value)
        {
            StudentInGroupOfCourseDto track = new StudentInGroupOfCourseDto();
            track.StudentId = value.StudentId;
            track.GroupOfCourseId = value.GroupOfCourseId;
            track.NumAbsence = value.NumAbsence;
            await dataServices.AddDataAsync(track);
            return value;
        }

        // PUT api/<TrackController>/5
        [HttpPut]
        public async Task<PostModelStudentInGroupOfCourse> UpdateDataAsync(int id,[FromBody] PostModelStudentInGroupOfCourse value)
        {
            StudentInGroupOfCourseDto sioc = new StudentInGroupOfCourseDto();
            sioc.StudentId = value.StudentId;
            sioc.GroupOfCourseId = value.GroupOfCourseId;
            sioc.NumAbsence = value.NumAbsence;
            sioc.StudentInGroupOfCourseId = id;
            await dataServices.UpdateDataAsync(sioc);
            return value;
        }

        // DELETE api/<StudentInGroupOfCourseController>/5
        [HttpDelete("{id}")]
        public async Task DeleteDataByIdAsync(int id)
        {
            await dataServices.DeleteDataAsync(id);
        }
    }

}

