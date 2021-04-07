using System;
using System.Threading.Tasks;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Models;

namespace TwitterSampler.Data.Queries
{
    public class TweetQueries : ITweetQueries
    {
        #region Private Members
        private readonly ITweetQueriesRepository _tweetQueriesRepository;

        #endregion

        #region Constructors
        public TweetQueries(ITweetQueriesRepository tweetQueriesRepository)
        {
            _tweetQueriesRepository = tweetQueriesRepository;
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
            var result = default(TryGetResult<int>);

            try
            {
                total = await _tweetQueriesRepository.GetTotalNumberOfTweets();
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
            var average = default(double);
            var result = default(TryGetResult<double>);

            try
            {
                average = await _tweetQueriesRepository.GetAverageTweetsPerHour();
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
            var average = default(double);
            var result = default(TryGetResult<double>);

            try
            {
                average = await _tweetQueriesRepository.GetAverageTweetsPerMinute();
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
            var average = default(double);
            var result = default(TryGetResult<double>);

            try
            {
                average = await _tweetQueriesRepository.GetAverageTweetsPerSecond();
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
            var formattedPercentage = "0.0%";
            var result = default(TryGetResult<string>);

            try
            {
                var percentage = await _tweetQueriesRepository.PercentOfTweetsWithEmojis();
                formattedPercentage = string.Format("{0:0%}", percentage);
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
            var formattedPercentage = "0.0%";
            var result = default(TryGetResult<string>);

            try
            {
                var percentage = await _tweetQueriesRepository.PercentOfTweetsWithPhotos();
                formattedPercentage = string.Format("{0:0%}", percentage);
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
            var formattedPercentage = "0.0%";
            var result = default(TryGetResult<string>);

            try
            {
                var percentage = await _tweetQueriesRepository.PercentOfTweetsWithUrl();
                formattedPercentage = string.Format("{0:0%}", percentage);
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
