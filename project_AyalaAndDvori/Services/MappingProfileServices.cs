using AutoMapper;
using Common.DTO_s;
using Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MappingProfileServices:Profile
    {
        public MappingProfileServices()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<StudyGroup, GroupDto>().ReverseMap();
            CreateMap<GroupOfCourse, GroupOfCourseDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<StudentInGroupOfCourse, StudentInGroupOfCourseDto>().ReverseMap();
            CreateMap<Track, TrackDto>().ReverseMap();
        }

    }
}
