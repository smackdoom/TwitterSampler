using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwitterSampler.Models.Data
{
    [Table("url")]
    public class Url
    {
        [Key]
        [Column("urlid")]
        public long UrlId { get; set; }

        [Column("referenceid")]
        public string ReferenceId { get; set; }

        [Column("value")]
        public string Value { get; set; }

        [Column("displayvalue")]
        public string DisplayValue { get; set; }
    }
}
