using System.Net;
using Application.Interfaces;
using Application.Query.Appointment;
using Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Appointment;

public class GetAppointmentsQueryHandler(IOnionDbContext onionDbContext)
    : IRequestHandler<GetAppointmentsQuery, ResponseDto<AppointmentOverviewDto>>
{
    public async Task<ResponseDto<AppointmentOverviewDto>> Handle(GetAppointmentsQuery request, CancellationToken cancellationToken)
    {
        var appointments = await onionDbContext.Appointments
            .Select(x => new AppointmentSummaryDto(x.Id, x.AppointmentTypeId, x.FullCost))
            .ToListAsync(cancellationToken);

        return new ResponseDto<AppointmentOverviewDto>(new(appointments), true, HttpStatusCode.OK);
    }
}