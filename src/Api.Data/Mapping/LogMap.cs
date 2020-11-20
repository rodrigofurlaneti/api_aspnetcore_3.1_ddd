using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Api.Data.Mapping
{
    public class LogMap : IEntityTypeConfiguration<LogEntity>  
    {
        public void Configure(EntityTypeBuilder<LogEntity> builder)
        {
            builder.ToTable("Log");
            builder.HasKey(u => u.CreateAt);
        }
    }
}
