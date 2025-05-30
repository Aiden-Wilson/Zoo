using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZooApi.Data.Entities;
using ZooApi.Models;

namespace ZooApi.Data.Configurations
{
    public class AnimalConfiguration : IEntityTypeConfiguration<AnimalEntity>
    {
        public void Configure(EntityTypeBuilder<AnimalEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Species).IsRequired().HasMaxLength(255);
            builder.Property(x => x.EnergyLevel).IsRequired().HasMaxLength(3);
        }
    }
}
