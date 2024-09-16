namespace Catalog.Core.Models.Requests;

[ExcludeFromCodeCoverage]
public class CreateBrandRequest
{
    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;
}