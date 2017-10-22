using Foosball_Lib.Models;
using System.Collections.Generic;

namespace Foosball_Lib.FileManagement
{
    class FileProcedures
    {
        public FileProcedures() { }
        /*public bool SignInProcedure(User user)
        {

        }

        public async bool RegisterProcedure(User user)
        {
            bool fileexist = await FileManagement.PCLHelper.IsFileExistAsync("UsersList.txt");
        } */

        // a big bunch of text is turned into collection of users
        public List<User> UserList(string text)
        {
            var users = new List<User>();
            string[] allLines = text.Split('\n');

            foreach (string line in allLines)
            {
                string[] split = line.Split(';');
                User user = new User(split[0], split[1], split[2]);
                users.Add(user);
            }
            return users;
        }

    }
}
