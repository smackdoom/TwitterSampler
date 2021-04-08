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
    public class UrlQueries
        : BaseQueries<TwitterDbContext>, IUrlQueries
    {
        #region Constructors
        public UrlQueries(TwitterDbContext databaseContext)
            : base(databaseContext)
        { }

        #endregion

        #region Public Methods
        public async Task<TryGetResult<List<ItemCountDto>>> GetTopUrls()
        {
            var result = default(TryGetResult<List<ItemCountDto>>);

            try
            {
                var urls = await DatabaseContext.Url
                .GroupBy(e => e.DisplayValue)
                .Select(e => new ItemCountDto
                {
                    Name = e.Key,
                    Count = e.Count()
                })
                .OrderByDescending(e => e.Count)
                .ToListAsync();

                result = new TryGetResult<List<ItemCountDto>>(urls);
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
