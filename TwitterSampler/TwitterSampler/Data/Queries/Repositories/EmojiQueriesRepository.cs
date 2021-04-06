using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Models.Dto;

namespace TwitterSampler.Data.Queries.Repositories
{
    public class EmojiQueriesRepository
        : BaseQueriesRepository<TwitterDbContext>, IEmojiQueriesRepository
    {
        public EmojiQueriesRepository(TwitterDbContext databaseContext)
            : base(databaseContext)
        { }

        #region Public Methods
        public async Task<List<ItemCountDto>> GetTopEmojis()
        {
            var topEmojis = await DatabaseContext.Emoji
                .GroupBy(e => e.ShortName)
                .Select(e => new ItemCountDto
                {
                    Name = e.Key,
                    Count = e.Count()
                })
                .OrderByDescending(e => e.Count)
                .ToListAsync();

            return topEmojis;
        }

        public async Task<int> GetDistinctReferenceCount()
        {
            var total = await DatabaseContext.Emoji.Select(e => e.ReferenceId).Distinct().CountAsync();
            return total;
        }
        #endregion
    }
}
