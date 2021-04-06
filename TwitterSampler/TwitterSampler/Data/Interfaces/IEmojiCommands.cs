using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Data.Interfaces
{
    public interface IEmojiCommands
    {
        Task AddEmoji(Emoji emoji);
        Task AddEmojis(List<Emoji> emojis);
    }
}
