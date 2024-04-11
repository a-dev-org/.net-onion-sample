using Application.Commands.AppointmentType;
using Application.Query.AppointmentType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Onion.Architecture.Api.Endpoints;

public static class AppointmentTypeEndpoints
{
    public static IEndpointRouteBuilder MapAppointmentTypeEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("appointment-type");

        group.MapGet("", async (IMediator mediator) =>
            Results.Json(await mediator.Send(new GetAppointmentTypesQuery())));

        group.MapPost("", async ([FromBody] AddAppointmentTypeCommand command, IMediator mediator) =>
        Results.Json(await mediator.Send(command)));

        group.MapDelete("{id:int}", async ([FromRoute] int id, IMediator mediator) =>
        Results.Json(await mediator.Send(new RemoveAppointmentTypeCommand(id))));

        return builder;
    }
}