using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IOnionDbContext
{
    DbSet<AppointmentType> AppointmentTypes { get; set; }

    DbSet<AppointmentCategory> AppointmentCategories { get; set; }

    DbSet<Appointment> Appointments { get; set; }
    
    Task<int> CommitChangesAsync(CancellationToken cancellationToken);
}