using Application.Responses;
using FluentValidation;
using MediatR;

namespace Application.Commands.Appointment;

public record AddAppointmentCommand(int AppointmentTypeId, decimal FullCost) : IRequest<BaseResponseDto>;

public class AddAppointmentCommandValidator : ApplicationAbstractValidator<AddAppointmentCommand>
{
    public AddAppointmentCommandValidator()
    {
        RuleFor(x => x.AppointmentTypeId).NotNull().GreaterThan(0);
        RuleFor(x => x.FullCost).NotNull().GreaterThan(0);
    }
}