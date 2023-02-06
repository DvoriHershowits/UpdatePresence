using System;
using System.Collections.Generic;

namespace Repositories.Entity;

public partial class StudentInGroupOfCourse
{
    public int StudentInGroupOfCourseId { get; set; }

    public int? StudentId { get; set; }

    public int? GroupOfCourseId { get; set; }

    public int? NumAbsence { get; set; }

    public virtual GroupOfCourse? GroupOfCourse { get; set; }

    public virtual Student? Student { get; set; }
}
