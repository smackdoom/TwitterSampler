using System;
using System.Threading.Tasks;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Data.Commands
{
    public class TweetCommands
        : BaseCommands<TwitterDbContext>, ITweetCommands
    {
        #region Constructors
        public TweetCommands(TwitterDbContext databaseContext)
            : base(databaseContext)
        { }

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
