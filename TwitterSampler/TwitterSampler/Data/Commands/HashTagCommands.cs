using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Data.Commands
{
    public class HashTagCommands
        : BaseCommands<TwitterDbContext>, IHashTagCommands
    {
        #region Constructors
        public HashTagCommands(TwitterDbContext databaseContext)
            : base(databaseContext)
        { }

        #endregion

        #region Public Methods
        public async Task AddHashTag(HashTag hashTag)
        {
            DatabaseContext.HashTag.Add(hashTag);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddHashTags(List<HashTag> hashTags)
        {
            hashTags.ForEach(e => DatabaseContext.HashTag.Add(e));
            await DatabaseContext.SaveChangesAsync();
        }

        #endregion
    }
}
