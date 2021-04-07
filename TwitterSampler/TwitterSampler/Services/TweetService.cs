using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Tweetinvi.Models.V2;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Interfaces;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Services
{
    public class TweetService : ITweetService
    {
        #region Private Members
        private readonly ILogger<TweetService> _logger;
        private readonly ITweetCommands _tweetCommands;
        private readonly ITweetQueries _tweetQueries;
        private readonly IEmojiService _emojiService;
        private readonly IHashTagService _hashTagService;
        private readonly IUrlService _urlService;

        #endregion

        #region Constructors
        public TweetService(ILogger<TweetService> logger,
            ITweetCommands tweetCommands,
            ITweetQueries tweetQueries,
            IEmojiService emojiService,
            IHashTagService hashTagService,
            IUrlService urlService)
        {
            _logger = logger;
            _tweetCommands = tweetCommands;
            _tweetQueries = tweetQueries;
            _emojiService = emojiService;
            _hashTagService = hashTagService;
            _urlService = urlService;
        }

        #endregion

        #region Public Methods
        public async Task<bool> SaveTweet(TweetV2 tweet)
        {
            var success = true;

            try
            {
                var newTweet = new Models.Data.Tweet();

                newTweet.TweetId = tweet.Id;
                newTweet.Text = tweet?.Text;
                newTweet.HasEmojis = await SaveEmojis(tweet);
                newTweet.HasHashTags = await SaveHashTags(tweet);
                newTweet.HasUrls = await SaveUrls(tweet);
                newTweet.HasPhotos = HasPhotoUrls(tweet);
                newTweet.CreatedAt = tweet.CreatedAt;

                await _tweetCommands.AddTweet(newTweet);
            }
            catch (Exception ex)
            {
                success = false;
                _logger.LogError(ex, "Error saving tweet.");
            }

            return success;
        }
        #endregion

        #region Private Methods
        private async Task<bool> SaveEmojis(TweetV2 tweet)
        {
            var hasEmoji = false;
            var emojis = await _emojiService.ParseEmojis(tweet.Text);

            if (emojis.Any())
            {
                emojis.ForEach(e => e.ReferenceId = tweet.Id);
                hasEmoji = await _emojiService.SaveEmojis(emojis);
            }

            return hasEmoji;
        }

        private async Task<bool> SaveHashTags(TweetV2 tweet)
        {
            var hasTags = false;
            var originalHashTags = tweet?.Entities?.Hashtags?.ToList();

            if (originalHashTags != null && originalHashTags.Any())
            {
                var hashTags = new List<HashTag>();

                originalHashTags.ForEach(h =>
                {
                    hashTags.Add(new HashTag()
                    {
                        Value = h.Tag,
                        ReferenceId = tweet.Id
                    });
                });

                hasTags = await _hashTagService.SaveHashTags(hashTags);
            }

            return hasTags;
        }

        private async Task<bool> SaveUrls(TweetV2 tweet)
        {
            var hasUrls = false;
            var originalUrls = tweet?.Entities?.Urls?.ToList();

            if (originalUrls != null && originalUrls.Any())
            {
                var urls = new List<Url>();

                originalUrls.ForEach(u =>
                {
                    urls.Add(new Url()
                    {
                        Value = u.ExpandedUrl,
                        ReferenceId = tweet.Id,
                        DisplayValue = u.DisplayUrl
                    });
                });

                hasUrls = await _urlService.SaveUrls(urls);
            }

            return hasUrls;
        }

        private bool HasPhotoUrls(TweetV2 tweet)
        {
            var hasPhotos = false;
            var urls = ParseUrls(tweet);

            if (!string.IsNullOrEmpty(urls))
            {
                var parsedUrls = urls.Split(",").ToList();
                hasPhotos = parsedUrls.Any(u => Constants.PhotoUrls.Contains(u.ToLower()));
            }

            return hasPhotos;
        }

        private string ParseUrls(TweetV2 tweet)
        {
            var urls = tweet?.Entities?.Urls?.ToList();
            var parsedUrls = string.Empty;

            if (urls != null && urls.Count() > 0)
            {
                parsedUrls = string.Join(",", urls.Select(u => u.Url));
            }

            return parsedUrls;
        }
        #endregion
    }
}
