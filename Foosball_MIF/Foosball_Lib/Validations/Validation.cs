using Foosball_Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
    }
}
