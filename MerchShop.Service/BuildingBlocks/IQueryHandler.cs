using MediatR;

namespace MerchShop.Service.BuildingBlocks;

public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}