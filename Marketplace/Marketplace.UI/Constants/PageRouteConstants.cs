using System.Diagnostics.CodeAnalysis;

namespace Marketplace.UI.Constants;

[ExcludeFromCodeCoverage]
public static class PageRouteConstants
{
    public const string HomePage = "/";

    public const string BoardGame = "board-game/{slug}";

    public const string Basket = "basket";
}