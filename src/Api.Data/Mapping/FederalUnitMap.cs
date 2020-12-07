using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Api.Data.Mapping
{
    public class FederalUnitMap : IEntityTypeConfiguration<FederalUnitEntity>
    {
        public void Configure(EntityTypeBuilder<FederalUnitEntity> builder)
        {
            builder.ToTable("FederalUnit");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Initials)
                   .IsUnique();

            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(45);
        }
    }
}