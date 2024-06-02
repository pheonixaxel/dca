﻿namespace Domain.Common.BaseClasses;

public abstract class ValueObject
{
    // Value objects are objects that are defined by their attributes, not by their identity.
    public override bool Equals(object? obj) {
        if (obj == null || obj.GetType() != GetType())
            return false;

        var other = (ValueObject) obj;
        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    // Compare the value objects.
    protected abstract IEnumerable<object> GetEqualityComponents();

    public override int GetHashCode() {
        return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }


    // Overriding the equality operators to compare value objects
    public static bool operator ==(ValueObject a, ValueObject b) {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;
        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;
        return a.Equals(b);
    }

    // Overriding the inequality operators to compare value objects
    public static bool operator !=(ValueObject a, ValueObject b) {
        return !(a == b);
    }

    // Overriding the ToString method to return the value object as a string
    public override string ToString() {
        return string.Join(", ", GetEqualityComponents());
    }
}