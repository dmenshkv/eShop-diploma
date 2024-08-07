namespace Catalog.Core.Mapping;

[ExcludeFromCodeCoverage]
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BoardGame, BoardGameDto>()
            .ForMember("PictureUrl", opt
                => opt.MapFrom<PictureResolver, string>(c => c.PictureFileName))
            .ReverseMap();

        CreateMap<Brand, BrandDto>().ReverseMap();

        CreateMap<Category, CategoryDto>().ReverseMap();

        CreateMap<Mechanic, MechanicDto>().ReverseMap();
    }
}