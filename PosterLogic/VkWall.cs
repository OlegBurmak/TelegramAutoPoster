using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TAPoster.Models;

namespace TAPoster.PosterLogic
{
    public class VkWall
    {
        
        private string requestString = "https://api.vk.com/method/wall.get?";

        public async Task<List<VkPostItem>> GetItemsAsync(User user)
        {
            List<VkPostItem> items = new List<VkPostItem>();
            foreach(var item in user.PostSettings)
            {
                var validString = ValidRequest(item, user.UserSetting.VkToken, user.UserSetting.VkApiVersion);
                var source = await GetSourceAsync(validString);
                var filterItems = await ConvertJsonToObjectAsync(source);
                filterItems = GetFilterObject(filterItems, new FiltersModel
                {
                    Comment = item.PostItemComment,
                    Like = item.PostItemLike,
                    Repost = item.PostItemRepost,
                    View = item.PostItemView
                });

                items.AddRange(filterItems);
            }
            return items;
        }

        private string ValidRequest(PostSetting setting, string vkToken, string vkApiVersion)
        {
            var idString = "";
            try
            {
                idString = $"owner_id=-{int.Parse(setting.GroupUrl).ToString()}";
            }
            catch (System.Exception)
            {
                idString = $"domain={setting.GroupUrl}";
            }
            
            string validRequestString = requestString + $"{idString}&count={setting.PostCount}&filter={setting.PostFilter}&access_token={vkToken}&v={vkApiVersion}";
            return validRequestString;
        }

        private async Task<string> GetSourceAsync(string validRequest)
        {
            string requestString;

            WebRequest request = WebRequest.Create(validRequest);
            request.Method = "GET";
            request.Credentials = CredentialCache.DefaultCredentials;
            request.ContentType = "application/json; charset=utf-8";

            WebResponse response = await request.GetResponseAsync();

            using(Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);
                requestString = await reader.ReadToEndAsync();
            }

            return requestString;
        }

        private async Task<List<VkPostItem>> ConvertJsonToObjectAsync(string source)
        {
            return await Task.Run(()=>ConvertJsonToObject(source));
        }

        private List<VkPostItem> ConvertJsonToObject(string source)
        {
            Items items = JsonConvert.DeserializeObject<Items>(source);

            List<VkPostItem> validItems = new List<VkPostItem>();

            foreach(var item in items.response.items)
            {
                try
                {
                    validItems.Add(new VkPostItem
                    {
                        PostType = item.post_type,
                        Text = item.text,
                        Date = item.date.ToString(),
                        TypeAttachment = item.attachments.LastOrDefault().photo.sizes.LastOrDefault().type,
                        Url = item.attachments.LastOrDefault().photo.sizes.LastOrDefault().url,
                        Comment = item.comments.count,
                        Like = item.likes.count,
                        Reposts = item.reposts.count,
                        Views = item.views.count
                    });
                }
                catch (System.Exception)
                {
                    
                    continue;
                }
            }

            return validItems;

        }

        private List<VkPostItem> GetFilterObject(List<VkPostItem> items, FiltersModel filters)
        {
            List<VkPostItem> filterItems = items.Where(i => i.Comment >= filters.Comment || filters.Comment <= 0)
                .Where(i => i.Like >= filters.Like || filters.Like <= 0)
                .Where(i => i.Reposts >= filters.Repost || filters.Repost <= 0)
                .Where(i => i.Views >= filters.View || filters.View <= -0).ToList();
            return filterItems;
        }

    }
}