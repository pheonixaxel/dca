namespace Domain.Common.BaseClasses;

public abstract class Aggregate<TId> : Entity<TId> where TId : IdBase {

    protected Aggregate(TId id) : base(id) {

    }

    // For EFC
    protected Aggregate(){}
    
}