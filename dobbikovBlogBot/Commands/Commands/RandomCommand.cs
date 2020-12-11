using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace dobbikovBlogBot.Commands.Commands
{
    public class RandomCommand : Command
    {
        public override string[] Names { get; set; } = new string[] { "random", "rand", "/рандом" };

        public async override void Execute(Message message, TelegramBotClient client)
        {
            var text = message.Text;
            var text_mass = text.Split(' ');
            Random rand = new Random();

            if (text_mass.Length == 1)
            {
                int rand_num = rand.Next();
                await client.SendTextMessageAsync(message.Chat.Id, $"Случайное число: {rand_num}");
            }
            else if(text_mass.Length == 2)
            {
                int parse_number = 0;
                Int32.TryParse(text_mass[1], out parse_number);

                int rand_num = rand.Next(parse_number);
                await client.SendTextMessageAsync(message.Chat.Id, $"Случайное число: {rand_num}");
            }            
            else if(text_mass.Length == 3)
            {
                int parse_number_1 = 0;
                int parse_number_2 = 2;
                Int32.TryParse(text_mass[1], out parse_number_1);
                Int32.TryParse(text_mass[2], out parse_number_2);
                if(parse_number_1 > parse_number_2)
                {
                    await client.SendTextMessageAsync(message.Chat.Id, $"Первое число должно быть меньше второго!");
                    return;
                }

                int rand_num = rand.Next(parse_number_1, parse_number_2);
                await client.SendTextMessageAsync(message.Chat.Id, $"Случайное число: {rand_num}");
            }
            else
            {
                await client.SendTextMessageAsync(message.Chat.Id, $"Вы ввели неправильно команду.\nСинтаксис команды:\n\n1: /random - выведет случайное число.\n2: /random число - выведет случайное число в диапазоне от нуля до вашего числа.\n3: /random число_1 число_2 - выведет случайное число в диапазоне от числа 1 до числа 2.");
            }
        }
    }
}
