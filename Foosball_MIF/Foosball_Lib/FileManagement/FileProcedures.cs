using Foosball_Lib.Models;
using System;
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
            string[] allLines = text.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in allLines)
            {
                string[] split;
                split = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                User user = new User(split[0], split[1], split[2] ?? "NoEmail");
                users.Add(user);
            }
            return users;
        }

    }
}
