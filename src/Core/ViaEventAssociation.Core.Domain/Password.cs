using ViaEventAssociation.Core.Tools.OperationResult;

namespace Domain;

public class Password
{
    public string Value { get; }

    private Password(string value)
    {
        Value = value;
    }

    public static Result<Password> Create(string input)
    {
        Password password = new Password(input);
        return Result<Password>.Success(password);
    }
}