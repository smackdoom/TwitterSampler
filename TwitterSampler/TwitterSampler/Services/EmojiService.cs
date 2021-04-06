using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Extensions.Logging;
using Tweetinvi.Models.V2;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Interfaces;
using TwitterSampler.Models.Data;
using TwitterSampler.Models.Dto;

namespace TwitterSampler.Services
{
    public class EmojiService : IEmojiService
    {
        #region Private Members
        private readonly ILogger<EmojiService> _logger;
        private readonly IEmojiCommands _emojiCommands;
        private readonly IUtilityService _utilityService;

        private HashSet<string> _emojiUnicodes;
        private Dictionary<string, string> _embeddedEmojis;
        #endregion

        #region Constructors
        public EmojiService(ILogger<EmojiService> logger,
            IEmojiCommands emojiCommands,
            IUtilityService utilityService)
        {
            _logger = logger;
            _emojiCommands = emojiCommands;
            _utilityService = utilityService;
        }

        #endregion

        #region Public Methods        
        public async Task<bool> SaveEmojis(List<Emoji> emojis)
        {
            var success = false;

            try
            {
                await _emojiCommands.AddEmojis(emojis);
                success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error saving Emojis to datastore.", ex);
            }

            return success;
        }

        public async Task<List<Emoji>> ParseEmojis(string text)
        {
            var emojis = new List<Emoji>();

            if (!string.IsNullOrEmpty(text))
            {
                await LoadEmbeddedEmojis();
                var textSplit = text.Split(" ").ToList();
                var results = _emojiUnicodes.Where(e => text.Contains(e)).ToList();

                results.ForEach(r =>
                {
                    var emoji = _embeddedEmojis[r];
                    emojis.Add(new Emoji() { ShortName = emoji, Unified = r });
                });
            }

            return emojis;
        }
        #endregion

        #region Private Methods        
        private async Task LoadEmbeddedEmojis()
        {
            if (_embeddedEmojis == null)
            {
                _emojiUnicodes = new HashSet<string>();
                _embeddedEmojis = new Dictionary<string, string>();

                var emojis = await _utilityService.GetEmbeddedJsonFile<List<EmojiDto>>("TwitterSampler.Resources.emoji.json");

                if (emojis.Any())
                {
                    emojis.ForEach(e =>
                    {
                        var emoji = GetEmojiValue(e.Unified);
                        _emojiUnicodes.Add(emoji);
                        _embeddedEmojis.TryAdd(emoji, e.ShortName);
                    });
                }
            }
        }

        private string GetEmojiValue(string text)
        {
            //Give credit where credit is due
            //https://stackoverflow.com/questions/49375596/c-sharp-convert-string-with-emoji-to-unicode
            var chars = new List<char>();

            foreach (var point in text.Split('-'))
            {
                uint unicodeInt = uint.Parse(point, System.Globalization.NumberStyles.HexNumber);
                chars.AddRange(Encoding.UTF32.GetChars(BitConverter.GetBytes(unicodeInt)));
            }

            return new string(chars.ToArray());
        }

        #endregion
    }
}
