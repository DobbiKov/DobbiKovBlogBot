using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace dobbikovBlogBot.Commands
{
    public static class RoflCommands
    {
        private static string[][] Names { get; set; } = new string[][] { 
            new string[]{"deb", "деб", "дэб", "Деб", "Дэб"},
            new string[]{"Химия химия", "химия химия"},
            new string[]{"сфоткать задачу", "Сфоткать задачу", "фото задачи", "Фото задачи"},
            new string[]{"Кабак", "кабак", "кэбэк", "Кэбэк", "кебек", "Кебек"},
            new string[]{"Франкенштейн", "франкенштейн"}
        };

        private static string[][] TextResponses = new string[][]
        {
            null,
            new string[]{"Вся залупа синяя."},
            new string[]{"Задача сфоткана."},
            null,
            null
        };

        private static string[][] PhotoResponses = new string[][]
        {
            new string[]{"https://imgur.com/a/z7auedL"}, //deb
            new string[]{"https://imgur.com/a/g9Irw8A"}, //Химия
            new string[]{ "https://imgur.com/a/m5T7k3W", "https://imgur.com/a/CRMLu47", "https://imgur.com/a/Ub2fupo", "https://imgur.com/a/VOoRyeh"}, //Фото задачи
            new string[]{"https://imgur.com/a/9sF15Vx"}, //Кабак
            new string[]{ "https://imgur.com/a/4SWaUou" } //Франкенштейн
        };

        public static int Contains(string command)
        {
            int id = 0;
            foreach (var comm in Names)
            {
                foreach (var comm_comm in comm)
                {
                    if (command.Contains(comm_comm))
                        return id;
                }
                id++;
            }
            return -1;
        }

        public static async void Execute(Message message, TelegramBotClient client, int command_id)
        {
            var rand = new Random();
            if(TextResponses[command_id] != null)
            {
                try
                {
                    await client.SendTextMessageAsync(message.Chat.Id, TextResponses[command_id][rand.Next(0, TextResponses[command_id].Length - 1)]);
                }
                catch { };
            }
            if(PhotoResponses[command_id] != null)
            {
                try
                {
                    var photo = new InputOnlineFile(PhotoResponses[command_id][rand.Next(0, PhotoResponses[command_id].Length - 1)]);
                    await client.SendPhotoAsync(message.Chat.Id, photo);
                }
                catch { };
            }
        }
    }
}
