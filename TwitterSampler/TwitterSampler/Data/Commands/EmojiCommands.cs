using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Data.Commands
{
    public class EmojiCommands : IEmojiCommands
    {
        private readonly IEmojiCommandsRepository _emojiCommandsRepository;

        public EmojiCommands(IEmojiCommandsRepository tweetCommandsRepository)
        {
            _emojiCommandsRepository = tweetCommandsRepository;
        }

        public async Task AddEmoji(Emoji emoji)
        {
            await _emojiCommandsRepository.AddEmoji(emoji);
        }

        public async Task AddEmojis(List<Emoji> emojis)
        {
            await _emojiCommandsRepository.AddEmojis(emojis);
        }
    }
}
