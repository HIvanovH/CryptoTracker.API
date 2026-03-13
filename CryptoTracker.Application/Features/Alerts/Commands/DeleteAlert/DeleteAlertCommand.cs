using MediatR;

namespace CryptoTracker.Application.Features.Alerts.Commands.DeleteAlert
{
    public record DeleteAlertCommand : IRequest<bool>
    {
        public Guid UserId { get; init; }

        public Guid AlertId { get; init; }
    }
}
