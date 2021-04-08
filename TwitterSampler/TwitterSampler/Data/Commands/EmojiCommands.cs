using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Data.Commands
{
    public class EmojiCommands
        : BaseCommands<TwitterDbContext>, IEmojiCommands
    {
        #region Constructors
        public EmojiCommands(TwitterDbContext databaseContext)
            : base(databaseContext)
        { }

        #endregion

        #region Public Methods
        public async Task AddEmoji(Emoji emoji)
        {
            DatabaseContext.Emoji.Add(emoji);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddEmojis(List<Emoji> emojis)
        {
            emojis.ForEach(e => DatabaseContext.Emoji.Add(e));
            await DatabaseContext.SaveChangesAsync();
        }

        #endregion
    }
}
