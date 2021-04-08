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
    public class HashTagQueries
        : BaseQueries<TwitterDbContext>, IHashTagQueries
    {
        #region Constructors
        public HashTagQueries(TwitterDbContext databaseContext)
            : base(databaseContext)
        { }

        #endregion

        #region Public Methods
        public async Task<TryGetResult<List<ItemCountDto>>> GetTopHashTags()
        {
            var result = default(TryGetResult<List<ItemCountDto>>);

            try
            {
                var hashTags = await DatabaseContext.HashTag
                .GroupBy(e => e.Value)
                .Select(e => new ItemCountDto
                {
                    Name = e.Key,
                    Count = e.Count()
                })
                .OrderByDescending(e => e.Count)
                .ToListAsync();

                result = new TryGetResult<List<ItemCountDto>>(hashTags);
            }
            catch (Exception ex)
            {
                result = new TryGetResult<List<ItemCountDto>>(ex);
            }

            return result;
        }

        #endregion
    }
}
