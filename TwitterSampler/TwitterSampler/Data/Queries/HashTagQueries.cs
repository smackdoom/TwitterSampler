using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Models;
using TwitterSampler.Models.Dto;

namespace TwitterSampler.Data.Queries
{
    public class HashTagQueries : IHashTagQueries
    {
        #region Private Members
        private readonly IHashTagQueriesRepository _hashTagQueriesRepository;

        #endregion

        #region Constructors
        public HashTagQueries(IHashTagQueriesRepository hashTagQueriesRepository)
        {
            _hashTagQueriesRepository = hashTagQueriesRepository;
        }

        #endregion

        #region Public Methods
        public async Task<TryGetResult<List<ItemCountDto>>> GetTopHashTags()
        {
            var hashTags = new List<ItemCountDto>();
            var result = new TryGetResult<List<ItemCountDto>>(hashTags);

            try
            {
                hashTags = await _hashTagQueriesRepository.GetTopHashTags();
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
