using System.Net;
using Application.Commands.Appointment;
using Application.Constants;
using Application.Interfaces;
using Application.Responses;
using FluentValidation;
using MediatR;
using ApplicationException = Application.Exceptions.ApplicationException;

namespace Application.Handlers.Appointment;

public class RemoveAppointmentCommandHandler(IValidator<RemoveAppointmentCommand> validator, IOnionDbContext onionDbContext)
    : IRequestHandler<RemoveAppointmentCommand, BaseResponseDto>
{
    public async Task<BaseResponseDto> Handle(RemoveAppointmentCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAsync(request, cancellationToken);
        
        var appointment = await onionDbContext.Appointments.FindAsync(request.Id, cancellationToken)
                          ?? throw new ApplicationException(string.Format(Errors.GenericNotFound, nameof(Domain.Entities.Appointment)));

        onionDbContext.Appointments.Remove(appointment);
        await onionDbContext.CommitChangesAsync(cancellationToken);

        return new BaseResponseDto(true, HttpStatusCode.OK);
    }
}