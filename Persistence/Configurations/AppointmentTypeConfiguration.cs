using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class AppointmentTypeConfiguration:IEntityTypeConfiguration<AppointmentType>
{
    public void Configure(EntityTypeBuilder<AppointmentType> builder)
    {
        builder
            .HasOne(x => x.AppointmentCategory)
            .WithMany()
            .HasForeignKey(x => x.AppointmentCategoryId);
    }
}