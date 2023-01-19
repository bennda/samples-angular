using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace DBN.Samples.Angular.Ping.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        private readonly ILogger<PingController> _logger;

        public PingController(ILogger<PingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? host)
        {
            if (string.IsNullOrEmpty(host))
            {
                return BadRequest();
            }

            var dtStart = DateTime.Now;
            var pingSender = new System.Net.NetworkInformation.Ping();
            
            try
            {
                var reply = await pingSender.SendPingAsync(host);
                await Task.Delay(1000);

                return Ok(new
                {
                    EventStart = dtStart,
                    Duration = (DateTime.Now - dtStart).TotalMilliseconds,
                    StatusCode = reply.Status,
                    StatusText = reply.Status.ToString(),
                    RoundtripTime = reply.RoundtripTime,
                    Address = reply.Address.ToString(),
                    Ttl = reply.Options?.Ttl
                });
            } catch(PingException ex)
            {
                return StatusCode(500, ex.InnerException?.Message ?? string.Empty);
            }
        }
    }
}
