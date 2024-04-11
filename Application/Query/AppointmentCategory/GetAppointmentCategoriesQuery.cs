using Application.Responses;
using MediatR;

namespace Application.Query.AppointmentCategory;

public record GetAppointmentCategoriesQuery : IRequest<ResponseDto<AppointmentCategoryOverviewDto>>;