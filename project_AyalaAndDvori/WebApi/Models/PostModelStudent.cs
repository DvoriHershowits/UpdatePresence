namespace WebApi.Models
{
    public class PostModelStudent
    {
        public int? StudentIdnumber { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Phone { get; set; }

      //  public virtual ICollection<PostModelStudentInGroupOfCourse> StudentInGroupOfCourses { get; } = new List<PostModelStudentInGroupOfCourse>();
    }
}
