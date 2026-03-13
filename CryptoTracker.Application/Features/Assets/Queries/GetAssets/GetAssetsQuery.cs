using CryptoTracker.Domain.Entities;
using MediatR;

namespace CryptoTracker.Application.Features.Assets.Queries.GetAssets
{
    public record GetAssetsQuery : IRequest<List<Asset>>
    {
    }
}
