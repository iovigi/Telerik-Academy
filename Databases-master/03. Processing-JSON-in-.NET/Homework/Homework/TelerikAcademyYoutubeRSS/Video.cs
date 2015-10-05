using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TelerikAcademyYoutubeRSS
{
    public class Video
    {
        [JsonProperty("yt:videoId")]
        public string id;
        public string title;
        public Link link;
    }
}
