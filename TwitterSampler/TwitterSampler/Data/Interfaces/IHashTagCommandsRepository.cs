using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tweetinvi.Models.V2;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Data.Interfaces
{
    public interface IHashTagCommandsRepository
    {
        Task AddHashTag(HashTag hashTag);
        Task AddHashTags(List<HashTag> hashTags);
    }
}
