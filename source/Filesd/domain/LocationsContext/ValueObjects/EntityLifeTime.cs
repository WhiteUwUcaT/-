using System;
using System.Collections.Generic;
using System.Text;

namespace domain.LocationsContext.ValueObjects
{
    public sealed record EntityLifeTime
    {
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
        public bool IsActivate { get; }

        private EntityLifeTime(DateTime createdAt, DateTime updatetAt, bool isActivate)
        {
            CreatedAt = createdAt;
            UpdatedAt = updatetAt;
            IsActivate = isActivate;
        }

        public static EntityLifeTime Create(DateTime createdAt, DateTime updatetAt, bool isActivate)
        {
            if (createdAt == DateTime.MinValue || createdAt == DateTime.MaxValue)
                throw new ArgumentException("Некорректное значение даты создания.", nameof(createdAt));

            if (updatetAt == DateTime.MinValue || updatetAt == DateTime.MaxValue) 
                throw new ArgumentException("Некорректное значение даты обновления.", nameof (updatetAt));

            if (updatetAt < createdAt)
                throw new ArgumentException("Дата обновления не может быть меньше даты создания.", nameof(createdAt));

            return new EntityLifeTime(createdAt, updatetAt, isActivate);
        }
    }
}
