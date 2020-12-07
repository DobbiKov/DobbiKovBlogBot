using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace dobbikovBlogBot.Commands.Commands
{
    public class GetChatIdCommand : Command
    {
        public override string[] Names { get; set; } = new string[] { "getchatid", "get_chat_id" };

        public override async void Execute(Message message, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(message.Chat.Id, $"Id данного чата: {message.Chat.Id}");
        }
    }
}
