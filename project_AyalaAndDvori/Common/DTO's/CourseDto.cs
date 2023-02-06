using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO_s
{
    public class CourseDto
    {
        public int CourseId { get; set; }

        public int? TrackId { get; set; }

        public string? FullName { get; set; }

        public int? NumHours { get; set; }

        public virtual ICollection<GroupOfCourseDto> GroupOfCourses { get; } = new List<GroupOfCourseDto>();

        public virtual TrackDto? Track { get; set; }

    }
}
