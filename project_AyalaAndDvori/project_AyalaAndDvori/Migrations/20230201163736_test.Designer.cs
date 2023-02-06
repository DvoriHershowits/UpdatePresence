﻿// <auto-generated />
using System;
using Context.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Context.Migrations
{
    [DbContext(typeof(DvoriAndayalaContext))]
    [Migration("20230201163736_test")]
    partial class test
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Repositories.Entity.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("courseId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("FullName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("name");

                    b.Property<int?>("NumHours")
                        .HasColumnType("int")
                        .HasColumnName("numHours");

                    b.Property<int?>("TrackId")
                        .HasColumnType("int")
                        .HasColumnName("trackId");

                    b.HasKey("CourseId")
                        .HasName("PK_Lessons");

                    b.HasIndex("TrackId");

                    b.ToTable("Coureses");
                });

            modelBuilder.Entity("Repositories.Entity.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("groupId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"));

                    b.Property<string>("NameGroup")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nameGroup");

                    b.Property<int?>("NumStudents")
                        .HasColumnType("int")
                        .HasColumnName("numStudents");

                    b.HasKey("GroupId")
                        .HasName("PK_group");

                    b.ToTable("Group", (string)null);
                });

            modelBuilder.Entity("Repositories.Entity.GroupOfCourse", b =>
                {
                    b.Property<int>("GroupOfCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("groupOfCourseId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupOfCourseId"));

                    b.Property<int?>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("courseId");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int")
                        .HasColumnName("groupId");

                    b.Property<int?>("NumActualHours")
                        .HasColumnType("int")
                        .HasColumnName("numActualHours");

                    b.HasKey("GroupOfCourseId");

                    b.HasIndex("CourseId");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupOfCourse", (string)null);
                });

            modelBuilder.Entity("Repositories.Entity.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("studentId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("firstName");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("lastName");

                    b.Property<string>("Phone")
                        .HasMaxLength(11)
                        .HasColumnType("nchar(11)")
                        .HasColumnName("phone")
                        .IsFixedLength();

                    b.Property<int?>("StudentIdnumber")
                        .HasColumnType("int")
                        .HasColumnName("studentIDNumber");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Repositories.Entity.StudentInGroupOfCourse", b =>
                {
                    b.Property<int>("StudentInGroupOfCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("studentInGroupOfCourseId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentInGroupOfCourseId"));

                    b.Property<int?>("GroupOfCourseId")
                        .HasColumnType("int")
                        .HasColumnName("groupOfCourseId");

                    b.Property<int?>("NumAbsence")
                        .HasColumnType("int")
                        .HasColumnName("numAbsence");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("studentId");

                    b.HasKey("StudentInGroupOfCourseId");

                    b.HasIndex("GroupOfCourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentInGroupOfCourse", (string)null);
                });

            modelBuilder.Entity("Repositories.Entity.Track", b =>
                {
                    b.Property<int>("TrackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrackId"));

                    b.Property<string>("NameTrack")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nameTrack");

                    b.HasKey("TrackId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("Repositories.Entity.Course", b =>
                {
                    b.HasOne("Repositories.Entity.Track", "Track")
                        .WithMany("Coureses")
                        .HasForeignKey("TrackId")
                        .HasConstraintName("FK_Coureses_Tracks1");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Repositories.Entity.GroupOfCourse", b =>
                {
                    b.HasOne("Repositories.Entity.Course", "Course")
                        .WithMany("GroupOfCourses")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK_GroupOfCourse_Coureses");

                    b.HasOne("Repositories.Entity.Group", "Group")
                        .WithMany("GroupOfCourses")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_GroupOfCourse_Group");

                    b.Navigation("Course");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Repositories.Entity.StudentInGroupOfCourse", b =>
                {
                    b.HasOne("Repositories.Entity.GroupOfCourse", "GroupOfCourse")
                        .WithMany("StudentInGroupOfCourses")
                        .HasForeignKey("GroupOfCourseId")
                        .HasConstraintName("FK_StudentInGroupOfCourse_GroupOfCourse");

                    b.HasOne("Repositories.Entity.Student", "Student")
                        .WithMany("StudentInGroupOfCourses")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("FK_StudentInGroupOfCourse_Students");

                    b.Navigation("GroupOfCourse");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Repositories.Entity.Course", b =>
                {
                    b.Navigation("GroupOfCourses");
                });

            modelBuilder.Entity("Repositories.Entity.Group", b =>
                {
                    b.Navigation("GroupOfCourses");
                });

            modelBuilder.Entity("Repositories.Entity.GroupOfCourse", b =>
                {
                    b.Navigation("StudentInGroupOfCourses");
                });

            modelBuilder.Entity("Repositories.Entity.Student", b =>
                {
                    b.Navigation("StudentInGroupOfCourses");
                });

            modelBuilder.Entity("Repositories.Entity.Track", b =>
                {
                    b.Navigation("Coureses");
                });
#pragma warning restore 612, 618
        }
    }
}
