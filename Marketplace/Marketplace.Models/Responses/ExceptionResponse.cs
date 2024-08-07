using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Models.Responses;

[ExcludeFromCodeCoverage]
public class ExceptionResponse
{
    public string? Type { get; set; }

    public string? Detail { get; set; }

    public string? Instance { get; set; }
}