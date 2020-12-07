using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace dobbikovBlogBot.Commands.Commands
{
    public class SayAsBotCommand : Command
    {
        public override string[] Names { get; set; } = new string[] { "sayasbot", "say_as_bot" };

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var mess = message.Text.Split('"');
            if(mess.Length < 3)
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Вы ввели неправильно сообщение. Формат: /sayasbot id \"сообщение\"");
                return;
            }
            var chatid = message.Text.Split(" ");
            if (chatid.Length < 3)
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Вы ввели неправильно сообщение. Формат: /sayasbot id \"сообщение\"");
                return;
            }

            var newMess = mess[1];
            long newChatId;
            try
            {
                newChatId = Int64.Parse(chatid[1]);
            }
            catch(Exception e)
            {
                await client.SendTextMessageAsync(message.Chat.Id, $"Что-то пошло не так.");
                return;
            }
            await client.SendTextMessageAsync(newChatId, newMess);
            await client.SendTextMessageAsync(message.Chat.Id, "Сообщение успешно отправлено.");
        }
    }
}
