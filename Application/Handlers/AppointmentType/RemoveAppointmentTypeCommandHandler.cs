using System.Net;
using Application.Commands.AppointmentType;
using Application.Constants;
using Application.Interfaces;
using Application.Responses;
using FluentValidation;
using MediatR;
using ApplicationException = Application.Exceptions.ApplicationException;

namespace Application.Handlers.AppointmentType;

public class RemoveAppointmentTypeCommandHandler(IValidator<RemoveAppointmentTypeCommand> validator, IOnionDbContext onionDbContext)
    : IRequestHandler<RemoveAppointmentTypeCommand, BaseResponseDto>
{
    public async Task<BaseResponseDto> Handle(RemoveAppointmentTypeCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAsync(request, cancellationToken);

        var appointmentType = await onionDbContext.AppointmentTypes.FindAsync(request.Id, cancellationToken)
                              ?? throw new ApplicationException(string.Format(Errors.GenericNotFound, nameof(AppointmentType)));

        onionDbContext.AppointmentTypes.Remove(appointmentType);
        await onionDbContext.CommitChangesAsync(cancellationToken);

        return new BaseResponseDto(true, HttpStatusCode.OK);
    }
}