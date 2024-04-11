using Application.Responses;
using MediatR;

namespace Application.Query.AppointmentType;

public record GetAppointmentTypesQuery : IRequest<ResponseDto<AppointmentTypeOverviewDto>>;