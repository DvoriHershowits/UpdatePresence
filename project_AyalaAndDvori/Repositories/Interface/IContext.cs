using Microsoft.EntityFrameworkCore;
using Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IContext
    {
        DbSet<Course> Coureses { get; set; }

        DbSet<StudyGroup> StudyGroups { get; set; }

        DbSet<GroupOfCourse> GroupOfCourses { get; set; }

        DbSet<Student> Students { get; set; }

        DbSet<StudentInGroupOfCourse> StudentInGroupOfCourses { get; set; }

        DbSet<Track> Tracks { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
