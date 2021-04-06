using System;
using System.Threading.Tasks;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Data.Interfaces
{
    public interface ITweetCommandsRepository
    {
        Task AddTweet(Tweet tweet);
    }
}
