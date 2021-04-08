using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Models;

namespace TwitterSampler.Data.Queries
{
    public class TweetQueries
        : BaseQueries<TwitterDbContext>, ITweetQueries
    {
        #region Constructors
        public TweetQueries(TwitterDbContext databaseContext)
            : base(databaseContext)
        { }

        #endregion

        #region Public Methods
        /// <summary>
        /// Gets the Total Number of Tweets
        /// </summary>
        /// <returns></returns>
        public async Task<TryGetResult<int>> GetTotalNumberOfTweets()
        {
            var result = default(TryGetResult<int>);

            try
            {
                var total = await DatabaseContext.Tweet.CountAsync();
                result = new TryGetResult<int>(total);
            }
            catch (Exception ex)
            {
                result = new TryGetResult<int>(ex);
            }

            return result;
        }

        /// <summary>
        /// Gets the Average Tweets Per Hour
        /// </summary>
        /// <returns></returns>
        public async Task<TryGetResult<double>> GetAverageTweetsPerHour()
        {
            var result = default(TryGetResult<double>);

            try
            {
                var average = await DatabaseContext.Tweet.GroupBy(item => item.CreatedAt.Hour,
                    (key, group) => new { Hour = key, Count = group.Count() })
                .AverageAsync(i => i.Count);

                result = new TryGetResult<double>(average);
            }
            catch (Exception ex)
            {
                result = new TryGetResult<double>(ex);
            }

            return result;
        }

        /// <summary>
        /// Gets the Average Tweets Per Minute
        /// </summary>
        /// <returns></returns>
        public async Task<TryGetResult<double>> GetAverageTweetsPerMinute()
        {
            var result = default(TryGetResult<double>);

            try
            {
                var average = await DatabaseContext.Tweet.GroupBy(item => item.CreatedAt.Minute,
                    (key, group) => new { Hour = key, Count = group.Count() })
                .AverageAsync(i => i.Count);

                result = new TryGetResult<double>(average);
            }
            catch (Exception ex)
            {
                result = new TryGetResult<double>(ex);
            }

            return result;
        }

        /// <summary>
        /// Gets the Average Tweets Per Second
        /// </summary>
        /// <returns></returns>
        public async Task<TryGetResult<double>> GetAverageTweetsPerSecond()
        {
            var result = default(TryGetResult<double>);

            try
            {
                var average = await DatabaseContext.Tweet.GroupBy(item => item.CreatedAt.Second,
                        (key, group) => new { Hour = key, Count = group.Count() })
                    .AverageAsync(i => i.Count);

                result = new TryGetResult<double>(average);
            }
            catch (Exception ex)
            {
                result = new TryGetResult<double>(ex);
            }

            return result;
        }

        /// <summary>
        /// Gets the Percentage of Tweets with Emojis
        /// </summary>
        /// <returns></returns>
        public async Task<TryGetResult<string>> PercentOfTweetsWithEmojis()
        {
            var result = default(TryGetResult<string>);

            try
            {
                var tweets = await DatabaseContext.Tweet.Select(t => new { Id = t.TweetId, HasEmojis = t.HasEmojis }).ToListAsync();
                var percentage = (double)tweets.Where(t => t.HasEmojis).Count() / tweets.Count();
                var formattedPercentage = string.Format("{0:0%}", percentage);

                result = new TryGetResult<string>(formattedPercentage);
            }
            catch (Exception ex)
            {
                result = new TryGetResult<string>(ex);
            }

            return result;
        }

        /// <summary>
        /// Gets the Percentage of Tweets with Photos
        /// </summary>
        /// <returns></returns>
        public async Task<TryGetResult<string>> PercentOfTweetsWithPhotos()
        {
            var result = default(TryGetResult<string>);

            try
            {
                var tweets = await DatabaseContext.Tweet.Select(t => new { Id = t.TweetId, HasPhotos = t.HasPhotos }).ToListAsync();
                var percentage = (double)tweets.Where(t => t.HasPhotos).Count() / tweets.Count();
                var formattedPercentage = string.Format("{0:0%}", percentage);

                result = new TryGetResult<string>(formattedPercentage);
            }
            catch (Exception ex)
            {
                result = new TryGetResult<string>(ex);
            }

            return result;
        }

        /// <summary>
        /// Gets the Percentage of Tweets with Urls
        /// </summary>
        /// <returns></returns>
        public async Task<TryGetResult<string>> PercentOfTweetsWithUrl()
        {
            var result = default(TryGetResult<string>);

            try
            {
                var tweets = await DatabaseContext.Tweet.Select(t => new { Id = t.TweetId, HasUrls = t.HasUrls }).ToListAsync();
                var percentage = (double)tweets.Where(t => t.HasUrls).Count() / tweets.Count();
                var formattedPercentage = string.Format("{0:0%}", percentage);

                result = new TryGetResult<string>(formattedPercentage);
            }
            catch (Exception ex)
            {
                result = new TryGetResult<string>(ex);
            }

            return result;
        }

        #endregion


    }
}
