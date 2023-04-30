using Catalog.Models.DTOs;
using System.Diagnostics.CodeAnalysis;

namespace Catalog.Models.Responses
{
    [ExcludeFromCodeCoverage]
    public class GetBoardGameBySlugResponse
    {
        public BoardGameDto BoardGame { get; init; } = null!;
    }
}