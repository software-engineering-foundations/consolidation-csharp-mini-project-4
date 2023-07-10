using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace consolidation_csharp_mini_project_3.Models
{
    public class DateJsonConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(
                "MM/dd/yyyy", CultureInfo.InvariantCulture));
        }

        public override void WriteAsPropertyName(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            base.WriteAsPropertyName(writer, value, options);
        }
    }
}