using System;

namespace DirectoryService.Domain.PositionsContext.ValueObjects
{
    public sealed record PositionAddress
    {
        public const int MaxLength = 500;

        public string Value { get; }

        private PositionAddress(string value) => Value = value;

        public static PositionAddress Create(string value)
        {
            if (value == null)
            {
                return new PositionAddress(string.Empty);
            }

            if (value.Length > MaxLength)
            {
                throw new ArgumentException($"Описание позиции не может превышать {MaxLength} символов.", nameof(value));
            }

            return new PositionAddress(value);
        }

        public static PositionAddress Empty() => new(string.Empty);
    }
}