using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Data.Interfaces
{
    public interface IHashTagCommands
    {
        Task AddHashTag(HashTag hashTag);
        Task AddHashTags(List<HashTag> hashTags);
    }
}
