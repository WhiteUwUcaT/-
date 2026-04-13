using System;

namespace DirectoryService.Domain.Position.ValueObjects
{
    public sealed record PositionId
    {
        public Guid Value { get; }

        private PositionId(Guid value)
        {
            Value = value;
        }

        public static PositionId Create()
        {
            return new PositionId(Guid.NewGuid());
        }

        public static PositionId Create(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentException("Идентификатор позиции не может быть пустым.", nameof(value));
            }

            return new PositionId(value);
        }
    }
}