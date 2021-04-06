using System;
using System.Threading.Tasks;
using Tweetinvi.Models.V2;

namespace TwitterSampler.Interfaces
{
    public interface ITweetService
    {
        Task<bool> SaveTweet(TweetV2 tweet);
    }
}
