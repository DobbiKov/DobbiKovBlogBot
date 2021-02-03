using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace dobbikovBlogBot.Commands.Commands
{
    public class StartMinecraftCommand : Command
    {
        public override string[] Names { get; set; } = new string[] { "start_minecraft", "startminecraft" };

        public async override void Execute(Message message, TelegramBotClient client)
        {
            string path = "start.sh";
                Process.Start(path);
            await client.SendTextMessageAsync(message.Chat.Id, "Вы запустили майнкрафт сервер SHmine.");
        }
    }
}
