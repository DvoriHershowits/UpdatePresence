using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO_s
{
    public class TrackDto
    {
        public int TrackId { get; set; }

        public string NameTrack { get; set; } = null!;

        public virtual ICollection<CourseDto> Coureses { get; } = new List<CourseDto>();
    }
}
