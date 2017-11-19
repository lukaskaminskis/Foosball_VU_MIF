using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Foosball_Lib.Validations;
using System.ServiceModel;

namespace Foosball_MIF.Droid.Validations
{
    public class AndroidValidation : IValidation
    {
        ValidationServiceClient validationService = new ValidationServiceClient(
                new BasicHttpBinding(),
                new EndpointAddress("http://192.168.43.42/foos/ValidationService.svc"));

        public bool UsernamePatternMatch(string username)
        {
            return validationService.UsernamePatternMatch(username);
        }

        public bool PasswordPatternMatch(string password)
        {
            return validationService.PasswordPatternMatch(password);
        }

        public bool EmailPatternMatch(string email)
        {
            return validationService.EmailPatternMatch(email);
        }
    }
}