using System.Net;
using Application.Interfaces;
using Application.Query.AppointmentType;
using Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.AppointmentType;

public class GetAppointmentTypesQueryHandler(IOnionDbContext onionDbContext)
    : IRequestHandler<GetAppointmentTypesQuery, ResponseDto<AppointmentTypeOverviewDto>>
{
    public async Task<ResponseDto<AppointmentTypeOverviewDto>> Handle(GetAppointmentTypesQuery request, CancellationToken cancellationToken)
    {
        var appointmentTypes = await onionDbContext.AppointmentTypes
            .Select(x => new AppointmentTypeSummaryDto(x.Id, x.Name, x.AppointmentCategoryId))
            .ToListAsync(cancellationToken);

        return new ResponseDto<AppointmentTypeOverviewDto>(new(appointmentTypes), true, HttpStatusCode.OK);
    }
}