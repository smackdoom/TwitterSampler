using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tweetinvi.Models.V2;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Data.Commands.Repositories
{
    public class EmojiCommandsRepository
        : BaseCommandsRepository<TwitterDbContext>, IEmojiCommandsRepository
    {
        #region Constructrors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="databaseContext"></param>
        public EmojiCommandsRepository(TwitterDbContext databaseContext)
            : base(databaseContext)
        { }

        #endregion

        #region Public Methods
        /// <summary>
        /// Adds an Emoji to the datastore
        /// </summary>
        /// <param name="emoji"></param>
        /// <returns></returns>
        public async Task AddEmoji(Emoji emoji)
        {
            DatabaseContext.Add(emoji);
            await DatabaseContext.SaveChangesAsync();
        }

        /// <summary>
        /// Adds multiple Emojis to the datastore
        /// </summary>
        /// <param name="emojis"></param>
        /// <returns></returns>
        public async Task AddEmojis(List<Emoji> emojis)
        {
            emojis.ForEach(e => DatabaseContext.Add(e));
            await DatabaseContext.SaveChangesAsync();
        }

        #endregion
    }
}
