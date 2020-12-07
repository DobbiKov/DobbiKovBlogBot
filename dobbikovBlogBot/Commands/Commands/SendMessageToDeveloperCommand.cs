using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace dobbikovBlogBot.Commands.Commands
{
    public class SendMessageToDeveloperCommand : Command
    {
        public override string[] Names { get; set; } = new string[] { "sendmessagetodeveloper", "send_message_to_developer" };

        public override async void Execute(Message message, TelegramBotClient client)
        {
            try
            {
                var mess = message.Text.Split('"');
                if (mess.Length < 3)
                {
                    await client.SendTextMessageAsync(message.Chat.Id, $"Вы ввели неправильно ообщение. Формат: /sendmessagetodeveloper \"сообщение\"");
                    return;
                }
                var newMess = mess[1];

                long newChatId = Int64.Parse(Config.TelegramChannelMessageToDeveloperId);

                await client.SendTextMessageAsync(newChatId, $"[MESS]: [{message.From.FirstName} {message.From.LastName} ({message.From.Username})]: {newMess}");
                await client.SendTextMessageAsync(message.Chat.Id, "Ваше сообщение было доставлено разработчику бота.", replyToMessageId: message.MessageId);

            }
            catch(Exception e)
            {

            }
        }
    }
}
