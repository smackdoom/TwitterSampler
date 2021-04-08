using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TwitterSampler.Data.Commands;
using TwitterSampler.Data.Interfaces;
using TwitterSampler.Data.Queries;
using TwitterSampler.Interfaces;
using TwitterSampler.Services;

namespace TwitterSampler
{
    public static class Extensions
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.TryAddTransient<IUtilityService, UtilityService>();
            services.TryAddTransient<IEmojiService, EmojiService>();
            services.TryAddTransient<IHashTagService, HashTagService>();
            services.TryAddTransient<ITweetService, TweetService>();
            services.TryAddTransient<IUrlService, UrlService>();
            services.TryAddTransient<IStatisticsService, StatisticsService>();
            services.AddHostedService<StreamingService>();
        }

        public static void ConfigureDataServices(this IServiceCollection services)
        {
            //Commands
            services.TryAddTransient<IEmojiCommands, EmojiCommands>();
            services.TryAddTransient<IHashTagCommands, HashTagCommands>();
            services.TryAddTransient<ITweetCommands, TweetCommands>();
            services.TryAddTransient<IUrlCommands, UrlCommands>();

            //Queries
            services.TryAddTransient<IEmojiQueries, EmojiQueries>();
            services.TryAddTransient<IHashTagQueries, HashTagQueries>();
            services.TryAddTransient<ITweetQueries, TweetQueries>();
            services.TryAddTransient<IUrlQueries, UrlQueries>();
        }
    }
}
