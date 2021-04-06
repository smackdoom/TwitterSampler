using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterSampler.Models.Dto;

namespace TwitterSampler.Data.Interfaces
{
    public interface IEmojiQueriesRepository
    {
        Task<List<ItemCountDto>> GetTopEmojis();
        Task<int> GetDistinctReferenceCount();
    }
}
