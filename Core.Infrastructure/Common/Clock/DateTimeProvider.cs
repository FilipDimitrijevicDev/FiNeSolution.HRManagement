using Core.Application.Common.Clock;

namespace Core.Infrastructure.Common.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
