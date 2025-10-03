using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SweeftAssignment.Task_7.Entities;

namespace SweeftAssignment.Task_7.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Teacher> Teachers { get; set; } 
    public DbSet<Pupil> Pupils{ get; set; } 
    public DbSet<TeacherPupil> TeacherPupils { get; set; } 


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}