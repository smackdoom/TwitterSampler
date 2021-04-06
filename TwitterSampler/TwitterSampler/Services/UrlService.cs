using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Interfaces;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Services
{
    public class UrlService : IUrlService
    {
        #region Private Members
        private readonly ILogger<EmojiService> _logger;
        private readonly IUrlCommands _urlCommands;
        #endregion

        #region Constructors
        public UrlService(ILogger<EmojiService> logger,
            IUrlCommands urlCommands)
        {
            _logger = logger;
            _urlCommands = urlCommands;
        }

        #endregion

        #region Public Methods
        public async Task<bool> SaveUrl(Url url)
        {
            var success = false;

            try
            {
                await _urlCommands.AddUrl(url);
                success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error saving Url to datastore.", ex);
            }

            return success;
        }

        public async Task<bool> SaveUrls(List<Url> urls)
        {
            var success = false;

            try
            {
                await _urlCommands.AddUrls(urls);
                success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error saving Urls to datastore.", ex);
            }

            return success;
        }

        #endregion
    }
}
