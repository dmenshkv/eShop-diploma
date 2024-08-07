﻿using Catalog.Models.Configurations;
using Microsoft.Extensions.Options;

namespace Catalog.Core.Mapping;

[ExcludeFromCodeCoverage]
public class PictureResolver : IMemberValueResolver<BoardGame, BoardGameDto, string, object>
{
    private readonly CatalogConfig _config;

    public PictureResolver(IOptions<CatalogConfig> config)
    {
        _config = config.Value;
    }

    public object Resolve(BoardGame source, BoardGameDto destination, string sourceMember, object destMember, ResolutionContext context)
    {
        return $"/{_config.ImageUrl}/{sourceMember}";
    }
}