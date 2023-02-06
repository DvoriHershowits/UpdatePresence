using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO_s
{
    public class StudentInGroupOfCourseDto
    {
        public int StudentInGroupOfCourseId { get; set; }

        public int? StudentId { get; set; }

        public int? GroupOfCourseId { get; set; }

        public int? NumAbsence { get; set; }

        public virtual GroupOfCourseDto? GroupOfCourse { get; set; }

        public virtual StudentDto? Student { get; set; }
    }
}
