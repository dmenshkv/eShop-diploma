using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Models.Constants
{
    [ExcludeFromCodeCoverage]
    public static class ODataQueryConstants
    {
        public const string GroupStartSymbol = "(";

        public const string GroupEndSymbol = ")";

        public const string FilterByName = "{0}/name eq '{1}'";

        public const string CollectionFilterStart = "{0}/any({1}: ";

        public static Dictionary<string, string> CategoryFilters = new Dictionary<string, string>()
        {
            { "Category", "Categories" },
            { "Mechanic", "Mechanics" },
            { "Brand", "Brand" }
        };
    }
}