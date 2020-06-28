using System.Collections.Generic;
using System.Threading.Tasks;
using TAPoster.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TAPoster.PosterLogic
{
    public class TelegramPoster
    {
        TelegramBotClient client;

        public async Task SendPost(VkPostItem postItem, UserSetting setting)
        {
            if(client == null)
            {
                client = new TelegramBotClient(setting.TelegramToken);
            }

            InputMediaPhoto[] list = { };
 
            if(postItem.Text != null)
            {
                await client.SendTextMessageAsync(setting.TelegramGroup, $"{postItem.Text} {postItem.Url}");
            }
            if(postItem.Url != null)
            {
                //await client.SendPhotoAsync(groupId, postItem.Url);
            }
            
        }


    }
}