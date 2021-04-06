using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TwitterSampler.Interfaces;

namespace TwitterSampler.Controllers
{
    public class StreamingController : ControllerBase
    {
        private readonly IStreamingService _streamingService;

        public StreamingController(IStreamingService streamingService)
        {
            _streamingService = streamingService;
        }

        #region Public Methods
        [HttpPost("start")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Start()
        {
            await Task.CompletedTask;
            await _streamingService.StartAsync();

            return Ok("Success");
        }

        [HttpPost("stop")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Stop()
        {
            await Task.CompletedTask;
            await _streamingService.StopAsync();

            return Ok("Success");
        }

        #endregion
    }
}
