using System;
using System.Collections.Generic;
using System.Text;

namespace dobbikovBlogBot.Models
{
    public class CoronavirusUkraine
    {
        public string country { get; set; } // страна
        public int cases { get; set; } // всего заражено
        public int todayCases { get; set; } // сегодня заражено
        public int recovered { get; set; } // выздоровили
        public int todayRecovered { get; set; } // сегодня выздоровили
        public int deaths { get; set; } // всего умерло
        public int todayDeaths { get; set; } // сегодня умерли
    }
}
