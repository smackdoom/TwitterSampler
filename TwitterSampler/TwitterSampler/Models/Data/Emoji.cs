using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwitterSampler.Models.Data
{
    [Table("emoji")]
    public class Emoji
    {
        [Key]
        [Column("emojiid")]
        public long EmojiId { get; set; }

        [Column("referenceid")]
        public string ReferenceId { get; set; }

        [Column("shortname")]
        public string ShortName { get; set; }

        [Column("unified")]
        public string Unified { get; set; }
    }
}
