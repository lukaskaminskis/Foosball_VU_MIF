using Newtonsoft.Json;
using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foosball_Lib.Models;

namespace Foosball_MIF.Droid
{
    class SaveLoadDataJSON
    {

        public SaveLoadDataJSON()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filePath = Path.Combine(path, "UserData.txt");

            void SaveJSON(Object Data)
            {
                string json = JsonConvert.SerializeObject(Data);
                using (var file = File.Open(filePath, FileMode.Append, FileAccess.Write))
                using (var strm = new StreamWriter(file))
                {
                    strm.Write(json);
                }
            }

            Object LoadJSON()
            {
                string json;
                using (var file = File.Open(filePath, FileMode.Open))
                using (var strm = new StreamReader(file))
                {
                    json = strm.ReadToEnd();
                }
                return JsonConvert.DeserializeObject(json);
            }
        }
    }
}
