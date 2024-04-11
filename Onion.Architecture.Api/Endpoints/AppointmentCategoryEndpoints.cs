using Application.Commands.AppointmentCategory;
using Application.Query.AppointmentCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Onion.Architecture.Api.Endpoints;

public static class AppointmentCategoryEndpoints
{
    public static IEndpointRouteBuilder MapAppointmentCategoryEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("appointment-category");

        group.MapGet("", async (IMediator mediator) =>
            Results.Json(await mediator.Send(new GetAppointmentCategoriesQuery())));

        group.MapPost("", async ([FromBody] AddAppointmentCategoryCommand command, IMediator mediator) =>
        Results.Json(await mediator.Send(command)));

        group.MapDelete("{id:int}", async ([FromRoute] int id, IMediator mediator) =>
        Results.Json(await mediator.Send(new RemoveAppointmentCategoryCommand(id))));

        return builder;
    }
}