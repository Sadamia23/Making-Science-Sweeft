using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweeftAssignment.Task_7.Database.Constants;
using SweeftAssignment.Task_7.Entities;

namespace SweeftAssignment.Task_7.Database.Configurations;

public class PupilConfiguration : IEntityTypeConfiguration<Pupil> 
{ 
    public void Configure(EntityTypeBuilder<Pupil> builder)
        {
            builder.ToTable("Pupils");
            
            builder.HasKey(p => p.Id);
            
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(DatabaseConstants.FIRST_NAME_MAX_LENGTH);
                
            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(DatabaseConstants.LAST_NAME_MAX_LENGTH);
                
            builder.Property(p => p.Gender)
                .IsRequired()
                .HasMaxLength(DatabaseConstants.GENDER_MAX_LENGTH);
                
            builder.Property(p => p.Class)
                .IsRequired()
                .HasMaxLength(DatabaseConstants.CLASS_MAX_LENGTH);
            
            builder.HasMany(p => p.Teachers)
                .WithMany(t => t.Pupils)
                .UsingEntity<TeacherPupil>(
                    l => l.HasOne<Teacher>(tp => tp.Teacher)
                        .WithMany(t => t.TeacherPupils)
                        .HasForeignKey(tp => tp.TeacherId)
                        .OnDelete(DeleteBehavior.Cascade),
                    r => r.HasOne<Pupil>(tp => tp.Pupil)
                        .WithMany(p => p.TeacherPupils)
                        .HasForeignKey(tp => tp.PupilId)
                        .OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.ToTable("TeacherPupils");
                        j.HasKey(tp => tp.Id);
                        j.HasIndex(tp => new { tp.TeacherId, tp.PupilId })
                            .IsUnique();
                    });
        } 
}
