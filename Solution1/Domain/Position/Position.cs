using DirectoryService.Domain.Position.ValueObjects; // Изменено здесь
using DirectoryService.Domain.Shared;
using System;

namespace DirectoryService.Domain.Position
{
    public class Position
    {
        public PositionId Id { get; }
        public PositionName Name { get; }
        public PositionAddress Address { get; }
        public PositionTimeZone TimeZone { get; }
        public bool IsActive { get; }
        public EntityLifeTime LifeTime { get; }

        public Position(
            PositionId id,
            PositionName name,
            PositionAddress address,
            PositionTimeZone timeZone,
            bool isActive,
            EntityLifeTime lifeTime)
        {
            Id = id;
            Name = name;
            Address = address;
            TimeZone = timeZone;
            IsActive = isActive;
            LifeTime = lifeTime;
        }

        public static Position Create(PositionName name, PositionAddress address, PositionTimeZone timeZone)
        {
            return new Position(
                id: PositionId.Create(),
                name: name,
                address: address,
                timeZone: timeZone,
                isActive: true,
                lifeTime: EntityLifeTime.Create(DateTime.UtcNow, DateTime.UtcNow, false));
        }

        public static Position Create(Guid id, PositionName name, PositionAddress address, PositionTimeZone timeZone, bool isActive, EntityLifeTime lifeTime)
        {
            return new Position(
                id: PositionId.Create(id),
                name: name,
                address: address,
                timeZone: timeZone,
                isActive: isActive,
                lifeTime: lifeTime);
        }

        private void EnsureNotArchived()
        {
            if (LifeTime.IsArchived)
            {
                throw new InvalidOperationException("Нельзя изменять архивированную позицию.");
            }
        }

        public Position ChangeActivity(bool isActive)
        {
            EnsureNotArchived();
            return new Position(Id, Name, Address, TimeZone, isActive, LifeTime.Update());
        }

        public Position UpdateName(PositionName newName)
        {
            ArgumentNullException.ThrowIfNull(newName);
            EnsureNotArchived();
            return new Position(Id, newName, Address, TimeZone, IsActive, LifeTime.Update());
        }

        public Position UpdateAddress(PositionAddress newAddress)
        {
            ArgumentNullException.ThrowIfNull(newAddress);
            EnsureNotArchived();
            return new Position(Id, Name, newAddress, TimeZone, IsActive, LifeTime.Update());
        }

        public Position UpdateTimeZone(PositionTimeZone newTimeZone)
        {
            ArgumentNullException.ThrowIfNull(newTimeZone);
            EnsureNotArchived();
            return new Position(Id, Name, Address, newTimeZone, IsActive, LifeTime.Update());
        }
    }
}