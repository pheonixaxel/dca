using ViaEventAssociation.Core.Tools.OperationResult;

namespace Domain.Common.BaseClasses;

public class IdBase: ValueObject
{
    protected IdBase(string prefix) {
        Value = prefix + Guid.NewGuid();
    }

    private string Value { get; }

    protected override IEnumerable<object> GetEqualityComponents() {
        yield return Value;
    }

    public override string ToString() => Value;
}