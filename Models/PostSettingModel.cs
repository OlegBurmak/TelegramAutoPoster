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
    }
}