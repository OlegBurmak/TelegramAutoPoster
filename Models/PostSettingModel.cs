using System.ComponentModel.DataAnnotations;

namespace TAPoster.Models
{
    public class PostSettingModel
    {
        
        [Required(ErrorMessage = "Не указана ссылка")]
        [DataType(DataType.Url)]
        public string GroupUrl { get; set; }

        [Required(ErrorMessage = "Не указан PostCount")]
        public int PostCount { get; set; }

        [Required(ErrorMessage = "Не указан PostFilter")]
        public string PostFilter { get; set; }

        [Required(ErrorMessage = "Не указана задержка постинга")]
        public int PostDeley { get; set; }

        public int PostItemComment { get; set; }
        public int PostItemLike { get; set; }
        public int PostItemRepost { get; set; }
        public int PostItemView { get; set; }
    }
}