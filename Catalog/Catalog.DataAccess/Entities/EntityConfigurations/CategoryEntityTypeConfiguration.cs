namespace Catalog.DataAccess.Entities.EntityConfigurations;

[ExcludeFromCodeCoverage]
public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasIndex(c => c.Name)
            .IsUnique();
    }
}