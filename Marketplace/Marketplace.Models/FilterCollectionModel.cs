using Marketplace.Models.Enums;
using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Models;

[ExcludeFromCodeCoverage]
public class FilterCollectionModel
{
    public FilterTypeEnum FilterTypeEnum { get; set; }

    public bool IsCollection { get; set; }
}