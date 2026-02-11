using System;
using DirectoryService.Domain.ValueObjects;

namespace DirectoryService.Domain.Entities
{

    public class Location
    {
        public LocationId Id { get; private set; } = null!;

        public LocationName Name { get; private set; } = null!;
        public IanaTimeZone TimeZone { get; private set; } = null!;
        public LocationAddress Address { get; private set; } = null!;
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool IsArchived { get; private set; }

        private Location() { }

        private Location(
            LocationId id,
            LocationName name,
            IanaTimeZone timeZone,
            LocationAddress address)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            TimeZone = timeZone ?? throw new ArgumentNullException(nameof(timeZone));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            IsArchived = false;
        }

        public static Location Create(
            string name,
            string ianaTimeZone,
            string address)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name is required", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(ianaTimeZone))
            {
                throw new ArgumentException("Time zone is required", nameof(ianaTimeZone));
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException("Address is required", nameof(address));
            }

            return new Location(
                LocationId.CreateUnique(),
                LocationName.Create(name),
                IanaTimeZone.Create(ianaTimeZone),
                LocationAddress.Create(address));
        }

        public void UpdateInfo(
            string? name = null,
            string? ianaTimeZone = null,
            string? address = null)
        {
            if (IsArchived)
            {
                throw new InvalidOperationException("cannot change archive location");
            }

            bool updated = false;

            if (!string.IsNullOrWhiteSpace(name))
            {
                Name = LocationName.Create(name);
                updated = true;
            }

            if (!string.IsNullOrWhiteSpace(ianaTimeZone))
            {
                TimeZone = IanaTimeZone.Create(ianaTimeZone);
                updated = true;
            }

            if (!string.IsNullOrWhiteSpace(address))
            {
                Address = LocationAddress.Create(address);
                updated = true;
            }

            if (updated)
            {
                UpdatedAt = DateTime.UtcNow;
            }
        }

        public void Archive()
        {
            if (IsArchived)
            {
                return;
            }

            IsArchived = true;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Restore()
        {
            if (!IsArchived)
            {
                return;
            }

            IsArchived = false;
            UpdatedAt = DateTime.UtcNow;
        }

        public static Location FromPersistence(
            Guid id,
            string name,
            string ianaTimeZone,
            string address,
            DateTime createdAt,
            DateTime updatedAt,
            bool isArchived)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Id is required", nameof(id));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name is required", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(ianaTimeZone))
            {
                throw new ArgumentException("Time zone is required", nameof(ianaTimeZone));
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException("Address is required", nameof(address));
            }

            Location location = new Location
            {
                Id = LocationId.Create(id),
                Name = LocationName.Create(name),
                TimeZone = IanaTimeZone.Create(ianaTimeZone),
                Address = LocationAddress.Create(address),
                CreatedAt = createdAt,
                UpdatedAt = updatedAt,
                IsArchived = isArchived
            };

            return location;
        }
    }
}