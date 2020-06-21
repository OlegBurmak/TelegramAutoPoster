namespace TAPoster.Models
{
    public class UserSetting
    {
        public int UserSettingId { get; set; }
        public string VkToken { get; set; }
        public string VkApiVersion { get; set; }
        
        public string TelegramToken { get; set; }
        public int TelegramGroup { get; set; }

        public int Deley { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}