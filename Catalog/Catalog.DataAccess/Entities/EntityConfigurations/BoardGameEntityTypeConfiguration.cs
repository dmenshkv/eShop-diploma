namespace Catalog.DataAccess.Entities.EntityConfigurations;

[ExcludeFromCodeCoverage]
public class BoardGameEntityTypeConfiguration : IEntityTypeConfiguration<BoardGame>
{
    public void Configure(EntityTypeBuilder<BoardGame> builder)
    {
        builder.HasKey(bg => bg.Id);

        builder.HasIndex(bg => bg.Name)
            .IsUnique();

        builder.HasIndex(bg => bg.Slug)
            .IsUnique();

        builder.Property(bg => bg.Description)
            .IsRequired();

        builder.Property(bg => bg.Price)
            .HasPrecision(5, 2)
            .IsRequired();

        builder.Property(bg => bg.PictureFileName)
            .IsRequired();

        builder.Property(bg => bg.AvailableStock)
            .IsRequired();

        builder.HasOne(b => b.Brand)
            .WithMany(bg => bg.BoardGames)
            .HasForeignKey(b => b.BrandId);

        builder.HasMany(c => c.Categories)
            .WithMany(bg => bg.BoardGames)
            .UsingEntity<Dictionary<string, object>>(
                "BoardGameCategory",
                j => j.HasOne<Category>()
                        .WithMany()
                        .HasForeignKey("CategoryId"),
                j => j.HasOne<BoardGame>()
                        .WithMany()
                        .HasForeignKey("BoardGameId")
            );

        builder.HasMany(c => c.Mechanics)
            .WithMany(bg => bg.BoardGames)
            .UsingEntity<Dictionary<string, object>>(
                "BoardGameMechanic",
                j => j.HasOne<Mechanic>()
                        .WithMany()
                        .HasForeignKey("MechanicId"),
                j => j.HasOne<BoardGame>()
                        .WithMany()
                        .HasForeignKey("BoardGameId")
            );
    }
}