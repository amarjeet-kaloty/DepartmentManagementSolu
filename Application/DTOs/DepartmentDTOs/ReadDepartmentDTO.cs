namespace Application.DTOs.DepartmentDTOs
{
    public class ReadDepartmentDTO
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
