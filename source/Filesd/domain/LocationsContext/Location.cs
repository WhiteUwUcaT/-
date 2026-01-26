using domain.LocationsContext.ValueObjects;
namespace domain.LocationsContext
{

    public class Location
    {
        public Location(
            LocationId id,
            LocationAddress address,
            LocationName name,
            IanaTimeZone timeZone,
            EntityLifeTime lifeTime
        )
        {
            Id = id;
            Address = address;
            Name = name;
            TimeZone = timeZone;
            LifeTime = lifeTime;
        }

        public LocationId Id { get; }
        public LocationName Name { get; }
        public LocationAddress Address { get; }
        public EntityLifeTime LifeTime { get; }
        public IanaTimeZone TimeZone { get; }
    }
}
