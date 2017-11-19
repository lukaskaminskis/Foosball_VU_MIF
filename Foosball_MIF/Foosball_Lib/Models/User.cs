namespace Foosball_Lib.Models
{
    public class User
    {
        public string UserId { get; private set; }
        private string Password { get; set; }
        public string Email { get; private set; }
        public int MatchCount { get; private set; }
        public int Wins { get; private set; }
        public int Loses { get; private set; }

        public User(){}

        public User(string UserId, string Password, string Email = "", int MatchCount = 0, int Wins = 0, int Loses = 0)
        {
            this.UserId     = UserId;
            this.Password   = Password;
            this.Email      = Email;
            this.MatchCount = MatchCount;
            this.Wins       = Wins;
            this.Loses      = Loses;
        }

        public void ChangeEmail(string Email)
        {
            this.Email = Email;
        }

        public void ChangePassword(string Password)
        {
            this.Password = Password;
        }

        public string GetPassword()
        {
            return Password;
        }

        public void MatchWon()
        {
            MatchCount++;
            Wins++;
        }

        public void MatchLost()
        {
            MatchCount++;
            Loses++;
        }
    }
}
