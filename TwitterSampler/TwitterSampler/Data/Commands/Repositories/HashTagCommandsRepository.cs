using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tweetinvi.Models.V2;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Data.Commands.Repositories
{
    public class HashTagCommandsRepository
        : BaseCommandsRepository<TwitterDbContext>, IHashTagCommandsRepository
    {
        #region Constructors
        public HashTagCommandsRepository(TwitterDbContext databaseContext)
            : base(databaseContext)
        { }

        #endregion

        #region Public Methods
        public async Task AddHashTag(HashTag hashTag)
        {
            DatabaseContext.Add(hashTag);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddHashTags(List<HashTag> hashTags)
        {
            hashTags.ForEach(e => DatabaseContext.Add(e));
            await DatabaseContext.SaveChangesAsync();
        }

        #endregion
    }
}
