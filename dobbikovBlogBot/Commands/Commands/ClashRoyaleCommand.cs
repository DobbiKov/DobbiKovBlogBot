using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace dobbikovBlogBot.Commands.Commands
{
    public class ClashRoyaleCommand : Command
    {
        public override string[] Names { get; set; } = new string[] { "clash royale", "клеш роял", "клэш роял", "клеш рояль", "клэш рояль" };

        public override async void Execute(Message message, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(message.Chat.Id, $"клеш рояль лучшая в мире игра!!!");
        }
    }
}
