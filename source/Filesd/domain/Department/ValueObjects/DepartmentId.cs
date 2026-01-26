namespace domain.DepartmentsContext.ValueObjects
{
    public record DepartmentId
    {
        public Guid Value {  get; }

        private DepartmentId(Guid value)
        {
            Value = value; 
        }

        public static DepartmentId Create()
        {
            return new DepartmentId(Guid.NewGuid());
        }

        public static DepartmentId Create(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentNullException("Идентификатор подразделения не может быть пустым GUID.", nameof(value));

            return new DepartmentId(value);
        }
        
        public static DepartmentId Create(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Идентификатор подразделения не может быть пустой строкой.", nameof(value));

            if (!Guid.TryParse(value, out Guid guid))
                throw new ArgumentException("Некорректный формат идентификатора подразделения.", nameof(value));

            return new DepartmentId(guid);
        }
        
        public override string ToString() => Value.ToString();

        public static implicit operator Guid(DepartmentId id) => id.Value;
        public static implicit operator string(DepartmentId id) => id?.ToString();
    }
}
