using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwitterSampler.Models.Data
{
    [Table("tweet")]
    public class Tweet
    {
        [Key]
        [Column("tweetid")]
        public string TweetId { get; set; }

        [Column("text")]
        public string Text { get; set; }

        [Column("hasemojis")]
        public bool HasEmojis { get; set; }

        [Column("hashashtags")]
        public bool HasHashTags { get; set; }

        [Column("hasphotos")]
        public bool HasPhotos { get; set; }

        [Column("photos")]
        public string Photos { get; set; }

        [Column("hasurls")]
        public bool HasUrls { get; set; }

        [Column("createdat")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
