using System;
using System.Threading.Tasks;
using TwitterSampler.Models;

namespace TwitterSampler.Data.Interfaces
{
    public interface ITweetQueries
    {
        Task<TryGetResult<int>> GetTotalNumberOfTweets();
        Task<TryGetResult<double>> GetAverageTweetsPerHour();
        Task<TryGetResult<double>> GetAverageTweetsPerMinute();
        Task<TryGetResult<double>> GetAverageTweetsPerSecond();
        Task<TryGetResult<string>> PercentOfTweetsWithEmojis();
        Task<TryGetResult<string>> PercentOfTweetsWithPhotos();
        Task<TryGetResult<string>> PercentOfTweetsWithUrl();
    }
}
