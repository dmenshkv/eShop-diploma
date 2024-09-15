using Catalog.Models.Configurations;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace Catalog.API.Extensions;

[ExcludeFromCodeCoverage]
public static class ODataOptionsExtensions
{
    public static void SetupODataOptions(this ODataOptions options, ConfigurationManager configuration)
    {
        var querySettings = configuration.GetSection(ConfigurationSectionsNames.RequestQuery)
            .Get<RequestQueryConfig>();

        var odataModelBuilder = new ODataConventionModelBuilder();

        odataModelBuilder.EntityType<BrandDto>();
        odataModelBuilder.EntityType<CategoryDto>();
        odataModelBuilder.EntityType<MechanicDto>();
        odataModelBuilder.EntitySet<BoardGameDto>("edm");

        options.SetMaxTop(querySettings!.MaxTopValue)
            .Filter()
            .OrderBy()
            .Count()
            .AddRouteComponents(RouteConstants.BoardGame, GetEdmModel());
    }

    private static IEdmModel GetEdmModel()
    {
        var odataModelBuilder = new ODataConventionModelBuilder();

        odataModelBuilder.EnableLowerCamelCase();

        odataModelBuilder.EntityType<BrandDto>();
        odataModelBuilder.EntityType<CategoryDto>();
        odataModelBuilder.EntityType<MechanicDto>();
        odataModelBuilder.EntitySet<BoardGameDto>("edm");

        return odataModelBuilder.GetEdmModel();
    }
}