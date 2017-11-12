﻿using Foosball_MIF2.Models;
using Foosball_MIF2.Validations;
using Foosball_MIF2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball_MIF2.FileManagement
{
    class BackEnd
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
                        List<User> users = new List<User>();
                        users = await GetUsersList();

                        var regUser = (from selectUser in users
                                       where selectUser.UserId == user.UserId
                                       select selectUser).Any();

                        if (regUser == false)
                        {
                            AddUser(user);

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

        public async Task<List<User>> GetUsersList()
        {
            var users = new List<User>();
            string text = await FileManagement.PCLHelper.ReadAllTextAsync(Labels.UsersList);
            FileProcedures file = new FileProcedures();
            users = file.UserList(text);
            return users;
        }

        public async void AddUser(User user)
        {
            string text = await FileManagement.PCLHelper.ReadAllTextAsync(Labels.UsersList);
            text = text + String.Format("{0};{1};{2}|", user.UserId, user.GetPassword(), user.Email);
            await FileManagement.PCLHelper.DeleteFile(Labels.UsersList);
            await FileManagement.PCLHelper.WriteTextAllAsync(Labels.UsersList, text);
        }

    }
}
