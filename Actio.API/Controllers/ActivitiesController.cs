using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Actio.Common.Commands;
using RawRabbit;

namespace Actio.API.Controllers
{
    [Route("api/[controller]")]
    public class ActivitiesController : Controller
    {
        private readonly IBusClient _busClient;

        public ActivitiesController(IBusClient busClient)
        {
            _busClient = busClient;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreateActivity command )
        {
            command.Id = Guid.NewGuid();
            command.CreatedAt = DateTime.Now;

            await _busClient.PublishAsync(command);

            return Accepted($"activities/{command.Id}");

        }
    }
}
