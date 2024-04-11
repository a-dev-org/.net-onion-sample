namespace Domain.Entities;

public class Appointment
{
    public int Id { get; set; }

    public virtual AppointmentType AppointmentType { get; set; }

    public int AppointmentTypeId { get; set; }

    public decimal FullCost { get; set; }
}