using System.Collections.Generic;
using Xamarin.Forms;

namespace Foosball_Lib.Models
{
    public class Constants
    {
        public static Color BackgroundColor = Color.FromRgb(0, 94, 51);
        public static Color MainTextColor = Color.FromRgb(190,222,186) ;
        public static int LoginIconHeight = 120;
        public static int MaxGoalLimit = 10;

        public static List<User> userList;
        public static User opponent;
        public static User LocalUser;
        public static int GoalLimit = 10;
    }
}
