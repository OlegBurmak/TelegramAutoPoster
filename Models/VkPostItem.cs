namespace TAPoster.Models
{
    public class VkPostItem
    {
        public string PostType { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public string TypeAttachment { get; set; }
        public string Url { get; set; }
        public int Comment { get; set; }
        public int Like { get; set; }
        public int Reposts { get; set; }
        public int Views { get; set; }
    }
}