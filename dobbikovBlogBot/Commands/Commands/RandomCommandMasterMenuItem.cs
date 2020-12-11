using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dobbikovBlogBot.Commands.Commands
{

    public class RandomCommandMasterMenuItem
    {
        public RandomCommandMasterMenuItem()
        {
            TargetType = typeof(RandomCommandMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}