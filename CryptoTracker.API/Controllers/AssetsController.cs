using CryptoTracker.Application.Features.Alerts.Commands.CreateAlert;
using CryptoTracker.Application.Features.Alerts.Queries.GetUserAlerts;
using CryptoTracker.Application.Features.Assets.Queries.GetAssets;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CryptoTracker.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AssetsController : ControllerBase
    {
        private readonly ISender _sender;

        public AssetsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAssets()
        {
            var result = await _sender.Send(new GetAssetsQuery());
            return Ok(result);
        }

        [HttpGet("{symbol}")]
        public async Task<IActionResult> GetAssetBySymbol(string symbol)
        {
            var result = await _sender.Send(new GetAssetBySymbolQuery { 
                Symbol = symbol 
            });

            return Ok(result);
        }
    }
}
