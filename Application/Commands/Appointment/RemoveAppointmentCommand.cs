using Application.Responses;
using FluentValidation;
using MediatR;

namespace Application.Commands.Appointment;

public record RemoveAppointmentCommand(int Id) : IRequest<BaseResponseDto>;

public class RemoveAppointmentCommandValidator : ApplicationAbstractValidator<RemoveAppointmentCommand>
{
    public RemoveAppointmentCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan(0);
    }
}