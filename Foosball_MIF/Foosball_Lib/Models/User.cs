using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball_Lib.Models
{
    public class User
    {
        private string UserId { get; set; }
        private string Password { get; set; }
        private int MatchCount { get; set; }
        private int Wins { get; set; }
        private int Loses { get; set; }

        public User(string UserId, string Password)
        {
            this.UserId = UserId;
            this.Password = Password;
        }

        public bool CheckInformation()
        {
            if (this.UserId != "" || this.Password != "")
                return true;
            else
                return false;
        }

        public void ChangePassword(string Password)
        {
            this.Password = Password;
        }

        public void MatchWon(string UserId)
        {
            MatchCount++;
            Wins++;
        }

        public void MatchLost(string UserId)
        {
            MatchCount++;
            Loses++;
        }
    }
}
