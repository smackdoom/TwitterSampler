using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tweetinvi.Models.V2;
using TwitterSampler.Models.Data;
using TwitterSampler.Models.Dto;

namespace TwitterSampler.Interfaces
{
    public interface IEmojiService
    {
        /// <summary>
        /// Saves all Emojis to the datastore
        /// </summary>
        /// <param name="tweet"></param>
        /// <returns></returns>
        Task<bool> SaveEmojis(List<Emoji> emojis);

        /// <summary>
        /// Parses and returns a list of emojis from text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        Task<List<Emoji>> ParseEmojis(string text);
    }
}
