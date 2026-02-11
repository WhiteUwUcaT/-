using System;

namespace DirectoryService.Domain.ValueObjects
{
    public class LocationAddress : IEquatable<LocationAddress>
    {
        public string Value { get; }

        private LocationAddress(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Address cannot be empty", nameof(value));
            }

            if (value.Length > 500)
            {
                throw new ArgumentException("Address cannot exceed 500 characters", nameof(value));
            }

            Value = value.Trim();
        }

        public static LocationAddress Create(string value)
        {
            return new LocationAddress(value);
        }


        public bool Equals(LocationAddress? other)
        {
            if (other is null)
            {
                return false;
            }

            return Value == other.Value;
        }

        public override bool Equals(object? obj)
        {
            return obj is LocationAddress other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode(StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return Value;
        }
        public static LocationAddress FromString(string value) => Create(value);
    }
}