using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Models;
using TwitterSampler.Models.Dto;

namespace TwitterSampler.Data.Queries
{
    public class EmojiQueries : IEmojiQueries
    {
        #region Private Members
        private readonly IEmojiQueriesRepository _emojiQueriesRepository;

        #endregion

        #region Constructors
        public EmojiQueries(IEmojiQueriesRepository emojiQueriesRepository)
        {
            _emojiQueriesRepository = emojiQueriesRepository;
        }

        #endregion

        #region Public Methods
        public async Task<TryGetResult<List<ItemCountDto>>> GetTopEmojis()
        {
            var emojis = new List<ItemCountDto>();
            var result = default(TryGetResult<List<ItemCountDto>>);

            try
            {
                emojis = await _emojiQueriesRepository.GetTopEmojis();
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
            var count = default(int);
            var result = default(TryGetResult<int>);

            try
            {
                count = await _emojiQueriesRepository.GetDistinctReferenceCount();
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
