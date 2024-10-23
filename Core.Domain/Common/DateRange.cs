namespace Core.Domain.Common;
using Microsoft.EntityFrameworkCore;

[Owned]
public record DateRange
{
    private DateRange()
    {
    }

    public DateOnly Start { get; init; }

    public DateOnly End { get; init; }

    public int LengthInDays => End.DayNumber - Start.DayNumber;

    public static DateRange Create(DateOnly start, DateOnly end)
    {
        if (start > end)
        {
            throw new ApplicationException("End date precedes start date");
        }

        if (start < DateOnly.FromDateTime(DateTime.UtcNow))
        {
            throw new ApplicationException("Start date cannot be in the past");
        }

        return new DateRange
        {
            Start = start,
            End = end
        };
    }
}