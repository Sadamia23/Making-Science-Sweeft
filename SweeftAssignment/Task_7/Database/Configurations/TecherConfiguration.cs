using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using SweeftAssignment.Task_7.Database.Constants;
using SweeftAssignment.Task_7.Entities;

namespace SweeftAssignment.Task_7.Database.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("Teachers");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.FirstName)
            .IsRequired()
            .HasMaxLength(DatabaseConstants.FIRST_NAME_MAX_LENGTH);

        builder.Property(t => t.LastName)
            .IsRequired()
            .HasMaxLength(DatabaseConstants.LAST_NAME_MAX_LENGTH);

        builder.Property(t => t.Gender)
            .IsRequired()
            .HasMaxLength(DatabaseConstants.GENDER_MAX_LENGTH);

        builder.Property(t => t.Subject)
            .IsRequired()
            .HasMaxLength(DatabaseConstants.SUBJECT_MAX_LENGTH);
    }
}