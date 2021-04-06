using System;
using Newtonsoft.Json;

namespace TwitterSampler.Models.Dto
{
    public class EmojiDto
    {
        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        [JsonProperty("unified")]
        public string Unified { get; set; }

        public EmojiDto()
        {
        }
    }
}
