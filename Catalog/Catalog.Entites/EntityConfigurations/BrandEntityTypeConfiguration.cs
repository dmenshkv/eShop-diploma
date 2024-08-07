using Catalog.Entites.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Catalog.Entites.EntityConfigurations;

[ExcludeFromCodeCoverage]
public class BrandEntityTypeConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(b => b.Id);

        builder.HasIndex(b => b.Name)
            .IsUnique();

        builder.Property(b => b.Country)
            .IsRequired()
            .HasMaxLength(25);
    }
}