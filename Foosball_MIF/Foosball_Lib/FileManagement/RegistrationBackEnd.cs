using Foosball_Lib.Models;
using Foosball_Lib.Validations;
using Foosball_Lib.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball_Lib.FileManagement
{
    class RegistrationBackEnd
    {
        public enum Message { RegexNoMatch, PassNoMatch, EmailNotMatch, RegSucc, UserExists, Exc};

        public async Task<Message> BackEndAsync(string username, string password, string repeatPassword, string email)
        {
            try
            {
                if (!Validation.UsernamePatternMatch(username)
                        && !Validation.PasswordPatternMatch(password)
                        && !Validation.PasswordPatternMatch(repeatPassword))
                {
                    return Message.RegexNoMatch;
                }
                else if (password != repeatPassword)
                {
                    return Message.PassNoMatch;
                }
                else if (Validation.EmailPatternMatch(email))
                {
                    return Message.EmailNotMatch;
                }
                else
                {
                    User user = new User(UserId: username, Password: password, Email: email);
                    bool fileExists = await PCLHelper.IsFileExistAsync(Labels.UsersList);
                    if (!fileExists)
                    {
                        string text = String.Format("{0};{1};{2}|", user.UserId, user.GetPassword(), user.Email);
                        await PCLHelper.WriteTextAllAsync(Labels.UsersList, text);

                        Constants.LocalUser = user;
                        return Message.RegSucc;
                    }
                    else
                    {
                        var users = new List<User>();
                        string text = await FileManagement.PCLHelper.ReadAllTextAsync(Labels.UsersList);
                        FileProcedures file = new FileProcedures();
                        users = file.UserList(text);

                        var regUser = (from selectUser in users
                                       where selectUser.UserId == user.UserId
                                       select selectUser).Any();

                        if (regUser == false)
                        {
                            text = text + String.Format("{0};{1};{2}|", user.UserId, user.GetPassword(), user.Email);
                            await FileManagement.PCLHelper.DeleteFile(Labels.UsersList);
                            await FileManagement.PCLHelper.WriteTextAllAsync(Labels.UsersList, text);

                            Constants.LocalUser = user;
                            return Message.RegSucc;
                        }
                        else
                        {
                            return Message.UserExists;
                        }

                    }
                }
            }
            catch (Exception exc)
            {
                return Message.Exc;
            }
        }

    }
}
