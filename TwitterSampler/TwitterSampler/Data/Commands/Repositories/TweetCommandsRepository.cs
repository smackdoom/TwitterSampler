using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Tweetinvi.Models.V2;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Data.Commands.Repositories
{
    public class TweetCommandsRepository
        : BaseCommandsRepository<TwitterDbContext>, ITweetCommandsRepository
    {
        #region Private Members
        private readonly ILogger<TweetCommandsRepository> _logger;
        #endregion

        #region Constructors
        public TweetCommandsRepository(ILogger<TweetCommandsRepository> logger,
            TwitterDbContext databaseContext)
            : base(databaseContext)
        {
            _logger = logger;
        }

        #endregion

        #region Public Methods
        public async Task AddTweet(Tweet tweet)
        {
            try
            {
                DatabaseContext.Tweet.Add(tweet);
                await DatabaseContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
