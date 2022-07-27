using Hospital.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Data.Mappings;

public class PrescriptionMapping : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.DatePrescription)
            .IsRequired()
            .HasColumnType("date");

        builder.ToTable("Prescriptions");
    }
}