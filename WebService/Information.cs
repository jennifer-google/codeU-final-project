using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWikiSearch
{
    class Information
    {
        public string[] interests;

        public string[] pastSearches;

        public string[] pastClicks;

        public Information()
        {
            interests = new string[5];
            pastSearches = new string[5];
            pastClicks = new string[5];
        }
    }

   
}
