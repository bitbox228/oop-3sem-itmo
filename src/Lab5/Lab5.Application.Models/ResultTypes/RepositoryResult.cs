namespace Lab5.Application.Models.ResultTypes;

public abstract record RepositoryResult
{
    private RepositoryResult() { }

    public sealed record Success : RepositoryResult;

    public sealed record Failed(string Message) : RepositoryResult;
}