using Foosball_Lib.Models;
using System.Collections.Generic;

namespace Foosball_Lib.FileManagement
{
    class FileProcedures
    {
        /*public bool SignInProcedure(User user)
        {

        }

        public async bool RegisterProcedure(User user)
        {
            bool fileexist = await FileManagement.PCLHelper.IsFileExistAsync("UsersList.txt");
        } */

        public async Task<User> UsersList()
        {
            string text = await FileManagement.PCLHelper.ReadAllTextAsync("UsersList.txt");
        }
    }
}
