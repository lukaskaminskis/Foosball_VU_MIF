using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball_Lib.User
{
    public class User
    {
        private string UserId { get; set; }
        private string Password { get; set; }
        private int MatchCount { get; set; }
        private int Wins { get; set; }
        private int Loses { get; set; }

        public User(string _userId, string _password)
        {
            this.UserId = _userId;
            this.Password = _password;
        }

        public void ChangePassword(string _Password)
        {
            this.Password = _Password;
        }

        public void MatchWon(string _UserId)
        {
            MatchCount++;
            Wins++;
        }

        public void MatchLost(string _UserId)
        {
            MatchCount++;
            Loses++;
        }
}
}
