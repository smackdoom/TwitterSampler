using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Models.Dto;

namespace TwitterSampler.Data.Queries.Repositories
{
    public class HashTagQueriesRepository
         : BaseQueriesRepository<TwitterDbContext>, IHashTagQueriesRepository
    {
        #region Constructors
        public HashTagQueriesRepository(TwitterDbContext databaseContext)
            : base(databaseContext)
        { }

        #endregion

        #region Public Methods
        public async Task<List<ItemCountDto>> GetTopHashTags()
        {
            var topHashTags = await DatabaseContext.HashTag
                .GroupBy(e => e.Value)
                .Select(e => new ItemCountDto
                {
                    Name = e.Key,
                    Count = e.Count()
                })
                .OrderByDescending(e => e.Count)
                .ToListAsync();

            return topHashTags;
        }

        #endregion
    }
}
