using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweeftAssignment.Task_7.Entities;

namespace SweeftAssignment.Task_7.Database.Configurations;

public class TeacherPupilConfiguration : IEntityTypeConfiguration<TeacherPupil>
{
    public void Configure(EntityTypeBuilder<TeacherPupil> builder)
    {
        builder.ToTable("TeacherPupils");
            
        builder.HasKey(tp => tp.Id);
            
        builder.Property(tp => tp.TeacherId)
            .IsRequired();
                
        builder.Property(tp => tp.PupilId)
            .IsRequired();
            
        builder.HasOne(tp => tp.Teacher)
            .WithMany(t => t.TeacherPupils)
            .HasForeignKey(tp => tp.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);
                
        builder.HasOne(tp => tp.Pupil)
            .WithMany(p => p.TeacherPupils)
            .HasForeignKey(tp => tp.PupilId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasIndex(tp => new { tp.TeacherId, tp.PupilId })
            .IsUnique()
            .HasDatabaseName("IX_TeacherPupils_TeacherId_PupilId");
    }
}