using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Framework
{
    public class ObjectIdJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(ObjectId).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            //serializer.Deserialize(reader, objectType);
            //throw new NotImplementedException();
            return ObjectId.Parse(existingValue.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());
        }
    }
}