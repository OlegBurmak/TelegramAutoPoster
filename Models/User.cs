using System.Collections.Generic;
using System.Linq;

namespace TAPoster.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserSetting UserSetting {get; set; }
        public List<PostSetting> PostSettings { get; set; }
        public List<VkPostItem> VkPostItems { get; set; }
    }
}