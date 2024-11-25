using Core.Application.Common.Interfaces;

namespace Core.Infrastructure.Services;

public class WorkingDaysService : IWorkingDaysService
{
    public int GetWorkingDaysCount(DateOnly start, DateOnly end)
    {
        int workingDaysCount = 0;
        for (DateOnly date = start; date <= end; date = date.AddDays(1))
        {
            if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
            {
                workingDaysCount++;
            }
        }
        return workingDaysCount;
    }
}
