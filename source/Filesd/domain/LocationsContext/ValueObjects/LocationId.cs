namespace domain.LocationsContext.ValueObjects
{
    public record LocationId
    {
        public Guid Value { get; }

        private LocationId(Guid value)
        {
            Value = value;
        }

        public static LocationId Create()
        {
            return new LocationId(Guid.NewGuid());
        }

        public static LocationId Create(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("Идентификатор локации не может быть пустым GUID.", nameof(value));

            return new LocationId(value);
        }

        public static LocationId Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Идентификатор локации не может быть пустой строкой.", nameof(value));

            if (!Guid.TryParse(value, out Guid guid))
                throw new ArgumentException("Некорректный формат идентификатора локации.", nameof(value));

            return Create(guid);
        }

        public override string ToString() => Value.ToString();

        public static implicit operator Guid(LocationId id) => id.Value;
        public static implicit operator string(LocationId id) => id?.ToString();
    }
}
