namespace SweeftAssignment.Task_7.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TeacherPupil :  BaseEntity
{
    public int TeacherId { get; set; }
    public int PupilId { get; set; }
    public Teacher Teacher { get; set; } = null!;
    public Pupil Pupil { get; set; } = null!;
}
