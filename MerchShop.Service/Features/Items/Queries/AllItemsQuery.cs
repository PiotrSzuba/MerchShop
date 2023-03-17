using MerchShop.Persistance;
using MerchShop.Service.BuildingBlocks;
using MerchShop.Service.Services;
using Microsoft.EntityFrameworkCore;

namespace MerchShop.Service.Features.Items.Queries;

public class AllItemsQuery : IQuery<List<ItemDto>>
{
    internal class AllItemsQueryHandler : IQueryHandler<AllItemsQuery, List<ItemDto>>
    {
        private readonly MerchShopContext _context;
        private readonly IPathProvider _pathProvider;
        private readonly IDomainProvider _domainProvider;

        public AllItemsQueryHandler(MerchShopContext context, IPathProvider pathProvider, IDomainProvider domainProvider)
        {
            _context = context;
            _pathProvider = pathProvider;
            _domainProvider = domainProvider;
        }

        public async Task<List<ItemDto>> Handle(AllItemsQuery request, CancellationToken cancellationToken)
        {
            var items = await _context.Items
                .Include(item => item.Types)
                .Include(item => item.Images)
                .Include(item => item.Details)
                    .ThenInclude(itemDetail => itemDetail.Values)
                .ToListAsync(cancellationToken);

            if (items == null || items.Count == 0)
                return new();

            return items.Select(item => ItemDto.Mapper.Map(item, _pathProvider, _domainProvider)).ToList();
        }
    }
}
