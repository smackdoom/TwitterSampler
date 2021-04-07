using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tweetinvi.Models.V2;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Data.Commands.Repositories
{
    public class UrlCommandsRepository
        : BaseCommandsRepository<TwitterDbContext>, IUrlCommandsRepository
    {
        #region Constructors
        public UrlCommandsRepository(TwitterDbContext databaseContext)
            : base(databaseContext)
        { }

        #endregion

        #region Public Methods
        public async Task AddUrl(Url url)
        {
            DatabaseContext.Url.Add(url);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddUrls(List<Url> urls)
        {
            urls.ForEach(e => DatabaseContext.Url.Add(e));
            await DatabaseContext.SaveChangesAsync();
        }
        #endregion
    }
}
