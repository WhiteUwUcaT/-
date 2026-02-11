using System;

namespace DirectoryService.Domain.ValueObjects
{
    public class IanaTimeZone : IEquatable<IanaTimeZone>
    {
        public string Value { get; }

        private IanaTimeZone(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("IANA time zone cannot be empty", nameof(value));
            }

            if (value.Length > 100)
            {
                throw new ArgumentException("IANA time zone cannot exceed 100 characters", nameof(value));
            }

            Value = value.Trim();
        }

        public static IanaTimeZone Create(string value)
        {
            return new IanaTimeZone(value);
        }


        public bool Equals(IanaTimeZone? other)
        {
            if (other is null)
            {
                return false;
            }

            return Value == other.Value;
        }

        public override bool Equals(object? obj)
        {
            return obj is IanaTimeZone other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode(StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return Value;
        }

        public static IanaTimeZone FromString(string value) => Create(value);
    }
}