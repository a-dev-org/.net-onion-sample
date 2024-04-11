using System.Net;
using Application.Interfaces;
using Application.Query.AppointmentCategory;
using Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.AppointmentCategory;

public class GetAppointmentCategoriesQueryHandler(IOnionDbContext onionDbContext)
    : IRequestHandler<GetAppointmentCategoriesQuery, ResponseDto<AppointmentCategoryOverviewDto>>
{
    public async Task<ResponseDto<AppointmentCategoryOverviewDto>> Handle(GetAppointmentCategoriesQuery request, CancellationToken cancellationToken)
    {
        var appointmentCategories = await onionDbContext.AppointmentCategories
            .Select(x => new AppointmentCategorySummaryDto(x.Id, x.Name)).ToListAsync(cancellationToken);

        return new ResponseDto<AppointmentCategoryOverviewDto>(new(appointmentCategories), true, HttpStatusCode.OK);
    }
}