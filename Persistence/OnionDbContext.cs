using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class OnionDbContext(DbContextOptions<OnionDbContext> option) : DbContext(option), IOnionDbContext
{
    public DbSet<AppointmentType> AppointmentTypes { get; set; } = null!;

    public DbSet<AppointmentCategory> AppointmentCategories { get; set; } = null!;

    public DbSet<Appointment> Appointments { get; set; } = null!;

    public async Task<int> CommitChangesAsync(CancellationToken cancellationToken) =>
        await base.SaveChangesAsync(cancellationToken);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OnionDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}