using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikAcademyYoutubeRSS
{
    public class Link
    {
        [JsonProperty("@rel")]
        public string rel;

        [JsonProperty("@href")]
        public string href;
    }
}
