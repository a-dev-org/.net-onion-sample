using Application.Commands.Appointment;
using Application.Query.Appointment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Onion.Architecture.Api.Endpoints;

public static class AppointmentEndpoints
{
    public static IEndpointRouteBuilder MapAppointmentEndpoints(this IEndpointRouteBuilder builder)
    {
        var route = builder.MapGroup("appointment");

        route.MapGet("", async (IMediator mediator) =>
            Results.Json(await mediator.Send(new GetAppointmentsQuery())));

        route.MapPost("", async ([FromBody] AddAppointmentCommand command, IMediator mediator) =>
        Results.Json(await mediator.Send(command)));

        route.MapDelete("{id:int}", async ([FromRoute] int id, IMediator mediator) =>
        Results.Json(await mediator.Send(new RemoveAppointmentCommand(id))));

        return builder;
    }
}