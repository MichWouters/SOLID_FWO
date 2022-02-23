using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ArdalisRating.Serialization
{
    public class JsonPolicySerializer
    {
        public Policy GetPolicyFromJsonString(string policyJson)
        {
            return JsonConvert.DeserializeObject<Policy>(policyJson,
                new StringEnumConverter());
        }
    }
}