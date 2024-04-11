using System.Net;
using Application.Commands.AppointmentType;
using Application.Constants;
using Application.Interfaces;
using Application.Responses;
using FluentValidation;
using MediatR;
using ApplicationException = Application.Exceptions.ApplicationException;

namespace Application.Handlers.AppointmentType;

public class AddAppointmentTypeCommandHandler(IValidator<AddAppointmentTypeCommand> validator, IOnionDbContext onionDbContext)
    : IRequestHandler<AddAppointmentTypeCommand, BaseResponseDto>
{
    public async Task<BaseResponseDto> Handle(AddAppointmentTypeCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAsync(request, cancellationToken);

        _ = await onionDbContext.AppointmentCategories.FindAsync(request.AppointmentCategoryId, cancellationToken)
            ?? throw new ApplicationException(string.Format(Errors.GenericNotFound, nameof(AppointmentCategory)));

        await onionDbContext.AppointmentTypes.AddAsync(new Domain.Entities.AppointmentType
        {
            Name = request.Name,
            AppointmentCategoryId = request.AppointmentCategoryId,
            Cost = request.Cost,
            Description = request.Description,
            OnlineCost = request.OnlineCost,
            DurationInMinutes = request.DurationInMinutes
        }, cancellationToken);

        await onionDbContext.CommitChangesAsync(cancellationToken);

        return new BaseResponseDto(true, HttpStatusCode.Created);
    }
}