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

        public async Task SendPost(VkPostItem postItem, string token, int groupId)
        {
            if(client == null)
            {
                client = new TelegramBotClient(token);
            }

            InputMediaPhoto[] list = { };
 
            if(postItem.Text != null)
            {
                await client.SendTextMessageAsync(groupId, $"{postItem.Text} {postItem.Url}");
            }
            if(postItem.Url != null)
            {
                //await client.SendPhotoAsync(groupId, postItem.Url);
            }
            
        }


    }
}