namespace Catalog.Core.Mapping;

[ExcludeFromCodeCoverage]
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region BoardGame

        CreateMap<CreateBoardGameRequest, BoardGame>();

        CreateMap<UpdateBoardGameRequest, BoardGame>();

        CreateMap<BoardGame, BoardGameDto>()
            .ForMember("PictureUrl", opt
                => opt.MapFrom<PictureResolver, string>(bg => bg.PictureFileName));

        #endregion

        #region Brand

        CreateMap<CreateBrandRequest, Brand>();

        CreateMap<Brand, BrandDto>().ReverseMap();

        #endregion

        #region Category

        CreateMap<CreateCategoryRequest, Category>();

        CreateMap<Category, CategoryDto>().ReverseMap();

        #endregion

        #region Mechanic

        CreateMap<CreateMechanicRequest, Mechanic>();

        CreateMap<Mechanic, MechanicDto>().ReverseMap();

        #endregion
    }
}