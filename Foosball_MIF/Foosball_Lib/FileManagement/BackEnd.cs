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
    class BackEnd
    {
        public enum Message { RegexNoMatch, PassNoMatch, EmailNotMatch, RegSucc, UserExists, Exc };

        public async Task<Message> BackEndAsync(string username, string password, string repeatPassword, string email)
        {
            try
            {
                if (!Validation.UsernamePatternMatch(username)
                        && !Validation.PasswordPatternMatch(password)
                        && !Validation.PasswordPatternMatch(repeatPassword))
                {
                    throw new ArgumentException(Labels.NoMatch);
                    return Message.RegexNoMatch;
                }
                else if (password != repeatPassword)
                {
                    throw new Exception(Labels.NoMatch);
                    return Message.PassNoMatch;
                }
                else if (!Validation.EmailPatternMatch(email))
                {
                    throw new Exception(Labels.EmailNotMatch);
                    return Message.EmailNotMatch;
                }
                else
                {
                    User user = new User(UserId: username, Password: password, Email: email);
                    bool fileExists = await PCLHelper.IsFileExistAsync(Labels.UsersList);
                    if (!fileExists)
                    {
                        NewUserAsync(user);


                        Constants.LocalUser = user;
                        return Message.RegSucc;
                    }
                    else
                    {
                        var regUser = (from selectUser in Constants.userList
                                       where selectUser.UserId == user.UserId
                                       select selectUser).Any();

                        if (regUser == false)
                        {
                            NewUserAsync(user);

                            Constants.LocalUser = user;
                            return Message.RegSucc;
                        }
                        else
                        {
                            throw new Exception(Labels.UserExists);
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

        public static async Task<List<User>> GetUserListAsync()
        {
            string text = await PCLHelper.ReadAllTextAsync(Labels.UsersList);
            FileProcedures file = new FileProcedures();
            var userList = file.UserList(text);
            return userList;
        }

        public static async void NewUserAsync(User user)
        {
            string text = await PCLHelper.ReadAllTextAsync(Labels.UsersList);
            text = text + String.Format("{0};{1};{2};0;0;0|", user.UserId, user.GetPassword(), user.Email);
            await PCLHelper.DeleteFile(Labels.UsersList);
            await PCLHelper.WriteTextAllAsync(Labels.UsersList, text);
        }

        public static async void UpdateUserList()
        {
            string text = "";
            await PCLHelper.DeleteFile(Labels.UsersList);
            foreach (User user in Constants.userList)
            {
                string tmp = String.Format("{0};{1};{2};{3};{4};{5}|", user.UserId, user.GetPassword(), user.Email, user.MatchCount.ToString(), user.Wins.ToString(), user.Loses.ToString());
                text += tmp;
            }
            await PCLHelper.WriteTextAllAsync(Labels.UsersList, text);
        }
    }
}
