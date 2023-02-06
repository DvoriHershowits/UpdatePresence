using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO_s
{
    public class GroupOfCourseDto
    {
        public int GroupOfCourseDtoId { get; set; }

        public int? CourseId { get; set; }

        public int? GroupId { get; set; }

        public int? NumActualHours { get; set; }

        public virtual CourseDto? CourseDto { get; set; }

        public virtual GroupDto? GroupDto { get; set; }

        public virtual ICollection<StudentInGroupOfCourseDto> StudentInGroupOfCourses { get; } = new List<StudentInGroupOfCourseDto>();

    }
}
