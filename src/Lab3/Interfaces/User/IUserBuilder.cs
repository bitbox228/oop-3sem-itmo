namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces.User;

public interface IUserBuilder
{
    IUser Build();
}

public interface IUserNameSelector
{
    IUserBuilder WithName(string name);
}