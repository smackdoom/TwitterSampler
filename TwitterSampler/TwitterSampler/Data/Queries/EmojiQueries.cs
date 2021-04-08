using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Models;
using TwitterSampler.Models.Dto;

namespace TwitterSampler.Data.Queries
{
    public class EmojiQueries
        : BaseQueries<TwitterDbContext>, IEmojiQueries
    {
        #region Constructors
        public EmojiQueries(TwitterDbContext databaseContext)
            : base(databaseContext)
        { }

        #endregion

        #region Public Methods
        public async Task<TryGetResult<List<ItemCountDto>>> GetTopEmojis()
        {
            var result = default(TryGetResult<List<ItemCountDto>>);

            try
            {
                var emojis = await DatabaseContext.Emoji
                .GroupBy(e => e.ShortName)
                .Select(e => new ItemCountDto
                {
                    Name = e.Key,
                    Count = e.Count()
                })
                .OrderByDescending(e => e.Count)
                .ToListAsync();

                result = new TryGetResult<List<ItemCountDto>>(emojis);
            }
            catch (Exception ex)
            {
                result = new TryGetResult<List<ItemCountDto>>(ex);
            }

            return result;
        }

        public async Task<TryGetResult<int>> GetDistinctReferenceCount()
        {
            var result = default(TryGetResult<int>);

            try
            {
                var count = await DatabaseContext.Emoji.Select(e => e.ReferenceId).Distinct().CountAsync();
                result = new TryGetResult<int>(count);
            }
            catch (Exception ex)
            {
                result = new TryGetResult<int>(ex);
            }

            return result;
        }
        #endregion

    }
}
