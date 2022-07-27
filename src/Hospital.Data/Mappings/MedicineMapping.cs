using Hospital.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Data.Mappings;

public class MedicineMapping : IEntityTypeConfiguration<Medicine>
{
    public void Configure(EntityTypeBuilder<Medicine> builder)
    {
        builder.HasKey(m => m.Id);
        
        builder.Property(m => m.Name)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(m => m.Company)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.ToTable("Medicines");
    }
}