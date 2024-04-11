using Application.Responses;
using MediatR;

namespace Application.Query.Appointment;

public record GetAppointmentsQuery : IRequest<ResponseDto<AppointmentOverviewDto>>;