using System.Formats.Asn1;
using System.Globalization;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace GraveyardManager.Utils
{
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        private const string Format = "yyyy-MM-dd";

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            //var a = reader.Read();
            return DateOnly.ParseExact(
                reader.GetString() ?? throw new Exception("TODO"), //TODO
                Format,
                CultureInfo.InvariantCulture
                );
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
        }
    }
}
