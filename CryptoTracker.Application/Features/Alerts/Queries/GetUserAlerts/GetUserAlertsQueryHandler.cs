using CryptoTracker.Application.Common.Interfaces;
using CryptoTracker.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CryptoTracker.Application.Features.Alerts.Queries.GetUserAlerts
{
    public class GetUserAlertsQueryHandler : IRequestHandler<GetUserAlertsQuery, List<Alert>>
    {
        private readonly IApplicationDbContext _context;

        public GetUserAlertsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Alert>> Handle(GetUserAlertsQuery request, CancellationToken cancellationToken)
        {
            List<Alert> alerts = await _context.Alerts
                .Where(a => a.UserId == request.UserId)
                .ToListAsync(cancellationToken);

            return alerts;
        }
    }
}
