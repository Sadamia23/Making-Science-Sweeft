namespace SweeftAssignment.Task_7.Entities;


public class Pupil : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string Class { get; set; } = string.Empty;
    public ICollection<TeacherPupil> TeacherPupils { get; set; } = new List<TeacherPupil>();
    public ICollection<Teacher> Teachers => TeacherPupils.Select(tp => tp.Teacher).ToList();
}
