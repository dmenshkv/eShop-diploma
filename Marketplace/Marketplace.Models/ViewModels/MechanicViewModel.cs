using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Models.ViewModels;

[ExcludeFromCodeCoverage]
public class MechanicViewModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
}