namespace domain.LocationsContext.ValueObjects
{
    public record IanaTimeZone
    {
        private static readonly HashSet<string> ValidTimeZones = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "Europe/Moscow",
            "America/New_York",
            "Europe/London",
            "Asia/Tokyo"
        };

        public string Value { get; }

        private IanaTimeZone(string value)
        {
            Value = value;
        }

        public static IanaTimeZone Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Идентификатор часового пояса не может быть пустым.", nameof(value));

            if (!IsValidIanaTimeZone(value))
                throw new ArgumentException($"'{value}' не является допустимым идентификатором IANA часового пояса.", nameof(value));

            return new IanaTimeZone(value);
        }

        private static bool IsValidIanaTimeZone(string timeZoneId)
        {
            if (!timeZoneId.Contains("/") || timeZoneId.StartsWith("/") || timeZoneId.EndsWith("/"))
                return false;

            return ValidTimeZones.Contains(timeZoneId);
        }

        public override string ToString() => Value;

        public static implicit operator string(IanaTimeZone timeZone) => timeZone?.Value;
    }
}
