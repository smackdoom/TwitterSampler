using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Data.Commands
{
    public class UrlCommands : IUrlCommands
    {
        #region Private Members
        private readonly IUrlCommandsRepository _urlCommandsRepository;

        #endregion

        public UrlCommands(IUrlCommandsRepository urlCommandsRepository)
        {
            _urlCommandsRepository = urlCommandsRepository;
        }

        public async Task AddUrl(Url url)
        {
            await _urlCommandsRepository.AddUrl(url);
        }

        public async Task AddUrls(List<Url> urls)
        {
            await _urlCommandsRepository.AddUrls(urls);
        }
    }
}
