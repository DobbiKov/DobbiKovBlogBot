using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace dobbikovBlogBot.Commands.Commands
{
    public class GetMyIdCommand : Command
    {
        public override string[] Names { get; set; } = new string[] { "getmyid", "get_my_id" };

        public override async void Execute(Message message, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(message.Chat.Id, $"Ваш Telegram ID: {message.From.Id}");
        }
    }
}
