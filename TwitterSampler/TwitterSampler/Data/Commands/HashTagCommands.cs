using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Data.Commands
{
    public class HashTagCommands : IHashTagCommands
    {
        private readonly IHashTagCommandsRepository _hashTagCommandsRepository;

        public HashTagCommands(IHashTagCommandsRepository hashTagCommandsRepository)
        {
            _hashTagCommandsRepository = hashTagCommandsRepository;
        }

        public async Task AddHashTag(HashTag hashTag)
        {
            await _hashTagCommandsRepository.AddHashTag(hashTag);
        }

        public async Task AddHashTags(List<HashTag> hashTags)
        {
            await _hashTagCommandsRepository.AddHashTags(hashTags);
        }
    }
}
