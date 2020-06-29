using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TAPoster.Models
{
    public class VkPostItem
    {
        public int VkPostItemId { get; set; }

        public string PostType { get; set; }

        [Required(ErrorMessage="Enter text")]
        public string Text { get; set; }
        public string Date { get; set; }
        public string TypeAttachment { get; set; }

        [Required(ErrorMessage="Enter Url")]
        public string Url { get; set; }
        public int Comment { get; set; }
        public int Like { get; set; }
        public int Reposts { get; set; }
        public int Views { get; set; }


        [JsonIgnore]
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }

        public void UpdateModel(VkPostItem postItem)
        {
            this.Text = postItem.Text;
            this.Url = postItem.Url;
        }
    }
}