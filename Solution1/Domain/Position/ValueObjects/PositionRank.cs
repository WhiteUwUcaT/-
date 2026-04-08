using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryService.Domain.Position.ValueObjects
{
    public sealed record PositionRank
    {
        public int Value { get; }
        private PositionRank(int value) => Value = value;

        public static PositionRank Create(int value)
        {
            if (value <= 0) throw new ArgumentException("Ранг должен быть положительным числом.");
            return new PositionRank(value);
        }
    }
}
