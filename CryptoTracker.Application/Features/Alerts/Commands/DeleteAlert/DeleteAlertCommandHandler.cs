using CryptoTracker.Application.Common.Interfaces;
using CryptoTracker.Application.Features.Alerts.Commands.CreateAlert;
using CryptoTracker.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CryptoTracker.Application.Features.Alerts.Commands.DeleteAlert
{
    public class DeleteAlertCommandHandler : IRequestHandler<DeleteAlertCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteAlertCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteAlertCommand request, CancellationToken cancellationToken)
        {
            var alert = await _context.Alerts.FirstOrDefaultAsync(a => a.UserId == request.UserId && a.Id == request.AlertId);

            if (alert is null)
                return false;

            _context.Alerts.Remove(alert);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}