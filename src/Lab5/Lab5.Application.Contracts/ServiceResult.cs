namespace Lab5.Application.Contracts;

public abstract record ServiceResult
{
    private ServiceResult() { }

    public sealed record Success : ServiceResult;

    public sealed record Failed(string Message) : ServiceResult;
}