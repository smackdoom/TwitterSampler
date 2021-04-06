using System;
using System.Globalization;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Interfaces;
using TwitterSampler.Models;

namespace TwitterSampler.Services
{
    public class StatisticsService : IStatisticsService
    {
        #region Private Members
        private readonly ILogger<StatisticsService> _logger;
        private readonly IEmojiQueries _emojiQueries;
        private readonly IHashTagQueries _hashTagQueries;
        private readonly ITweetQueries _tweetQueries;
        private readonly IUrlQueries _urlQueries;

        private NumberFormatInfo _numberFormat = new CultureInfo("en-US", false).NumberFormat;
        #endregion

        #region Constructors
        public StatisticsService(ILogger<StatisticsService> logger,
            IEmojiQueries emojiQueries,
            IHashTagQueries hashTagQueries,
            ITweetQueries tweetQueries,
            IUrlQueries urlQueries)
        {
            _logger = logger;
            _emojiQueries = emojiQueries;
            _hashTagQueries = hashTagQueries;
            _tweetQueries = tweetQueries;
            _urlQueries = urlQueries;
        }

        #endregion

        #region Public Methods
        public async Task<TryGetResult<int>> GetTotalNumberOfTweets()
        {
            return await _tweetQueries.GetTotalNumberOfTweets();
        }

        public async Task<TryGetResult<double>> GetAverageNumberOfTweetsPerHour()
        {
            return await _tweetQueries.GetAverageTweetsPerHour();
        }

        public async Task<TryGetResult<double>> GetAverageNumberOfTweetsPerMinute()
        {
            return await _tweetQueries.GetAverageTweetsPerMinute();
        }

        public async Task<TryGetResult<double>> GetAverageNumberOfTweetsPerSecond()
        {
            return await _tweetQueries.GetAverageTweetsPerSecond();
        }

        public async Task<TryGetResult<string>> PercentOfTweetsWithEmojis()
        {
            var output = string.Empty;
            var result = new TryGetResult<string>(output);

            var emojiResponse = await _emojiQueries.GetDistinctReferenceCount();
            var tweetResponse = await _tweetQueries.GetTotalNumberOfTweets();

            if (emojiResponse.Success && tweetResponse.Success)
            {
                var percentage = (emojiResponse.Result / tweetResponse.Result);
                output = percentage.ToString("P", _numberFormat);
            }
            else
            {
                if (!emojiResponse.Success)
                    result = new TryGetResult<string>(emojiResponse.Exception);
                if (!tweetResponse.Success)
                    result = new TryGetResult<string>(tweetResponse.Exception);
            }

            return result;
        }

        public async Task<TryGetResult<string>> PercentOfTweetsWithPhotos()
        {
            return await _tweetQueries.PercentOfTweetsWithPhotos();
        }

        public async Task<TryGetResult<string>> PercentOfTweetsWithUrls()
        {
            return await _tweetQueries.PercentOfTweetsWithUrl();
        }

        public async Task<TryGetResult<string>> GetTopEmojisInTweets()
        {
            var output = string.Empty;
            var result = new TryGetResult<string>(output);

            var response = await _emojiQueries.GetTopEmojis();

            if (response.Success)
            {
                try
                {
                    output = JsonSerializer.Serialize(response.Result);
                }
                catch (Exception ex)
                {
                    result = new TryGetResult<string>(ex);
                }
            }
            else
                result = new TryGetResult<string>(response.Exception);

            return result;
        }

        public async Task<TryGetResult<string>> GetTopHashTagsInTweets()
        {
            var output = string.Empty;
            var result = new TryGetResult<string>(output);

            var response = await _hashTagQueries.GetTopHashTags();

            if (response.Success)
            {
                try
                {
                    output = JsonSerializer.Serialize(response.Result);
                }
                catch (Exception ex)
                {
                    result = new TryGetResult<string>(ex);
                }
            }
            else
                result = new TryGetResult<string>(response.Exception);

            return result;
        }

        public async Task<TryGetResult<string>> GetTopUrlsInTweets()
        {
            var output = string.Empty;
            var result = new TryGetResult<string>(output);

            var response = await _urlQueries.GetTopUrls();

            if (response.Success)
            {
                try
                {
                    output = JsonSerializer.Serialize(response.Result);
                }
                catch (Exception ex)
                {
                    result = new TryGetResult<string>(ex);
                }
            }
            else
                result = new TryGetResult<string>(response.Exception);

            return result;
        }
        #endregion
    }
}
