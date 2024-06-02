namespace Domain.Common.BaseClasses;

public abstract class Entity<TId> {

    public TId Id { get; set; }

    protected Entity(TId id) {
        Id = id;
    }

    // For EFC serializaiton
    protected Entity() {

    }
    
}