using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using smartMedRestApi.Models;

namespace smartMedRestApi.Mappings
{
    public class MedicationMap : IEntityTypeConfiguration<Medication>
    {
        public void Configure(EntityTypeBuilder<Medication> builder)
        {
            builder.HasKey(c => c.id);
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Quantity).IsRequired();
            builder.Property(c => c.Creation_Date).IsRequired();

            builder.ToTable("medication");
        }
    }
}