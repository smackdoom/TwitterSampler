using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Models;
using TwitterSampler.Models.Dto;

namespace TwitterSampler.Data.Queries
{
    public class UrlQueries : IUrlQueries
    {
        #region Private Members
        private readonly IUrlQueriesRepository _urlQueriesRepository;

        #endregion

        #region Constructors
        public UrlQueries(IUrlQueriesRepository urlQueriesRepository)
        {
            _urlQueriesRepository = urlQueriesRepository;
        }

        #endregion

        #region Public Methods
        public async Task<TryGetResult<List<ItemCountDto>>> GetTopUrls()
        {
            var urls = new List<ItemCountDto>();
            var result = new TryGetResult<List<ItemCountDto>>(urls);

            try
            {
                urls = await _urlQueriesRepository.GetTopUrls();
            }
            catch (Exception ex)
            {
                result = new TryGetResult<List<ItemCountDto>>(ex);
            }

            return result;
        }

        public async Task<int> GetDistinctReferenceCount()
        {
            var count = await _urlQueriesRepository.GetDistinctReferenceCount();
            return count;
        }
        #endregion
    }
}
