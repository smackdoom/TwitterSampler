using System;
using System.Threading.Tasks;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Models;

namespace TwitterSampler.Data.Queries
{
    public class TweetQueries : ITweetQueries
    {
        #region Private Members
        private readonly ITweetQueriesRepository _queriesRepository;

        #endregion

        #region Constructors
        public TweetQueries(ITweetQueriesRepository queriesRepository)
        {
            _queriesRepository = queriesRepository;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Gets the Total Number of Tweets
        /// </summary>
        /// <returns></returns>
        public async Task<TryGetResult<int>> GetTotalNumberOfTweets()
        {
            var total = default(int);
            var result = new TryGetResult<int>(total);

            try
            {
                total = await _queriesRepository.GetTotalNumberOfTweets();
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
            var average = default(double);
            var result = new TryGetResult<double>(average);

            try
            {
                average = await _queriesRepository.GetAverageTweetsPerHour();
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
            var average = default(double);
            var result = new TryGetResult<double>(average);

            try
            {
                average = await _queriesRepository.GetAverageTweetsPerMinute();
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
            var average = default(double);
            var result = new TryGetResult<double>(average);

            try
            {
                average = await _queriesRepository.GetAverageTweetsPerSecond();
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
            var formattedPercentage = "0.0%";
            var result = new TryGetResult<string>(formattedPercentage);

            try
            {
                var percentage = await _queriesRepository.PercentOfTweetsWithEmojis();
                formattedPercentage = string.Format("{0:0%}", percentage);
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
            var formattedPercentage = "0.0%";
            var result = new TryGetResult<string>(formattedPercentage);

            try
            {
                var percentage = await _queriesRepository.PercentOfTweetsWithPhotos();
                formattedPercentage = string.Format("{0:0%}", percentage);
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
            var formattedPercentage = "0.0%";
            var result = new TryGetResult<string>(formattedPercentage);

            try
            {
                var percentage = await _queriesRepository.PercentOfTweetsWithUrl();
                formattedPercentage = string.Format("{0:0%}", percentage);
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
