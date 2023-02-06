using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO_s
{
    public class StudentDto
    {
        public int StudentId { get; set; }

        public int? StudentIdnumber { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Phone { get; set; }

        public virtual ICollection<StudentInGroupOfCourseDto> StudentInGroupOfCourses { get; } = new List<StudentInGroupOfCourseDto>();
    }
}
