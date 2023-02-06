using System;
using System.Collections.Generic;

namespace Repositories.Entity;

public partial class Track
{
    public int TrackId { get; set; }

    public string NameTrack { get; set; } = null!;

    public virtual ICollection<Course> Coureses { get; } = new List<Course>();
}
