using Catalog.Entites.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Catalog.Entites.EntityConfigurations
{
    [ExcludeFromCodeCoverage]
    public class MechanicEntityTypeConfiguration : IEntityTypeConfiguration<Mechanic>
    {
        public void Configure(EntityTypeBuilder<Mechanic> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasIndex(m => m.Name)
                .IsUnique();
        }
    }
}