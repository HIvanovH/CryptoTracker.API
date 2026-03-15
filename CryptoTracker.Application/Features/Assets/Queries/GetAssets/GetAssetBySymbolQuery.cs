using CryptoTracker.Domain.Entities;
using MediatR;

namespace CryptoTracker.Application.Features.Assets.Queries.GetAssets
{
    public record GetAssetBySymbolQuery : IRequest<Asset?>
    {
        public required string Symbol { get; init; }
    }
}
