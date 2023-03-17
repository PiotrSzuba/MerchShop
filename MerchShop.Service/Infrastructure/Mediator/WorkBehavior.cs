using MediatR;
using MerchShop.Persistance;
using MerchShop.Service.BuildingBlocks;

namespace MerchShop.Service.Infrastructure.Mediator;

public class WorkBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
{
    private readonly MerchShopContext _context;

    public WorkBehavior(MerchShopContext context)
    {
        _context = context;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var result = await next();

        if (request is ICommand || request is ICommand<TResponse>)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        return result;
    }
}