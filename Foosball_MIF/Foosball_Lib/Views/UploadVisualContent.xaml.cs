using System;
using System.Collections.Generic;
using Plugin.Media;
using Xamarin.Forms;

namespace Foosball_Lib.Views
{
    public partial class UploadVisualContent : ContentPage
    {
        public UploadVisualContent()
        {
            InitializeComponent();
        }

        public async void TakePhotoButton_OnClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();


            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(
                new Plugin.Media.Abstractions.StoreCameraMediaOptions()
                {
                    SaveToAlbum = true
                });

            if (file == null)
                return;
            
            MainImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });

            //or:
            //image.Source = ImageSource.FromFile(file.Path);
            //image.Dispose();
        }

        public async void PickPhotoButton_OnClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if(!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("No Image", "Pick phot is not supported", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
                return;

         
            MainImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }

        public async void PickVideoButton_OnClicked(object sebder, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickVideoSupported)
            {
                await DisplayAlert("No Image", "Pick phot is not supported", "OK");
                return;
            }  

            var file = await CrossMedia.Current.PickVideoAsync();

            if (file == null)
                return;
        }
    }
}
