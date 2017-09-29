using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Foosball_Lib.Models
{
    public class Constants
    {
        public static Color BackgroundColor = Color.FromRgb(58, 153, 215);
        public static Color MainTextColor = Color.White;
        public static int LoginIconHeight = 120;
        public static int MaxGoalLimit = 10; 

        private static User localUser = null;
        public static User LocalUser { get => localUser; set => localUser = value; }

        private static int goalLimit;
        public static int GoalLimit { get => goalLimit; set => goalLimit = value; }

    }
}
