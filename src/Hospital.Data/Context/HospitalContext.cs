using Hospital.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data.Context;

public class HospitalContext : DbContext
{
    public HospitalContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Medicine> Medicines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HospitalContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}