namespace Domain.Entities;

public class AppointmentCategory
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }
}