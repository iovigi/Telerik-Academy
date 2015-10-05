using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Formatting = Newtonsoft.Json.Formatting;

namespace TelerikAcademyYoutubeRSS
{
    class RSSFeeder
    {
        static void Main(string[] args)
        {
            var url = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";

            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            var rssXml = client.DownloadString(url);

            var document = new XmlDocument();
            document.LoadXml(rssXml);

            var json = JsonConvert.SerializeXmlNode(document, Formatting.Indented);

            var jsonObj = JObject.Parse(json);
            var videos = jsonObj["feed"]["entry"].Select(x => JsonConvert.DeserializeObject<Video>(x.ToString()));

            using (FileStream htmlStream = new FileStream("youtube.html", FileMode.Create))
            {
                StreamWriter writer = new StreamWriter(htmlStream, Encoding.UTF8);
                writer.AutoFlush = true;

                writer.Write("<!DOCTYPE html>" + Environment.NewLine);
                writer.Write("<html>" + Environment.NewLine);
                writer.Write("<head>" + Environment.NewLine);
                writer.Write("<title>" + Environment.NewLine);
                writer.Write("You tube videos" + Environment.NewLine);
                writer.Write("</title>" + Environment.NewLine);
                writer.Write("</head>" + Environment.NewLine);
                writer.Write("<body>" + Environment.NewLine);

                foreach (var video in videos)
                {
                    writer.Write("<div>" + Environment.NewLine);
                    var link = video.link.href;
                    writer.Write("<a href=\""+ link + "\">");
                    writer.Write(video.title);
                    writer.Write("</a>" + Environment.NewLine);
                    writer.Write("</div>" + Environment.NewLine);

                    Console.WriteLine(video.title);

                    writer.Write("<div>" + Environment.NewLine);

                    string src = String.Format("\"http://www.youtube.com/embed/{0}\"", video.id);

                    writer.Write("<iframe width = \"420\" height = \"345\"src =" + src + ">" + Environment.NewLine);
                    writer.Write("</iframe>" + Environment.NewLine);

                    writer.Write("</div>" + Environment.NewLine);
                }

                writer.Write("</body>" + Environment.NewLine);
                writer.Write("</html>" + Environment.NewLine);
            }
        }
    }
}
