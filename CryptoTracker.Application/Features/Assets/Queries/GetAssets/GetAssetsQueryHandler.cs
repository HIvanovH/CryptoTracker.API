using CryptoTracker.Application.Common.Interfaces;
using CryptoTracker.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CryptoTracker.Application.Features.Assets.Queries.GetAssets
{
    public class GetAssetsQueryHandler : IRequestHandler<GetAssetsQuery, List<Asset>>
    {
        private readonly IApplicationDbContext _dbcontext;

        public GetAssetsQueryHandler(IApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<List<Asset>> Handle(GetAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _dbcontext.Assets.ToListAsync();
        }
    }
}
