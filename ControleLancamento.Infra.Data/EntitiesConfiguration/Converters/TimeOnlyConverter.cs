using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleLancamento.Infra.Data.EntitiesConfiguration.Converters;

public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
{
    public TimeOnlyConverter() : base(
        timeOnly => timeOnly.ToTimeSpan(),
        timeSpan => TimeOnly.FromTimeSpan(timeSpan))
    { }
}
