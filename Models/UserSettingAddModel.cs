using System.ComponentModel.DataAnnotations;

namespace TAPoster.Models
{
    public class UserSettingAddModel
    {
        [Required(ErrorMessage = "Не указан VkToken")]
         public string VkToken { get; set; }

        [Required(ErrorMessage = "Не указана VkApi версия")]
        public string VkApiVersion { get; set; }
        
        [Required(ErrorMessage = "Не указан TelegramToken")]
        public string TelegramToken { get; set; }

        [Required(ErrorMessage = "Не указан TelegramGroup ID")]
        public int TelegramGroup { get; set; }

        [Required(ErrorMessage = "Не указана задержка постинга")]
        public int Deley { get; set; }

    }
}