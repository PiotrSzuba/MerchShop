using MediatR;

namespace MerchShop.Service.BuildingBlocks;

public interface IQuery<out TResult> : IRequest<TResult>
{
}
