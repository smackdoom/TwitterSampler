using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Models;

namespace TwitterSampler.Data.Queries.Repositories
{
    public class TweetQueriesRepository
        : BaseQueriesRepository<TwitterDbContext>, ITweetQueriesRepository
    {
        #region Constructors
        public TweetQueriesRepository(TwitterDbContext databaseContext)
            : base(databaseContext)
        { }

        #endregion

        #region Public Methods        
        public async Task<int> GetTotalNumberOfTweets()
        {
            var total = await DatabaseContext.Tweet.CountAsync();
            return total;
        }

        public async Task<double> GetAverageTweetsPerHour()
        {
            var average = await DatabaseContext.Tweet.GroupBy(item => item.CreatedAt.Hour,
                    (key, group) => new { Hour = key, Count = group.Count() })
                .AverageAsync(i => i.Count);

            return average;
        }

        public async Task<double> GetAverageTweetsPerMinute()
        {
            var average = await DatabaseContext.Tweet.GroupBy(item => item.CreatedAt.Minute,
                    (key, group) => new { Hour = key, Count = group.Count() })
                .AverageAsync(i => i.Count);

            return average;
        }

        public async Task<double> GetAverageTweetsPerSecond()
        {
            var average = await DatabaseContext.Tweet.GroupBy(item => item.CreatedAt.Second,
                        (key, group) => new { Hour = key, Count = group.Count() })
                    .AverageAsync(i => i.Count);

            return average;
        }

        public async Task<double> PercentOfTweetsWithEmojis()
        {
            var tweets = await DatabaseContext.Tweet.Select(t => new { Id = t.TweetId, HasEmojis = t.HasEmojis }).ToListAsync();
            return (double)tweets.Where(t => t.HasEmojis).Count() / tweets.Count();
        }

        public async Task<double> PercentOfTweetsWithPhotos()
        {
            var tweets = await DatabaseContext.Tweet.Select(t => new { Id = t.TweetId, HasPhotos = t.HasPhotos }).ToListAsync();
            return (double)tweets.Where(t => t.HasPhotos).Count() / tweets.Count();
        }

        public async Task<double> PercentOfTweetsWithUrl()
        {
            var tweets = await DatabaseContext.Tweet.Select(t => new { Id = t.TweetId, HasUrls = t.HasUrls }).ToListAsync();
            return (double)tweets.Where(t => t.HasUrls).Count() / tweets.Count();
        }
        #endregion
    }
}
