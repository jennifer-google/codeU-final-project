using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWikiSearch
{
    class User
    {
        public string username { get; set; }

        public string password { get; set; }

        public Information info { get; set;}

        public User(string name, string password)
        {
            this.username = username;
            this.password = password;
        }

        public void setInfo(string one, string two, string three)
        {
            info.interests[0] = one;
            info.interests[1] = two;
            info.interests[2] = three;
        }

        public void saveUserInformation()
        {

        }
    }
}
