using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Tweetinvi.Models.V2;
using TwitterSampler.Models;

namespace TwitterSampler.Interfaces
{
    public interface IStatisticsService
    {
        Task<TryGetResult<int>> GetTotalNumberOfTweets();
        Task<TryGetResult<double>> GetAverageNumberOfTweetsPerHour();
        Task<TryGetResult<double>> GetAverageNumberOfTweetsPerMinute();
        Task<TryGetResult<double>> GetAverageNumberOfTweetsPerSecond();
        Task<TryGetResult<string>> PercentOfTweetsWithEmojis();
        Task<TryGetResult<string>> PercentOfTweetsWithPhotos();
        Task<TryGetResult<string>> PercentOfTweetsWithUrls();
        Task<TryGetResult<string>> GetTopEmojisInTweets();
        Task<TryGetResult<string>> GetTopHashTagsInTweets();
        Task<TryGetResult<string>> GetTopUrlsInTweets();
    }
}
