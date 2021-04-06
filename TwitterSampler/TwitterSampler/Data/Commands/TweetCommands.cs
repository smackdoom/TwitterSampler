using System;
using System.Threading.Tasks;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Data.Commands
{
    public class TweetCommands : ITweetCommands
    {
        private readonly ITweetCommandsRepository _tweetCommandsRepository;

        public TweetCommands(ITweetCommandsRepository tweetCommandsRepository)
        {
            _tweetCommandsRepository = tweetCommandsRepository;
        }

        public async Task AddTweet(Tweet tweet)
        {
            await _tweetCommandsRepository.AddTweet(tweet);
        }
    }
}
