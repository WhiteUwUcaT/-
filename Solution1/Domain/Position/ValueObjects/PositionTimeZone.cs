using System;

namespace DirectoryService.Domain.PositionsContext.ValueObjects
{
    public sealed record PositionTimeZone
    {
        public const int MaxLength = 100;
        public string Value { get; }
        private PositionTimeZone(string value) => Value = value;

        public static PositionTimeZone Create(string value)
        {
            if (value == null)
            {
                return new PositionTimeZone(string.Empty);
            }

            if (value.Length > MaxLength)
            {
                throw new ArgumentException($"Часовой пояс локации не может превышать {MaxLength} символов", nameof(value));
            }

            return new PositionTimeZone(value.Trim());
        }

        public static PositionTimeZone Empty() => new(string.Empty);
    }
}