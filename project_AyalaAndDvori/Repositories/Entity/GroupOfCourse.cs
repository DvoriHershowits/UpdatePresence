using System;
using System.Collections.Generic;

namespace Repositories.Entity;

public partial class GroupOfCourse
{
    public int GroupOfCourseId { get; set; }

    public int? CourseId { get; set; }

    public int? GroupId { get; set; }

    public int? NumActualHours { get; set; }

    public virtual Course? Course { get; set; }

    public virtual StudyGroup? Group { get; set; }

    public virtual ICollection<StudentInGroupOfCourse> StudentInGroupOfCourses { get; } = new List<StudentInGroupOfCourse>();
}
