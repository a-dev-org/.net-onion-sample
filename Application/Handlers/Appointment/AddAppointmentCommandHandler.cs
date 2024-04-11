using System.Net;
using Application.Commands.Appointment;
using Application.Constants;
using Application.Interfaces;
using Application.Responses;
using FluentValidation;
using MediatR;
using ApplicationException = Application.Exceptions.ApplicationException;

namespace Application.Handlers.Appointment;

public class AddAppointmentCommandHandler(IValidator<AddAppointmentCommand> validator, IOnionDbContext onionDbContext)
    : IRequestHandler<AddAppointmentCommand, BaseResponseDto>
{
    public async Task<BaseResponseDto> Handle(AddAppointmentCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAsync(request, cancellationToken);

        _ = await onionDbContext.AppointmentTypes.FindAsync(request.AppointmentTypeId, cancellationToken)
            ?? throw new ApplicationException(string.Format(Errors.GenericNotFound, nameof(AppointmentType)));

        await onionDbContext.Appointments.AddAsync(new Domain.Entities.Appointment
        {
            AppointmentTypeId = request.AppointmentTypeId,
            FullCost = request.FullCost
        }, cancellationToken);

        await onionDbContext.CommitChangesAsync(cancellationToken);

        return new BaseResponseDto(true, HttpStatusCode.OK);
    }
}