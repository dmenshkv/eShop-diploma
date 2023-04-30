using System.Diagnostics.CodeAnalysis;
using Catalog.API.Constants;
using Catalog.Models.Configurations;
using Catalog.Models.DTOs;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace Catalog.API.Extensions
{
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
                .Expand()
                .AddRouteComponents("board-games", GetEdmModel());
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
}
