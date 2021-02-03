using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace dobbikovBlogBot.Commands
{
    public abstract class Command
    {
        /// <summary>
        /// Массив строк, через которые можно вызвать команду. Пример: getmyid, get-my-id, get_my_id
        /// </summary>
        public abstract string[] Names { get; set; }
        /// <summary>
        /// Выполнение кода команды.
        /// </summary>
        /// <param name="message">Само сообщение.</param>
        /// <param name="client">Telegram bot client, от которого мы и будем отправлять сообщение обратно.</param>
        public abstract void Execute(Message message, TelegramBotClient client);

        /// <summary>
        /// Метод, который проверяет, найдена ли команда.
        /// </summary>
        /// <param name="command">Строка, в которой нужно определеить команду.</param>
        /// <returns></returns>
        public bool Contains(string command)
        {
            foreach(var comm in Names)
            {
                if (command.Contains(comm))
                    return true;      
            }
            return false;
        }
    }
}
