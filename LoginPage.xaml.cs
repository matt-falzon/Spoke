﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Spokesman
{
    public partial class LoginPage : ContentPage
    {
		

        public LoginPage()
        {


            InitializeComponent();

			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (s, e) =>
			{
				navigate();
			};
			btnLogin.GestureRecognizers.Add(tapGestureRecognizer);

            async void navigate()
            {
                await Navigation.PushModalAsync(new FacebookProfilePage());
            }

        }


        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new FacebookProfilePage());
        }

        void Handle_Clicked_Facebook(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
