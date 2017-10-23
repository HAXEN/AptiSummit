using System;
using Newtonsoft.Json;

namespace AptiSummit.Api.Commons
{
    public class JsonHalConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            var haveLinks = value as IHaveLinks;
            if (haveLinks != null)
            {
                writer.WritePropertyName("_links");
                writer.WriteStartObject();
                foreach (var link in haveLinks.Links())
                {
                    writer.WritePropertyName(link.Rel);
                    writer.WriteStartObject();
                    writer.WritePropertyName("href");
                    serializer.Serialize(writer, link.Href);
                    writer.WriteEndObject();
                }
                writer.WriteEndObject();
            }

            foreach (var property in value.GetType().GetProperties())
            {
                writer.WritePropertyName(property.Name);
                serializer.Serialize(writer, property.GetValue(value));
            }

            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanRead => false;
        public override bool CanWrite => true;

        public override bool CanConvert(Type objectType)
        {
            return typeof(IHaveLinks).IsAssignableFrom(objectType);
        }
    }
}
