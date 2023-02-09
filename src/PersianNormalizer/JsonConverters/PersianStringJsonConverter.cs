using System.Text.Json;
using System.Text.Json.Serialization;

using PersianNormalizer.Extensions;

namespace PersianNormalizer.JsonConverters;

public class PersianStringJsonConverter : JsonConverter<string>
{
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString()?.CleanString() ?? string.Empty;
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}