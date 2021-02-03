using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace dobbikovBlogBot.Commands.Commands
{
    public class StopMinecraftCommand : Command
    {
        public override string[] Names { get; set; } = new string[] { "stop_minecraft", "stopminecraft" };

        public async override void Execute(Message message, TelegramBotClient client)
        {
            string path = "/root/SHmine/stop.sh";
            try
            {
                Process.Start(path);
            }
            catch 
            {
                //
            }
            await client.SendTextMessageAsync(message.Chat.Id, "Вы остановили майнкрафт сервер SHmine.");
        }
    }
}
