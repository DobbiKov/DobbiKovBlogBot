using dobbikovBlogBot.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace dobbikovBlogBot.Commands.Commands
{
    public class CoronavirusUnkraineCommand : Command
    {
        public override string[] Names { get; set; } = new string[] { "coronavirusukraine", "coronavirus_ukraine" };

        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            HttpClient http = new HttpClient();
            var request = await http.GetStringAsync("https://corona.lmao.ninja/v2/countries/Ukraine?yesterday&strict");
            var response = JsonConvert.DeserializeObject<CoronavirusUkraine>(request);

            await client.SendTextMessageAsync(chatId, $"Статистика по кронавирусу в Украине от DobbiKovBot\n\nВсего заражено: {response.cases}.\nСегодня заражено: {response.todayCases}.\nВсего умерло: {response.deaths}.\nСегодня умерло: {response.todayDeaths}.\nВсего выздоровело: {response.recovered}.\nСегодня выздоровело: {response.todayRecovered}.");
        }
    }
}
