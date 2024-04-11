namespace Domain.Entities;

public class AppointmentType
{
    public int Id { get; set; }

    public virtual AppointmentCategory AppointmentCategory { get; set; }

    public int AppointmentCategoryId { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public byte DurationInMinutes { get; set; }

    public decimal Cost { get; set; }

    public decimal OnlineCost { get; set; }
}