using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using TwitterSampler.Controllers;
using TwitterSampler.Data;
using TwitterSampler.Data.Queries;
using TwitterSampler.Models.Data;
using TwitterSampler.Services;
using Xunit;

namespace TwitterSampler.UnitTest
{
    public class StatisticsControllerTest
    {
        #region Tests
        [Fact]
        public async Task Get_Total_Number_Of_Tweets_Success()
        {
            //Arrange
            await using var twitterDbContext = new TwitterDbContext(CreateDbContext());
            await twitterDbContext.AddRangeAsync(GenerateFakeTweets());
            await twitterDbContext.AddRangeAsync(GenerateFakeEmojis());
            await twitterDbContext.AddRangeAsync(GenerateFakeHashTags());
            await twitterDbContext.AddRangeAsync(GenerateFakeUrls());
            await twitterDbContext.SaveChangesAsync();

            var statisticsController = GenerateStatisticsController(twitterDbContext);
            int expected = 6;

            //Act
            var actionResult = await statisticsController.TotalNumberOfTweets();

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);
            var result = Assert.IsAssignableFrom<OkObjectResult>(actionResult);

            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public async Task Get_Average_Tweets_Per_Hour_Success()
        {
            //Arrange
            await using var twitterDbContext = new TwitterDbContext(CreateDbContext());
            await twitterDbContext.AddRangeAsync(GenerateFakeTweets());
            await twitterDbContext.AddRangeAsync(GenerateFakeEmojis());
            await twitterDbContext.AddRangeAsync(GenerateFakeHashTags());
            await twitterDbContext.AddRangeAsync(GenerateFakeUrls());
            await twitterDbContext.SaveChangesAsync();

            var statisticsController = GenerateStatisticsController(twitterDbContext);
            double expected = 3;

            //Act
            var actionResult = await statisticsController.AverageNumberOfTweetsPerHour();

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);
            var result = Assert.IsAssignableFrom<OkObjectResult>(actionResult);

            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public async Task Get_Average_Tweets_Per_Minute_Success()
        {
            //Arrange
            await using var twitterDbContext = new TwitterDbContext(CreateDbContext());
            await twitterDbContext.AddRangeAsync(GenerateFakeTweets());
            await twitterDbContext.AddRangeAsync(GenerateFakeEmojis());
            await twitterDbContext.AddRangeAsync(GenerateFakeHashTags());
            await twitterDbContext.AddRangeAsync(GenerateFakeUrls());
            await twitterDbContext.SaveChangesAsync();

            var statisticsController = GenerateStatisticsController(twitterDbContext);
            double expected = 3;

            //Act
            var actionResult = await statisticsController.AverageNumberOfTweetsPerMinute();

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);
            var result = Assert.IsAssignableFrom<OkObjectResult>(actionResult);

            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public async Task Get_Average_Tweets_Per_Second_Success()
        {
            //Arrange
            await using var twitterDbContext = new TwitterDbContext(CreateDbContext());
            await twitterDbContext.AddRangeAsync(GenerateFakeTweets());
            await twitterDbContext.AddRangeAsync(GenerateFakeEmojis());
            await twitterDbContext.AddRangeAsync(GenerateFakeHashTags());
            await twitterDbContext.AddRangeAsync(GenerateFakeUrls());
            await twitterDbContext.SaveChangesAsync();

            var statisticsController = GenerateStatisticsController(twitterDbContext);
            double expected = 3;

            //Act
            var actionResult = await statisticsController.AverageNumberOfTweetsPerSecond();

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);
            var result = Assert.IsAssignableFrom<OkObjectResult>(actionResult);

            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public async Task Get_Top_Emojis_In_Tweets_Success()
        {
            //Arrange
            await using var twitterDbContext = new TwitterDbContext(CreateDbContext());
            await twitterDbContext.AddRangeAsync(GenerateFakeTweets());
            await twitterDbContext.AddRangeAsync(GenerateFakeEmojis());
            await twitterDbContext.AddRangeAsync(GenerateFakeHashTags());
            await twitterDbContext.AddRangeAsync(GenerateFakeUrls());
            await twitterDbContext.SaveChangesAsync();

            var statisticsController = GenerateStatisticsController(twitterDbContext);
            string expected = "[{\"Name\":\"wink\",\"Count\":1},{\"Name\":\"cool\",\"Count\":1},{\"Name\":\"cry\",\"Count\":1}]";

            //Act
            var actionResult = await statisticsController.TopEmojisInTweets();

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);
            var result = Assert.IsAssignableFrom<OkObjectResult>(actionResult);

            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public async Task Get_Top_HashTags_In_Tweets_Success()
        {
            //Arrange
            await using var twitterDbContext = new TwitterDbContext(CreateDbContext());
            await twitterDbContext.AddRangeAsync(GenerateFakeTweets());
            await twitterDbContext.AddRangeAsync(GenerateFakeEmojis());
            await twitterDbContext.AddRangeAsync(GenerateFakeHashTags());
            await twitterDbContext.AddRangeAsync(GenerateFakeUrls());
            await twitterDbContext.SaveChangesAsync();

            var statisticsController = GenerateStatisticsController(twitterDbContext);
            string expected = "[{\"Name\":\"whazzzzupppp\",\"Count\":3},{\"Name\":\"havefun\",\"Count\":1},{\"Name\":\"dowhateverittakes\",\"Count\":1}]";

            //Act
            var actionResult = await statisticsController.TopHashtagInTweets();

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);
            var result = Assert.IsAssignableFrom<OkObjectResult>(actionResult);

            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public async Task Get_Top_URLs_In_Tweets_Success()
        {
            //Arrange
            await using var twitterDbContext = new TwitterDbContext(CreateDbContext());
            await twitterDbContext.AddRangeAsync(GenerateFakeTweets());
            await twitterDbContext.AddRangeAsync(GenerateFakeEmojis());
            await twitterDbContext.AddRangeAsync(GenerateFakeHashTags());
            await twitterDbContext.AddRangeAsync(GenerateFakeUrls());
            await twitterDbContext.SaveChangesAsync();

            var statisticsController = GenerateStatisticsController(twitterDbContext);
            string expected = "[{\"Name\":\"twitter.com\",\"Count\":1},{\"Name\":\"google.com\",\"Count\":1},{\"Name\":\"jha.com\",\"Count\":1},{\"Name\":\"pic.twitter.com\",\"Count\":1}]";

            //Act
            var actionResult = await statisticsController.TopUrlsInTweets();

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);
            var result = Assert.IsAssignableFrom<OkObjectResult>(actionResult);

            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public async Task Get_Percent_Of_Tweets_With_Emojis_Success()
        {
            //Arrange
            await using var twitterDbContext = new TwitterDbContext(CreateDbContext());
            await twitterDbContext.AddRangeAsync(GenerateFakeTweets());
            await twitterDbContext.AddRangeAsync(GenerateFakeEmojis());
            await twitterDbContext.AddRangeAsync(GenerateFakeHashTags());
            await twitterDbContext.AddRangeAsync(GenerateFakeUrls());
            await twitterDbContext.SaveChangesAsync();

            var statisticsController = GenerateStatisticsController(twitterDbContext);
            string expected = "50%";

            //Act
            var actionResult = await statisticsController.PercentageOfTweetsWithEmojis();

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);
            var result = Assert.IsAssignableFrom<OkObjectResult>(actionResult);

            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public async Task Get_Percent_Of_Tweets_With_Photos_Success()
        {
            //Arrange
            await using var twitterDbContext = new TwitterDbContext(CreateDbContext());
            await twitterDbContext.AddRangeAsync(GenerateFakeTweets());
            await twitterDbContext.AddRangeAsync(GenerateFakeEmojis());
            await twitterDbContext.AddRangeAsync(GenerateFakeHashTags());
            await twitterDbContext.AddRangeAsync(GenerateFakeUrls());
            await twitterDbContext.SaveChangesAsync();

            var statisticsController = GenerateStatisticsController(twitterDbContext);
            string expected = "17%";

            //Act
            var actionResult = await statisticsController.PercentageOfTweetsWithPhotos();

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);
            var result = Assert.IsAssignableFrom<OkObjectResult>(actionResult);

            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public async Task Get_Percent_Of_Tweets_With_URLs_Success()
        {
            //Arrange
            await using var twitterDbContext = new TwitterDbContext(CreateDbContext());
            await twitterDbContext.AddRangeAsync(GenerateFakeTweets());
            await twitterDbContext.AddRangeAsync(GenerateFakeEmojis());
            await twitterDbContext.AddRangeAsync(GenerateFakeHashTags());
            await twitterDbContext.AddRangeAsync(GenerateFakeUrls());
            await twitterDbContext.SaveChangesAsync();

            var statisticsController = GenerateStatisticsController(twitterDbContext);
            string expected = "50%";

            //Act
            var actionResult = await statisticsController.PercentageOfTweetsWithUrls();

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);
            var result = Assert.IsAssignableFrom<OkObjectResult>(actionResult);

