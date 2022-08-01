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
    public DbSet<Prescription> Prescriptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Medicine-Prescription Many-to-Many
        modelBuilder.Entity<Prescription>()
            .HasMany(p => p.Medicines)
            .WithMany(m => m.Prescriptions)
            .UsingEntity<MedicinePrescription>(
                j => j
                    .HasOne(mp => mp.Medicine)
                    .WithMany(m => m.MedicinePrescriptions)
                    .HasForeignKey(mp => mp.MedicineId)
                    .OnDelete(DeleteBehavior.Restrict),
                j => j
                    .HasOne(mp => mp.Prescription)
                    .WithMany(p => p.MedicinePrescriptions)
                    .HasForeignKey(mp => mp.PrescriptionId)
                    .OnDelete(DeleteBehavior.Restrict),
                j =>
                {
                    j.HasKey(t => new {t.MedicineId, t.PrescriptionId});
                });
        #endregion

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HospitalContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}