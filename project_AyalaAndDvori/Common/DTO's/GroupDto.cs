using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO_s
{
    public class GroupDto
    {
        public int GroupDtoId { get; set; }

        public string? NameGroup { get; set; }

        public int? NumStudents { get; set; }

        public virtual ICollection<GroupOfCourseDto> GroupOfCourses { get; } = new List<GroupOfCourseDto>();

    }
}
