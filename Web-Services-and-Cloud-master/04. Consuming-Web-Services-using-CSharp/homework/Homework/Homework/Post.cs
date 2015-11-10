namespace Homework
{
    public class Post
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

        public override string ToString()
        {
            return string.Format("post was written by user with id {0}.\n Title:{1}\nID:{2}\nBody:{3}", userId, title, id, body);
        }
    }
}
