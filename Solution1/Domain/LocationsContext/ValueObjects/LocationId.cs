using System;

namespace DirectoryService.Domain.ValueObjects
{

    public class LocationId : IEquatable<LocationId>
    {
        public Guid Value { get; }

        private LocationId(Guid value)
        {
            Value = value;
        }

        public static LocationId CreateUnique()
        {
            return new LocationId(Guid.NewGuid());
        }

        public static LocationId Create(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentException("LocationId cannot be empty", nameof(value));
            }

            return new LocationId(value);
        }


        public bool Equals(LocationId? other)
        {
            if (other is null)
            {
                return false;
            }

            return Value.Equals(other.Value);
        }

        public override bool Equals(object? obj)
        {
            return obj is LocationId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}