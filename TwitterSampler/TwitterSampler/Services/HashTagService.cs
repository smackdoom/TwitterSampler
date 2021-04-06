using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Interfaces;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Services
{
    public class HashTagService : IHashTagService
    {
        #region Private Members
        private readonly ILogger<HashTagService> _logger;
        private readonly IHashTagCommands _hashTagCommands;

        #endregion

        #region Constructors
        public HashTagService(ILogger<HashTagService> logger,
            IHashTagCommands hashTagCommands)
        {
            _logger = logger;
            _hashTagCommands = hashTagCommands;
        }

        #endregion

        #region Public Methods        
        public async Task<bool> SaveHashTags(List<HashTag> hashTags)
        {
            var success = false;

            try
            {
                await _hashTagCommands.AddHashTags(hashTags);
                success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error saving Hash Tags to datastore.", ex);
            }

            return success;
        }

        #endregion
    }
}
