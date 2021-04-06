using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Interfaces
{
    public interface IHashTagService
    {
        Task<bool> SaveHashTags(List<HashTag> hashTags);
    }
}
