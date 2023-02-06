namespace WebApi.Models
{
    public class PostModelCourse
    {
        public int? TrackId { get; set; }

        public string? FullName { get; set; }

        public int? NumHours { get; set; }

       // public virtual ICollection<PostModelGroupOfCourse> GroupOfCourses { get; } = new List<PostModelGroupOfCourse>();

        //public virtual PostModelTrack? Track { get; set; }
    }
}
