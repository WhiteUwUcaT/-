using System;

namespace DirectoryService.Domain.Shared
{
    public sealed record EntityLifeTime
    {
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
        public bool IsArchived { get; } // То самое свойство, которого не хватало

        private EntityLifeTime(DateTime createdAt, DateTime updatedAt, bool isArchived)
        {
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsArchived = isArchived;
        }

        public static EntityLifeTime Create(DateTime createdAt, DateTime updatedAt, bool isArchived)
        {
            return new EntityLifeTime(createdAt, updatedAt, isArchived);
        }

        public EntityLifeTime Update()
        {
            return new EntityLifeTime(CreatedAt, DateTime.UtcNow, IsArchived);
        }

        public EntityLifeTime Archive()
        {
            return new EntityLifeTime(CreatedAt, DateTime.UtcNow, true);
        }
    }
}