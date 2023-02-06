namespace WebApi.Models
{
    public class PostModelGroupOfCourse
    {
        public int? CourseId { get; set; }

        public int? GroupId { get; set; }

        public int? NumActualHours { get; set; }

       // public virtual PostModelCourse? Course { get; set; }

      //  public virtual PostModelGroup? Group { get; set; }

       // public virtual ICollection<PostModelStudentInGroupOfCourse> StudentInGroupOfCourses { get; } = new List<PostModelStudentInGroupOfCourse>();
    }
}
