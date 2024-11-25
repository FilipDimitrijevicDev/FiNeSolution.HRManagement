namespace Core.Application.Common.Interfaces;

public interface IWorkingDaysService
{
    int GetWorkingDaysCount(DateOnly start, DateOnly end);
}
