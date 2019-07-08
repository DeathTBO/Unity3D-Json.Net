using System;
using UnityEngine;
using Newtonsoft.Json.Linq;

//This type has an issues with serialization, because normalized/magnitude are properties
//These properties return a new instance of the class, so during serialization
//They cause an endless loop
//This serializes only the x/y/z/w values skipping those properties
namespace Newtonsoft.Json.Unity
{
    public class JsonVector4Converter : JsonConverter<Vector4>
    {
        public override void WriteJson(JsonWriter writer, Vector4 value, JsonSerializer serializer)
        {
            JObject j = new JObject {{"x", value.x}, {"y", value.y}, {"z", value.z}, {"w", value.w}};

            j.WriteTo(writer);
        }

        //CanRead is false which means the default implementation will be used instead.
        public override Vector4 ReadJson(JsonReader reader, Type objectType, Vector4 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return existingValue;
        }

        public override bool CanWrite => true;

        public override bool CanRead => false;
    }
}