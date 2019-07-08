using System;
using UnityEngine;
using Newtonsoft.Json.Linq;

//This type has an issues with serialization, because normalized/magnitude are properties
//These properties return a new instance of the class, so during serialization
//They cause an endless loop
//This serializes only the x/y values skipping those properties
namespace Newtonsoft.Json.Unity
{
    public class JsonVector2Converter : JsonConverter<Vector2>
    {
        public override void WriteJson(JsonWriter writer, Vector2 value, JsonSerializer serializer)
        {
            JObject j = new JObject {{"x", value.x}, {"y", value.y}};

            j.WriteTo(writer);
        }

        //CanRead is false which means the default implementation will be used instead.
        public override Vector2 ReadJson(JsonReader reader, Type objectType, Vector2 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return existingValue;
        }

        public override bool CanWrite => true;

        public override bool CanRead => false;
    }
}