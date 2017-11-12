namespace Foosball_MIF2.Models
{
    public class User
    {
        public string UserId { get; private set; }
        private string Password { get; set; }
        public string Email { get; private set; }
        private int MatchCount { get; set; }
        private int Wins { get; set; }
        private int Loses { get; set; }

        public User(){}

        public User(string UserId, string Password, string Email = "")
        {
            this.UserId     = UserId;
            this.Password   = Password;
            this.Email      = Email;
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
            return this.Password;
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
