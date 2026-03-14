using CryptoTracker.Domain.Entities;
using MediatR;

namespace CryptoTracker.Application.Features.Alerts.Queries.GetUserAlerts
{
    public record GetUserAlertsQuery : IRequest<List<Alert>>
    {
        public Guid UserId { get; init; }
    }
}
