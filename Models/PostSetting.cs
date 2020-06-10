namespace TAPoster.Models
{
    public class PostSetting
    {
        public int PostSettingId { get; set; }
        public string GroupUrl { get; set; }
        public int PostCount { get; set; }
        public string PostFilter { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}