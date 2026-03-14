using CryptoTracker.Application.Common.Interfaces;
using CryptoTracker.Domain.Entities;
using CryptoTracker.Domain.Enums;
using MediatR;

namespace CryptoTracker.Application.Features.Alerts.Commands.CreateAlert
{
    public class CreateAlertCommandHandler : IRequestHandler<CreateAlertCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateAlertCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateAlertCommand request, CancellationToken cancellationToken)
        {
            Alert alert = new Alert()
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                AssetId = request.AssetId,
                TargetPrice = request.TargetPrice,
                Direction = request.Direction,
                Status = AlertStatus.Active,
                CreatedAt = DateTime.UtcNow
            };

            _context.Alerts.Add(alert);

            await _context.SaveChangesAsync(cancellationToken);

            return alert.Id;
        }
    }
}
