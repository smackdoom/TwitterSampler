using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tweetinvi.Models.V2;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Data.Interfaces
{
    public interface IEmojiCommandsRepository
    {
        Task AddEmoji(Emoji emoji);
        Task AddEmojis(List<Emoji> emojis);
    }
}
