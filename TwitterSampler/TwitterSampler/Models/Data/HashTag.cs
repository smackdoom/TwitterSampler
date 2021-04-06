using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwitterSampler.Models.Data
{
    [Table("hashtag")]
    public class HashTag
    {
        [Key]
        [Column("hastagid")]
        public long HashTagId { get; set; }

        [Column("referenceid")]
        public string ReferenceId { get; set; }

        [Column("value")]
        public string Value { get; set; }
    }
}
