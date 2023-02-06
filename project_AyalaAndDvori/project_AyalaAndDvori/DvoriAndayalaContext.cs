using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repositories.Entity;
using Repositories.Interface;

namespace Context.Entity;

public partial class DvoriAndayalaContext : DbContext,IContext
{
    public DvoriAndayalaContext()
    {
    }

    public DvoriAndayalaContext(DbContextOptions<DvoriAndayalaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Coureses { get; set; }

    public virtual DbSet<StudyGroup> StudyGroups { get; set; }

    public virtual DbSet<GroupOfCourse> GroupOfCourses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentInGroupOfCourse> StudentInGroupOfCourses { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=sqlsrv;Initial Catalog=dvoriANDayala;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK_Lessons");

            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.FullName)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.NumHours).HasColumnName("numHours");
            entity.Property(e => e.TrackId).HasColumnName("trackId");

            entity.HasOne(d => d.Track).WithMany(p => p.Coureses)
                .HasForeignKey(d => d.TrackId)
                .HasConstraintName("FK_Coureses_Tracks1");
        });

        modelBuilder.Entity<StudyGroup>(entity =>
        {
            entity.HasKey(e => e.StudyGroupId).HasName("PK_group");

            entity.ToTable("Group");

            entity.Property(e => e.StudyGroupId).HasColumnName("groupId");
            entity.Property(e => e.NameStudyGroup)
                .HasMaxLength(50)
                .HasColumnName("nameGroup");
            entity.Property(e => e.NumStudents).HasColumnName("numStudents");
        });

        modelBuilder.Entity<GroupOfCourse>(entity =>
        {
            entity.ToTable("GroupOfCourse");

            entity.Property(e => e.GroupOfCourseId).HasColumnName("groupOfCourseId");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.GroupId).HasColumnName("groupId");
            entity.Property(e => e.NumActualHours).HasColumnName("numActualHours");

            entity.HasOne(d => d.Course).WithMany(p => p.GroupOfCourses)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_GroupOfCourse_Coureses");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupOfCourses)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_GroupOfCourse_Group");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.StudentId).HasColumnName("studentId");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("lastName");
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("phone");
            entity.Property(e => e.StudentIdnumber).HasColumnName("studentIDNumber");
        });

        modelBuilder.Entity<StudentInGroupOfCourse>(entity =>
        {
            entity.ToTable("StudentInGroupOfCourse");

            entity.Property(e => e.StudentInGroupOfCourseId).HasColumnName("studentInGroupOfCourseId");
            entity.Property(e => e.GroupOfCourseId).HasColumnName("groupOfCourseId");
            entity.Property(e => e.NumAbsence).HasColumnName("numAbsence");
            entity.Property(e => e.StudentId).HasColumnName("studentId");

            entity.HasOne(d => d.GroupOfCourse).WithMany(p => p.StudentInGroupOfCourses)
                .HasForeignKey(d => d.GroupOfCourseId)
                .HasConstraintName("FK_StudentInGroupOfCourse_GroupOfCourse");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentInGroupOfCourses)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_StudentInGroupOfCourse_Students");
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.Property(e => e.NameTrack)
                .HasMaxLength(50)
                .HasColumnName("nameTrack");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
