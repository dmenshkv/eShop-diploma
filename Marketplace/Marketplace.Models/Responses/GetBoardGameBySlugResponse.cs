using Marketplace.Models.ViewModels;
using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Models.Responses
{
    [ExcludeFromCodeCoverage]
    public class GetBoardGameBySlugResponse
    {
        public BoardGameViewModel BoardGame { get; set; } = null!;
    }
}