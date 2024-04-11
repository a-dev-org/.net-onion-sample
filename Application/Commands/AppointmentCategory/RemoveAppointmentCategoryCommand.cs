using Application.Responses;
using FluentValidation;
using MediatR;

namespace Application.Commands.AppointmentCategory;

public record RemoveAppointmentCategoryCommand(int Id) : IRequest<BaseResponseDto>;

public class RemoveAppointmentCategoryCommandValidator : ApplicationAbstractValidator<RemoveAppointmentCategoryCommand>
{
    public RemoveAppointmentCategoryCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan(0);
    }
}