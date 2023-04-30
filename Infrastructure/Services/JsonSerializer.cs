using Infrastructure.Services.Interfaces;
using Newtonsoft.Json;

namespace Infrastructure.Services
{
    public class JsonSerializer : IJsonSerializer
    {
        public string Serialize<TModel>(TModel data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public TModel? Deserialize<TModel>(string value)
        {
            return JsonConvert.DeserializeObject<TModel>(value);
        }
    }
}