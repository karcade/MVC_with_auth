using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    internal class Tea
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string toStr()
        {
            string str=Name+" "+ Description;
            return str;
        }
    }

    
}
