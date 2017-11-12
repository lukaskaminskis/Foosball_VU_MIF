using Foosball_MIF2.Models;
using System;
using System.Collections.Generic;

namespace Foosball_MIF2.FileManagement
{
    class FileProcedures
    {
        public FileProcedures() { }

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
