using Foosball_Lib.FileManagement;
using Foosball_Lib.Models;
using Foosball_Lib.Services;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Foosball_Lib.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestCloud : ContentPage
    {
        User selectedUser;

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            selectedUser = e.Item as User;
            //Deselect Item
            //((ListView)sender).SelectedItem = null;
        }

        void Upload(object sender, EventArgs e)
        {

        }

        void Refresh(object sender, EventArgs e)
        {

        }
    }
}