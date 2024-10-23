namespace Core.Application.Common.Models;

public abstract class CommandResultBase
{
    public string Message { get; set; }

    protected CommandResultBase(string message)
    {
        Message = message;
    }
}
