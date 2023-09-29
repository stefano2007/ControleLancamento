using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleLancamento.Infra.Data.EntitiesConfiguration.Converters;

public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter() : base(
        dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
        dateTime => DateOnly.FromDateTime(dateTime))
    { }
}
