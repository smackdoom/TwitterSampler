using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterSampler.Models.Dto;

namespace TwitterSampler.Data.Interfaces
{
    public interface IUrlQueriesRepository
    {
        Task<List<ItemCountDto>> GetTopUrls();
        Task<int> GetDistinctReferenceCount();
    }
}
