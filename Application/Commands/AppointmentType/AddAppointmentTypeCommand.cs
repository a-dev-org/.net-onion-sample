using Application.Responses;
using FluentValidation;
using MediatR;

namespace Application.Commands.AppointmentType;

public record AddAppointmentTypeCommand(
    string Name,
    string? Description,
    byte DurationInMinutes,
    decimal Cost,
    decimal OnlineCost,
    int AppointmentCategoryId) : IRequest<BaseResponseDto>;

public class AddAppointmentTypeCommandValidator : ApplicationAbstractValidator<AddAppointmentTypeCommand>
{
    public AddAppointmentTypeCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.AppointmentCategoryId).NotNull();
        RuleFor(x => x.Cost).NotNull().GreaterThan(0);

        RuleFor(x => x.OnlineCost).NotNull().GreaterThan(0)
            .Must((model, onlineCost) => onlineCost >= model.Cost);

        RuleFor(x => x.DurationInMinutes).NotNull()
            .GreaterThan((byte)0)
            .LessThanOrEqualTo((byte)30);
    }
}