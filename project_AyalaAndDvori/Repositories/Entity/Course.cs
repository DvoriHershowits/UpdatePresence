using System;
using System.Collections.Generic;

namespace Repositories.Entity;

public partial class Course
{
    public int CourseId { get; set; }

    public int? TrackId { get; set; }

    public string? FullName { get; set; }

    public int? NumHours { get; set; }

    public virtual ICollection<GroupOfCourse> GroupOfCourses { get; } = new List<GroupOfCourse>();

    public virtual Track? Track { get; set; }
}
