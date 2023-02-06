using System;
using System.Collections.Generic;

namespace Repositories.Entity;

public partial class StudyGroup
{
    public int StudyGroupId { get; set; }

    public string? NameStudyGroup { get; set; }

    public int? NumStudents { get; set; }

    public virtual ICollection<GroupOfCourse> GroupOfCourses { get; } = new List<GroupOfCourse>();
}
