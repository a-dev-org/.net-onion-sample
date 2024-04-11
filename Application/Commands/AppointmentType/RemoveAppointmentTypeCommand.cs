using Application.Responses;
using FluentValidation;
using MediatR;

namespace Application.Commands.AppointmentType;

public record RemoveAppointmentTypeCommand(int Id) : IRequest<BaseResponseDto>;

public class RemoveAppointmentTypeCommandValidator : ApplicationAbstractValidator<RemoveAppointmentTypeCommand>
{
    public RemoveAppointmentTypeCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan(0);
    }
}