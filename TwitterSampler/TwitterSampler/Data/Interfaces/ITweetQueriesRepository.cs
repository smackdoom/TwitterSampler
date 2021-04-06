using System;
using System.Threading.Tasks;

namespace TwitterSampler.Data.Interfaces
{
    public interface ITweetQueriesRepository
    {
        Task<int> GetTotalNumberOfTweets();
        Task<double> GetAverageTweetsPerHour();
        Task<double> GetAverageTweetsPerMinute();
        Task<double> GetAverageTweetsPerSecond();
        Task<double> PercentOfTweetsWithEmojis();
        Task<double> PercentOfTweetsWithPhotos();
        Task<double> PercentOfTweetsWithUrl();
    }
}
