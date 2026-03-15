using CryptoTracker.Application.Features.Alerts.Commands.CreateAlert;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CryptoTracker.Application.Features.Alerts.Queries.GetUserAlerts;

namespace CryptoTracker.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AlertsController : ControllerBase
    {
        private readonly ISender _sender;

        public AlertsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlert([FromBody] CreateAlertCommand command)
        {
            Guid alertId = await _sender.Send(command);

            return CreatedAtAction(nameof(GetUserAlerts), 
                new { userId = command.UserId },
                new { id = alertId }
                );
        }

        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> GetUserAlerts(Guid userId)
        {
            var alerts = await _sender.Send(new GetUserAlertsQuery { UserId = userId });

            return Ok(alerts);
        }
    }
}
