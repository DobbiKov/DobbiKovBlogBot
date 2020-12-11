using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace dobbikovBlogBot.Commands.Commands
{
    public class TopMusicCommand : Command
    {
        public override string[] Names { get; set; } = new string[] { "topmusic", "top_music" };

        public async override void Execute(Message message, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(message.Chat.Id, $"Прислал вам топовый музон.");
            await client.SendAudioAsync(message.Chat.Id, @"C:\Users\DobbiKov\Downloads\Telegram Desktop\dj_tapolsky_purple_unit_feat_sight_mc_ti_ushla_na_drum_n_bass_zf.mp3");
        }
    }
}
