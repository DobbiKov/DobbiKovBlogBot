﻿using dobbikovBlogBot.Commands;
using dobbikovBlogBot.Commands.Commands;
using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace dobbikovBlogBot
{
    public class Program
    {
        private static TelegramBotClient client;
        private static List<Commands.Command> commands;
        static void Main(string[] args)
        {
            client = new TelegramBotClient(Config.Token);
            commands = new List<Commands.Command>();

            commands.Add(new SayAsBotCommand());
            commands.Add(new GetChatIdCommand());
            commands.Add(new GetMyIdCommand());
            commands.Add(new SendMessageToDeveloperCommand());
            commands.Add(new CoronavirusUnkraineCommand());
            commands.Add(new RandomCommand());
            commands.Add(new ClashRoyaleCommand());
            commands.Add(new StartMinecraftCommand());
            commands.Add(new StopMinecraftCommand());
            commands.Add(new EggCommand());

            client.StartReceiving();
            Console.WriteLine("Bot started.");
            client.OnMessage += Client_OnMessage;
            Console.ReadLine();
            client.StopReceiving();
            Console.WriteLine("Hello World!");
        }

        private static async void Client_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var message = e.Message;
            if(message.Text != null)
            {
                LogToTelegramChannel(message);
                Console.WriteLine($"[BOT]: New mess: chatID: {message.Chat.Id}, [{message.From.FirstName} {message.From.LastName} ({message.From.Username})]: {message.Text}.");
                foreach(var comm in commands)
                {
                    if (comm.Contains(message.Text))
                    {
                        comm.Execute(message, client);
                        break;
                    }
                }
                var rofl_comm = RoflCommands.Contains(message.Text);
                if (rofl_comm != -1)
                {
                    RoflCommands.Execute(message, client, rofl_comm);
                }
            }
        }

        private static async void LogToTelegramChannel(Message message)
        {
            await client.SendTextMessageAsync(Int64.Parse(Config.TelegramChannelForLoggingId), $"[BOT]: New message: chatID:{message.Chat.Id}, [{message.From.FirstName} {message.From.LastName} ({message.From.Username})]: {message.Text}");
        }
    }
}
