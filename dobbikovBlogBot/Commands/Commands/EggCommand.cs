using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace dobbikovBlogBot.Commands.Commands
{
    public class EggCommand : Command
    {
        public override string[] Names { get; set; } = new string[] { "egg", "яйцо" };

        public async override void Execute(Message message, TelegramBotClient client)
        {
            InputOnlineFile EggPhoto1 = new InputOnlineFile("https://imgur.com/a/TvCRdSU");
            InputOnlineFile EggPhoto2 = new InputOnlineFile("https://imgur.com/a/YUtnEgL");
            await client.SendPhotoAsync(message.Chat.Id, EggPhoto1);
            await client.SendPhotoAsync(message.Chat.Id, EggPhoto2);
        }
    }
}
