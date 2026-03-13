using CryptoTracker.Domain.Enums;
using MediatR;

namespace CryptoTracker.Application.Features.Alerts.Commands.CreateAlert
{
    public record CreateAlertCommand : IRequest<Guid>
    {
        public Guid UserId { get; init; }

        public Guid AssetId { get; init; }

        public decimal TargetPrice { get; init; }

        public AlertDirection Direction { get; init; }
    }
}
