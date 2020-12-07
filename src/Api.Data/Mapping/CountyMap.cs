using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class CountyMap: IEntityTypeConfiguration<CountyEntity>
    {
        public void Configure(EntityTypeBuilder<CountyEntity> builder)
        {
            builder.ToTable("County");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.CodeIbge);

            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.HasOne(u => u.FederalUnit)
                   .WithMany(m => m.Counties);

            

            
        }
    }
}