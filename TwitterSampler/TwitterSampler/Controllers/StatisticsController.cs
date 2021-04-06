using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TwitterSampler.Interfaces;
using TwitterSampler.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TwitterSampler.Controllers
{
    [ApiController]
    [Route("statistics")]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        #region Constructors
        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Gets the total number of tweets in the system
        /// </summary>
        /// <returns></returns>
        [HttpGet("totalnumberoftweets")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> TotalNumberOfTweets()
        {
            var response = await _statisticsService.GetTotalNumberOfTweets();

            if (response.Success)
                return Ok(response.Result);
            else
                return StatusCode((int)HttpStatusCode.InternalServerError, response.Exception);
        }

        /// <summary>
        /// Gets the average number of tweets per hour
        /// </summary>
        /// <returns></returns>
        [HttpGet("averagenumberoftweetsperhour")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> AverageNumberOfTweetsPerHour()
        {
            var response = await _statisticsService.GetAverageNumberOfTweetsPerHour();

            if (response.Success)
                return Ok(response.Result);
            else
                return StatusCode((int)HttpStatusCode.InternalServerError, response.Exception); ;
        }

        /// <summary>
        /// Gets the average number of tweets per minute
        /// </summary>
        /// <returns></returns>
        [HttpGet("AverageNumberOfTweetsPerMinute")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> AverageNumberOfTweetsPerMinute()
        {
            var response = await _statisticsService.GetAverageNumberOfTweetsPerMinute();

            if (response.Success)
                return Ok(response.Result);
            else
                return StatusCode((int)HttpStatusCode.InternalServerError, response.Exception);
        }

        /// <summary>
        /// Gets the average number of tweets per second
        /// </summary>
        /// <returns></returns>
        [HttpGet("AverageNumberOfTweetsPerSecond")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> AverageNumberOfTweetsPerSecond()
        {
            var response = await _statisticsService.GetAverageNumberOfTweetsPerSecond();

            if (response.Success)
                return Ok(response.Result);
            else
                return StatusCode((int)HttpStatusCode.InternalServerError, response.Exception);
        }

        /// <summary>
        /// Gets the top emojis in all tweets
        /// </summary>
        /// <returns></returns>
        [HttpGet("TopEmojisInTweets")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> TopEmojisInTweets()
        {
            var response = await _statisticsService.GetTopEmojisInTweets();

            if (response.Success)
                return Ok(response.Result);
            else
                return StatusCode((int)HttpStatusCode.InternalServerError, response.Exception);
        }

        /// <summary>
        /// Gets the percentage of tweets that have emojis
        /// </summary>
        /// <returns></returns>
        [HttpGet("PercentageOfTweetsWithEmojis")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PercentageOfTweetsWithEmojis()
        {
            var response = await _statisticsService.PercentOfTweetsWithEmojis();

            if (response.Success)
                return Ok(response.Result);
            else
                return StatusCode((int)HttpStatusCode.InternalServerError, response.Exception);
        }

        /// <summary>
        /// Gets the percentage of tweets with urls
        /// </summary>
        /// <returns></returns>
        [HttpGet("PercentageOfTweetsWithUrls")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PercentageOfTweetsWithUrls()
        {
            var response = await _statisticsService.PercentOfTweetsWithUrls();

            if (response.Success)
                return Ok(response.Result);
            else
                return StatusCode((int)HttpStatusCode.InternalServerError, response.Exception);
        }

        /// <summary>
        /// Gets the percentage of tweets with photos
        /// </summary>
        /// <returns></returns>
        [HttpGet("PercentageOfTweetsWithPhotos")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PercentageOfTweetsWithPhotos()
        {
            var response = await _statisticsService.PercentOfTweetsWithPhotos();

            if (response.Success)
                return Ok(response.Result);
            else
                return StatusCode((int)HttpStatusCode.InternalServerError, response.Exception);
        }

        /// <summary>
        /// Gets the top hash tags in tweets
        /// </summary>
        /// <returns></returns>
        [HttpGet("TopHashtagInTweets")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> TopHashtagInTweets()
        {
            var response = await _statisticsService.GetTopHashTagsInTweets();

            if (response.Success)
                return Ok(response.Result);
            else
                return StatusCode((int)HttpStatusCode.InternalServerError, response.Exception);
        }

        /// <summary>
        /// Gets the top urls in tweets
        /// </summary>
        /// <returns></returns>
        [HttpGet("TopUrlsInTweets")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> TopUrlsInTweets()
        {
            var response = await _statisticsService.GetTopUrlsInTweets();

            if (response.Success)
                return Ok(response.Result);
            else
                return StatusCode((int)HttpStatusCode.InternalServerError, response.Exception);
        }

        #endregion
    }
}
