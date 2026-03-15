using CryptoTracker.Application.Common.Interfaces;
using CryptoTracker.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CryptoTracker.Application.Features.Assets.Queries.GetAssets
{
    public class GetAssetBySymbolQueryHandler : IRequestHandler<GetAssetBySymbolQuery, Asset?>
    {
        private readonly IApplicationDbContext _dbcontext;

        public GetAssetBySymbolQueryHandler(IApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<Asset?> Handle(GetAssetBySymbolQuery request, CancellationToken cancellationToken)
        {
            var asset = await _dbcontext.Assets
                .FirstOrDefaultAsync(a => a.Symbol == request.Symbol, cancellationToken);

            return asset;
        }
    }
}
