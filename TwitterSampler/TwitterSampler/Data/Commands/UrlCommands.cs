using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Data.Commands
{
    public class UrlCommands
        : BaseCommands<TwitterDbContext>, IUrlCommands
    {
        #region Constructors
        public UrlCommands(TwitterDbContext databaseContext)
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
