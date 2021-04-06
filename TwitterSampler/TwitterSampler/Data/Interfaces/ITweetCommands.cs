using System;
using System.Threading.Tasks;
using Tweetinvi.Models.V2;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Data.Interfaces
{
    public interface ITweetCommands
    {
        Task AddTweet(Tweet tweet);
    }
}
