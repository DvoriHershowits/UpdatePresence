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
    public class StudentController : ControllerBase
    {
        IDataServices<StudentDto> dataServices;
        public StudentController(IDataServices<StudentDto> dataServices)
        {
            this.dataServices = dataServices;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public async Task<List<PostModelStudent>> GetAllAsync()
        {
            List<StudentDto> lst = await dataServices.GetAllAsync();
            List<PostModelStudent> data = new List<PostModelStudent>();
            for (int i = 0; i < lst.Count; i++)
            {
                PostModelStudent s = new PostModelStudent();
               s.StudentIdnumber = lst[i].StudentIdnumber;
                s.Phone=lst[i].Phone;
                s.LastName=lst[i].LastName;
                s.FirstName=lst[i].FirstName;
                data.Add(s);
            }
            return data;


        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<PostModelStudent> GetDataByIdAsync(int id)
        {

            StudentDto student = await dataServices.GetDataByIdAsync(id);
            PostModelStudent data = new PostModelStudent();
            data.StudentIdnumber = student.StudentIdnumber;
            data.Phone =student.Phone;
            data.LastName =student.LastName;
            data.FirstName =student.FirstName;
            return data;
        }

        // POST api/<StudentController>
        [HttpPost]
        public  async Task<PostModelStudent> AddDataAsync([FromBody] PostModelStudent value)
        {
            StudentDto student = new StudentDto();
            student.StudentIdnumber = value.StudentIdnumber;
            student.FirstName = value.FirstName;
            student.LastName = value.LastName;
            student.Phone = value.Phone;    
            await dataServices.AddDataAsync(student);
            return value;


        }
        

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public async Task<PostModelStudent> UpdateDataAsync(int id,[FromBody] PostModelStudent value)
        {
            StudentDto student = new StudentDto();
            student.StudentIdnumber = value.StudentIdnumber;
            student.FirstName = value.FirstName;
            student.LastName = value.LastName;
            student.Phone = value.Phone;
            student.StudentId = id;
            await dataServices.UpdateDataAsync(student);
            return value;
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task DeleteDataByIdAsync(int id)
        {
            await dataServices.DeleteDataAsync(id);
        }
    }
}
