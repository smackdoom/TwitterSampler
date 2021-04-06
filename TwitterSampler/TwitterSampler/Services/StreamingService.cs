using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Models.V2;
using TwitterSampler.Data;
using TwitterSampler.Interfaces;

namespace TwitterSampler.Services
{
    /// <summary>
    /// Service used for streaming from a URL
    /// </summary>
    public class StreamingService : BackgroundService
    {
        #region Private Members
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<IStreamingService> _logger;
        private readonly IOptionsMonitor<AppSettings> _appSettings;
        #endregion

        #region Constructors
        public StreamingService(ILogger<IStreamingService> logger,
            IOptionsMonitor<AppSettings> appSettings,
            IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _appSettings = appSettings;
            _serviceScopeFactory = serviceScopeFactory;
        }

        #endregion

        #region Protected Methods        
        /// <summary>
        /// Executes the Streaming Service
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Streaming service started.");

            try
            {
                var settings = GetRequiredSettings();
                var credentials = new ConsumerOnlyCredentials(settings.ConsumerKey, settings.ConsumerSecret)
                {
                    BearerToken = settings.BearerToken
                };

                var client = new TwitterClient(credentials);
                var stream = client.StreamsV2.CreateSampleStream();

                //Because it's a singleton, we need to do some special stuff here
                //https://blog.hildenco.com/2018/12/accessing-entity-framework-context-on.html
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var tweetService = scope.ServiceProvider.GetService<ITweetService>();

                    while (!stoppingToken.IsCancellationRequested)
                    {
                        stream.TweetReceived += (sender, args) =>
                        {
                            tweetService.SaveTweet(args.Tweet);
                            _logger.LogInformation(args.Tweet.Text);
                        };

                        await stream.StartAsync();
                    }
                }

                stream.StopStream();

                _logger.LogInformation("Streaming service stopping.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Private Methods
        private (string ConsumerKey, string ConsumerSecret, string BearerToken) GetRequiredSettings()
        {
            var consumerKey = _appSettings?.CurrentValue?.ConsumerKey;
            var consumerSecret = _appSettings?.CurrentValue?.ConsumerSecret;
            var bearerToken = _appSettings?.CurrentValue?.BearerToken;

            if (string.IsNullOrEmpty(consumerKey))
                throw new MissingFieldException("Missing Consumer Key.");
            if (string.IsNullOrEmpty(consumerSecret))
                throw new MissingFieldException("Missing Consumer Secret.");
            if (string.IsNullOrEmpty(bearerToken))
                throw new MissingFieldException("Missing Bearer Token.");

            return (consumerKey, consumerSecret, bearerToken);
        }
        #endregion
    }
}
