namespace TAPoster.Models
{
    public class PostSetting
    {
        public int PostSettingId { get; set; }
        public string GroupUrl { get; set; }
        public int PostCount { get; set; }
        public string PostFilter { get; set; }
        public int PostDeley { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }


        public void UpdateModel(PostSetting postSetting)
        {
            this.GroupUrl = postSetting.GroupUrl;
            this.PostCount = postSetting.PostCount;
            this.PostFilter = postSetting.PostFilter;
            this.PostDeley = postSetting.PostDeley;
        }
    }
}