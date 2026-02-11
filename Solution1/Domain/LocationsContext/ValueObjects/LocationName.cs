using System;

namespace DirectoryService.Domain.ValueObjects
{
    public class LocationName : IEquatable<LocationName>
    {
        public string Value { get; }

        private LocationName(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Location name cannot be empty", nameof(value));
            }

            if (value.Length > 200)
            {
                throw new ArgumentException("Location name cannot exceed 200 characters", nameof(value));
            }

            Value = value.Trim();
        }

        public static LocationName Create(string value)
        {
            return new LocationName(value);
        }

        public bool Equals(LocationName? other)
        {
            if (other is null)
            {
                return false;
            }

            return Value == other.Value;
        }

        public override bool Equals(object? obj)
        {
            return obj is LocationName other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode(StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return Value;
        }

        // Альтернатива оператору неявного преобразования
        public static LocationName FromString(string value) => Create(value);
    }
}