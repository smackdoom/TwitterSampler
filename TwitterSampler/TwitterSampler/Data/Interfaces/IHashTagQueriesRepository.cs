using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterSampler.Models.Dto;

namespace TwitterSampler.Data.Interfaces
{
    public interface IHashTagQueriesRepository
    {
        Task<List<ItemCountDto>> GetTopHashTags();
    }
}
