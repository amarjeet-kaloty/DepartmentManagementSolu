namespace Domain.Entities
{
    public class Department
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        public Department() : base()
        {
        }

        public Department(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
