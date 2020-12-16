using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating.Infrastureture
{
    public class SerializePolicyFile : IDeserializer
    {
        public Policy DeSerializePolicy(string policyJson)
        {
            return JsonConvert.DeserializeObject<Policy>(policyJson,
                  new StringEnumConverter());
        }
    }
}
