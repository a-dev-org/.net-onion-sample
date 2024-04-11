using System.Net;
using Application.Commands.AppointmentCategory;
using Application.Constants;
using Application.Interfaces;
using Application.Responses;
using FluentValidation;
using MediatR;
using ApplicationException = Application.Exceptions.ApplicationException;

namespace Application.Handlers.AppointmentCategory;

public class RemoveAppointmentCategoryCommandHandler(IValidator<RemoveAppointmentCategoryCommand> validator, IOnionDbContext onionDbContext)
    : IRequestHandler<RemoveAppointmentCategoryCommand, BaseResponseDto>
{
    public async Task<BaseResponseDto> Handle(RemoveAppointmentCategoryCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAsync(request, cancellationToken);
        var entity = await onionDbContext.AppointmentCategories.FindAsync(request.Id, cancellationToken)
                     ?? throw new ApplicationException(string.Format(Errors.GenericNotFound, nameof(AppointmentCategory)));

        onionDbContext.AppointmentCategories.Remove(entity);
        await onionDbContext.CommitChangesAsync(cancellationToken);

        return new BaseResponseDto(true, HttpStatusCode.OK);
    }
}