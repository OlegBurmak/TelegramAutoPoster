using System.Collections.Generic;

namespace TAPoster.PosterLogic
{
    public class Items
    {
        public Response response { get; set; }

    }

    public class Response
    {
        public int count { get; set; }
        public List<Item> items { get; set; }
    }

    public class Item
    {
        public int date { get; set; }
        public string post_type { get; set; }
        public string text { get; set; }
        public List<Attachment> attachments { get; set; }
    }

    public class Attachment
    {
        public string type { get; set; }
        public Photo photo { get; set; }
    }

    public class Photo
    {
        public int id { get; set; }
        public string owner_id { get; set; }
        public List<Size> sizes { get; set; }
    }

    public class Size
    {
        public string type { get; set; }
        public string url { get; set; }
    }

}