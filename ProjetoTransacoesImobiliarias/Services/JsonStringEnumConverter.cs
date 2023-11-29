using System.Text.Json;
using System.Text.Json.Serialization;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Services;

public class JsonStringEnumConverter : JsonConverter<PropertyType>
{
    public override PropertyType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string value = reader.GetString();

        return value switch
        {
            "Moradia" => PropertyType.House,
            "Apartamento" => PropertyType.Apartment,
            "Terreno" => PropertyType.Land,
            _ => throw new JsonException($"Value '{value}' is not supported for PropertyType.")
        };
    }

    public override void Write(Utf8JsonWriter writer, PropertyType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}