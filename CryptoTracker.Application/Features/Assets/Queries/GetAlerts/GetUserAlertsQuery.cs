using CryptoTracker.Domain.Entities;
using MediatR;

namespace CryptoTracker.Application.Features.Assets.Queries.GetAssets
{
    public record GetUserAlertsQuery : IRequest<List<Alert>>
    {
        public Guid UserId { get; init; }
    }
}
