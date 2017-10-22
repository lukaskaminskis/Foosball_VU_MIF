﻿using Foosball_Lib.Models;
using System.Text.RegularExpressions;

namespace Foosball_Lib.Validations
{
    public class Validation
    {
        public Validation() { }

        public static bool UsernamePatternMatch(string _username)
        {
            if (_username == "" || _username == null)
            {
                return false;
            }

            Regex regex = new Regex(@"^\w+$");
            return regex.IsMatch(_username);
        }

        public static bool PasswordPatternMatch(string _password)
        {
            if (_password == "" || _password == null)
            {
                return false;
            }

            Regex regex = new Regex(@"^\w+$");
            return regex.IsMatch(_password);
        }

        public static bool IsOpponentAssigned()
        {
            if (Constants.OponentName == "" || Constants.OponentName == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsGoalLimitAssigned()
        {
            if (Constants.GoalLimit == 0 || Constants.GoalLimit == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool EmailPatternMatch(string _email)
        {
            if (_email == "" || _email == null)
            {
                return false;
            }

            string EmailMatchPattern =
                @"^\S +@\S +$";

            Regex regex = new Regex(EmailMatchPattern);
            return regex.IsMatch(_email);
        }
    }
}
