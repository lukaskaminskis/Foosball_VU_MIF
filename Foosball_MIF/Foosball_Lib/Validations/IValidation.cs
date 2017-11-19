using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball_Lib.Validations
{
    public interface IValidation
    {
        bool UsernamePatternMatch(string username);
        bool PasswordPatternMatch(string password);
        bool EmailPatternMatch(string email);
    }
}
