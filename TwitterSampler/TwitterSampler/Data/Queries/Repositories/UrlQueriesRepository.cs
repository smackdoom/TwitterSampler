using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Models.Dto;

namespace TwitterSampler.Data.Queries.Repositories
{
    public class UrlQueriesRepository
        : BaseQueriesRepository<TwitterDbContext>, IUrlQueriesRepository
    {
        #region Constructors
        public UrlQueriesRepository(TwitterDbContext databaseContext)
            : base(databaseContext)
        { }

        #endregion

        #region Public Methods
        public async Task<List<ItemCountDto>> GetTopUrls()
        {
            var topUrls = await DatabaseContext.Url
                .GroupBy(e => e.Value)
                .Select(e => new ItemCountDto
                {
                    Name = e.Key,
                    Count = e.Count()
                })
                .OrderByDescending(e => e.Count)
                .ToListAsync();

            return topUrls;
        }

        public async Task<int> GetDistinctReferenceCount()
        {
            var total = await DatabaseContext.Url.Select(e => e.ReferenceId).Distinct().CountAsync();
            return total;
        }
        #endregion
    }
}
