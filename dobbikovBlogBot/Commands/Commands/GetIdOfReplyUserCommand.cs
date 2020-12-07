using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace dobbikovBlogBot.Commands.Commands
{
    public class GetIdOfReplyUserCommand : Command
    {
        public override string[] Names { get; set; } = new string[] { "getidofreplyuser", "get_id_of_reply_user" };

        public override async void Execute(Message message, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(message.Chat.Id, $"ID of user: {message.ForwardFromChat.Id}");   
        }
    }
}
