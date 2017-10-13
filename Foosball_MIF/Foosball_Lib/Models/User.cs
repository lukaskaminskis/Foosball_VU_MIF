using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball_Lib.Models
{
    public class User
    {
        public string UserId { get; private set; }
        private string Password { get; set; }
        private string Email { get; set; }
        private int MatchCount { get; set; }
        private int Wins { get; set; }
        private int Loses { get; set; }

        public User(){}

        public User(string UserId, string Password)
        {
            this.UserId = UserId;
            this.Password = Password;
        }

        public bool CheckInformation()
        {
            if (this.UserId == null || this.Password == null || this.UserId == "" || this.Password == "")
                return false;
            else
                return true;
        }

        public void ChangeEmail(string Email)
        {
            this.Email = Email;
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
