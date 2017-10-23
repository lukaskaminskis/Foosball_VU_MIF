using Xamarin.Forms;
using Foosball_MIF;
using System.IO;
using Foosball_Lib.Models;
using System;

[assembly: Dependency(typeof(ISaveAndLoadFiles))]
namespace Foosball_MIF.Droid
{
    class SaveAndLoadFilesAndroid : ISaveAndLoadFiles
    {
        public SaveAndLoadFilesAndroid() { }

        public void SaveText(string filename, string text)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            System.IO.File.WriteAllText(filePath, text);
        }
        public string LoadText(string filename)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            return System.IO.File.ReadAllText(filePath);
        }

        public void RegisterProcedure(User user)
        {
            string text = String.Format("{0}|{1}|{2}|\n", user.UserId, user.GetPassword(), user.Email);
            SaveAndLoadFilesAndroid file = new SaveAndLoadFilesAndroid();
            file.SaveText("UsersList.txt", text);
        }

    }
}