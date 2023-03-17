using MediatR;
using MerchShop.Service.Features.Items.Commands;
using MerchShop.Service.Features.Items.Queries;

namespace MerchShop.Api.Controllers;

public static class ItemController
{
    public static void AddItemController(this WebApplication app)
    {
        app.MapGet("/api/items", async (IMediator mediator) => 
            await mediator.Send(new AllItemsQuery()));

        app.MapPost("/api/items", async (IMediator mediator, CreateItemCommand command) =>
            await mediator.Send(command));
    }
}
