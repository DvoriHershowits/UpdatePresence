using System;
using System.Collections.Generic;

namespace Repositories.Entity;

public partial class Student
{
    public int StudentId { get; set; }

    public int? StudentIdnumber { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<StudentInGroupOfCourse> StudentInGroupOfCourses { get; } = new List<StudentInGroupOfCourse>();
}
