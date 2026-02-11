using DirectoryService.Domain.PositionsContext.ValueObjects;
using DirectoryService.Domain.Shared;
using System;

namespace DirectoryService.Domain.PositionsContext
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
                lifeTime: EntityLifeTime.Create(DateTime.UtcNow, DateTime.UtcNow, false)); // Добавлены параметры
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

        public Position ChangeActivity(bool isActive)
        {
            return new Position(Id, Name, Address, TimeZone, isActive, LifeTime.Update());
        }

        public Position UpdateName(PositionName newName)
        {
            ArgumentNullException.ThrowIfNull(newName); 

            return new Position(Id, newName, Address, TimeZone, IsActive, LifeTime.Update());
        }

        public Position UpdateAddress(PositionAddress newAddress)
        {
            ArgumentNullException.ThrowIfNull(newAddress); 

            return new Position(Id, Name, newAddress, TimeZone, IsActive, LifeTime.Update());
        }

        public Position UpdateTimeZone(PositionTimeZone newTimeZone)
        {
            ArgumentNullException.ThrowIfNull(newTimeZone); 

            return new Position(Id, Name, Address, newTimeZone, IsActive, LifeTime.Update());
        }

        // Метод для обновления описания (если нужно)
        public Position UpdateDescription(PositionAddress newDescription)
        {
            ArgumentNullException.ThrowIfNull(newDescription);

            return new Position(Id, Name, newDescription, TimeZone, IsActive, LifeTime.Update());
        }
    }
}