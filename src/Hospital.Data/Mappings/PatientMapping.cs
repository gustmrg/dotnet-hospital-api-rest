using Hospital.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Data.Mappings;

public class PatientMapping : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnType("varchar(200)");
        
        builder.Property(p => p.Age)
            .IsRequired()
            .HasColumnType("tinyint");

        builder.Property(p => p.Gender)
            .IsRequired()
            .HasColumnType("varchar(40)");

        // builder.Property(p => p.Address)
        //     .IsRequired()
        //     .HasColumnType("varchar(1000)");

        builder.Property(p => p.Phone)
            .IsRequired()
            .HasColumnType("varchar(20)");

        builder.Property(p => p.DateBirth)
            .IsRequired()
            .HasColumnType("date");
        
        builder.HasMany(p => p.Prescriptions)
            .WithOne(p => p.Patient)
            .HasForeignKey(p => p.PatientId);

        builder.ToTable("Patients");
    }
}