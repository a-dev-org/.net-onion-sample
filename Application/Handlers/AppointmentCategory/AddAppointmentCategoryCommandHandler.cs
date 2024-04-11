using System.Net;
using Application.Commands.AppointmentCategory;
using Application.Interfaces;
using Application.Responses;
using FluentValidation;
using MediatR;

namespace Application.Handlers.AppointmentCategory;

public class AddAppointmentCategoryCommandHandler(IOnionDbContext onionDbContext, IValidator<AddAppointmentCategoryCommand> validator) : IRequestHandler<AddAppointmentCategoryCommand, BaseResponseDto>
{
    public async Task<BaseResponseDto> Handle(AddAppointmentCategoryCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAsync(request, cancellationToken);
        await onionDbContext.AppointmentCategories.AddAsync(new Domain.Entities.AppointmentCategory
        {
            Name = request.Name,
            Description = request.Description
        }, cancellationToken);
        await onionDbContext.CommitChangesAsync(cancellationToken);

        return new BaseResponseDto(true, HttpStatusCode.Created);
    }
}