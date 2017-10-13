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

        public bool UsernamePatternMatch(string _username)
        {
            Regex regex = new Regex(@"^\w+$");
            return regex.IsMatch(_username);
        }

        public bool PasswordPatternMatch(string _password)
        {
            Regex regex = new Regex(@"^\w+$");
            return regex.IsMatch(_password);
        }
    }
}
