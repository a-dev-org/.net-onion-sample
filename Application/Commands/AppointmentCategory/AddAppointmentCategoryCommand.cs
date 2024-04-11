using Application.Responses;
using FluentValidation;
using MediatR;

namespace Application.Commands.AppointmentCategory;

public record AddAppointmentCategoryCommand(string Name, string? Description) : IRequest<BaseResponseDto>;

public class AddAppointmentCategoryCommandValidator : ApplicationAbstractValidator<AddAppointmentCategoryCommand>
{
    public AddAppointmentCategoryCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}