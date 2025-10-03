namespace SweeftAssignment.Task_7.Entities;

public class Teacher : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public ICollection<TeacherPupil> TeacherPupils { get; set; } = new List<TeacherPupil>();
    public ICollection<Pupil> Pupils => TeacherPupils.Select(tp => tp.Pupil).ToList();
}
