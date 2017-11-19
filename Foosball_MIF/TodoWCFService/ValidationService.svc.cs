using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text.RegularExpressions;

namespace FoosballWCFService
{
    [ServiceContract]
    public class ValidationService
    {
        [OperationContract]
        public bool UsernamePatternMatch(string username)
        {
            if (username == "" || username == null)
            {
                return false;
            }

            Regex regex = new Regex(@"^\w+$");
            return regex.IsMatch(username);
        }

        [OperationContract]
        public bool PasswordPatternMatch(string password)
        {
            if (password=="" || password == null)
            {
                return false;
            }

            Regex regex = new Regex(@"^\w+$");
            return regex.IsMatch(password);
        }

        [OperationContract]
        public bool EmailPatternMatch(string email)
        {
            if (email == "" || email == null)
            {
                return false;
            }

            string EmailMatchPattern =
                @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";
            //Credits to http://www.rhyous.com/2010/06/15/csharp-email-regular-expression

            Regex regex = new Regex(EmailMatchPattern);
            return regex.IsMatch(email);
        }
    }
}
