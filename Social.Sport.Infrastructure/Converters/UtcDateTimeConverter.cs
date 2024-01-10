using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace Social.Sport.Infrastructure.Converters
{
    internal static class UtcDateTimeConverter
    {
        public static void ApplyUtcdateConverter(this ModelBuilder builder)
        {
            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                datetime => datetime.ToUniversalTime(),
                datetime => DateTime.SpecifyKind(datetime, DateTimeKind.Utc));
            var nullableDateTimeConverter = new ValueConverter<DateTime?, DateTime?>(
                datetime => datetime.HasValue ? datetime.Value.ToUniversalTime() : datetime,
                datetime => datetime.HasValue ? DateTime.SpecifyKind(datetime.Value, DateTimeKind.Utc) : datetime);
            foreach (var entitytype in builder.Model.GetEntityTypes())
            {
                if (entitytype.IsKeyless)
                {
                    continue;
                }
                foreach(var property in entitytype.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime))
                    {
                        property.SetValueConverter(dateTimeConverter);
                        continue;
                    }
                    if (property.ClrType == typeof(DateTime?))
                    {
                        property.SetValueConverter(nullableDateTimeConverter);
                    }
                }
                
            }
        }
    }
}
