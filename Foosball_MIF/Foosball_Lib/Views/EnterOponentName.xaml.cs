﻿using Foosball_Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Foosball_Lib.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterOponentName : ContentPage
    {
        public EnterOponentName()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_OponentName.TextColor = Constants.MainTextColor;
            LogoIcon.HeightRequest = Constants.LoginIconHeight;
            Entry_OponentName.Text = Constants.OponentName;
        }

        public void SubmitProcedure(object e, EventArgs s)
        {
            if (Entry_OponentName.Text == null || Entry_OponentName.Text == "")
            {
                DisplayAlert("Empty Field", "Pleas eneter oponent name, field is empty", "Ok");
            }
            else
            {
                Constants.OponentName = Entry_OponentName.Text;
                Navigation.PushModalAsync(new PropertiesPage());
            }
        }
    }
}