namespace Catalog.DataAccess.Entities.EntityConfigurations;

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