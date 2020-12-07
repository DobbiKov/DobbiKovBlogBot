using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace dobbikovBlogBot.Commands
{
    public abstract class Command
    {
        public abstract string[] Names { get; set; }
        public abstract void Execute(Message message, TelegramBotClient client);

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