            Assert.Equal(expected, result.Value);
        }

        #endregion

        #region Setup
        private static IEnumerable<Tweet> GenerateFakeTweets()
        {
            return new List<Tweet>
            {
                new Tweet
                {
                    TweetId = "1",
                    Text = "😉 You are such a flirt!",
                    HasEmojis = true,
                    HasUrls = false,
                    HasPhotos = false,
                    HasHashTags = false,
                    CreatedAt = DateTime.UtcNow
                },
                new Tweet
                {
                    TweetId = "2",
                    Text = "😎 You are so cool!",
                    HasEmojis = true,
                    HasUrls = true,
                    HasPhotos = false,
                    HasHashTags = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Tweet
                {
                    TweetId = "3",
                    Text = "😭 You make me cry!",
                    HasEmojis = true,
                    HasUrls = false,
                    HasPhotos = false,
                    HasHashTags = true,
                    CreatedAt = DateTime.UtcNow.AddMinutes(-2)
                },
                new Tweet
                {
                    TweetId = "4",
                    Text = "Check out my url!",
                    HasEmojis = false,
                    HasUrls = true,
                    HasPhotos = false,
                    HasHashTags = true,
                    CreatedAt = DateTime.UtcNow.AddMinutes(-2)
                },
                new Tweet
                {
                    TweetId = "5",
                    Text = "I love hashtags!",
                    HasEmojis = false,
                    HasUrls = false,
                    HasPhotos = false,
                    HasHashTags = true,
                    CreatedAt = DateTime.UtcNow.AddHours(-1)
                },
                new Tweet
                {
                    TweetId = "6",
                    Text = "I love photos and hashtags!",
                    HasEmojis = false,
                    HasUrls = true,
                    HasPhotos = true,
                    HasHashTags = true,
                    CreatedAt = DateTime.UtcNow.AddSeconds(-1)
                }
            };
        }

        private static IEnumerable<Emoji> GenerateFakeEmojis()
        {
            return new List<Emoji>
            {
                new Emoji
                {
                    EmojiId = 1,
                    ReferenceId = "1",
                    ShortName = "wink",
                    Unified = "1F609"
                },
                new Emoji
                {
                    EmojiId = 2,
                    ReferenceId = "2",
                    ShortName = "cool",
                    Unified = "1F192"
                },
                new Emoji
                {
                    EmojiId = 3,
                    ReferenceId = "3",
                    ShortName = "cry",
                    Unified = "1F622"
                }
            };
        }

        private static IEnumerable<HashTag> GenerateFakeHashTags()
        {
            return new List<HashTag>
            {
                new HashTag
                {
                    HashTagId = 1,
                    ReferenceId = "2",
                    Value = "whazzzzupppp"
                },
                new HashTag
                {
                    HashTagId = 2,
                    ReferenceId = "3",
                    Value = "havefun"
                },
                new HashTag
                {
                    HashTagId = 3,
                    ReferenceId = "4",
                    Value = "whazzzzupppp"
                },
                new HashTag
                {
                    HashTagId = 4,
                    ReferenceId = "5",
                    Value = "dowhateverittakes"
                },
                new HashTag
                {
                    HashTagId = 5,
                    ReferenceId = "6",
                    Value = "whazzzzupppp"
                }
            };
        }

        private static IEnumerable<Url> GenerateFakeUrls()
        {
            return new List<Url>
            {
                new Url
                {
                    UrlId = 1,
                    ReferenceId = "2",
                    Value = "http://www.twitter.com",
                    DisplayValue = "twitter.com"
                },
                new Url
                {
                    UrlId = 2,
                    ReferenceId = "4",
                    Value = "http://www.google.com",
                    DisplayValue = "google.com"
                },
                new Url
                {
                    UrlId = 3,
                    ReferenceId = "6",
                    Value = "http://www.jha.com",
                    DisplayValue = "jha.com"
                },
                new Url
                {
                    UrlId = 4,
                    ReferenceId = "6",
                    Value = "https://pic.twitter.com",
                    DisplayValue = "pic.twitter.com"
                }
            };
        }

        private static DbContextOptions<TwitterDbContext> CreateDbContext()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<TwitterDbContext>();
            builder.UseInMemoryDatabase("in-memory")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        private static StatisticsController GenerateStatisticsController(TwitterDbContext databaseContext)
        {
            //queries
            var emojiQueries = new EmojiQueries(databaseContext);
            var hashTagQueries = new HashTagQueries(databaseContext);
            var tweetQueries = new TweetQueries(databaseContext);
            var urlQueries = new UrlQueries(databaseContext);
            //services
            var statisticsService = new StatisticsService(NullLogger<StatisticsService>.Instance, emojiQueries, hashTagQueries, tweetQueries, urlQueries);
            //make it so
            return new StatisticsController(statisticsService);
        }

        #endregion
    }
}
