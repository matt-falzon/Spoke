using System;
using System.Collections.Generic;
using FacebookLogin.Models;
using Xamarin.Forms;

namespace Spokesman
{
    public partial class NotificationsPage : ContentPage
    {

        private FacebookProfile _profile;
		
        public NotificationsPage()
        {
            InitializeComponent();

			var appData = Application.Current as App;
			_profile = appData.Profile;

			circleImage.Source = _profile.Picture.Data.Url;

			var tapGestureRecognizer = new TapGestureRecognizer();

			tapGestureRecognizer.Tapped += (s, e) =>
			{
				ActionSheetResult(s, e);
			};

			btnMenu.GestureRecognizers.Add(tapGestureRecognizer);

            async void ActionSheetResult(object sender, EventArgs e)
            {
                var action = await DisplayActionSheet(null, null, null, "Notification Settings", "About Spokesman");

                if(action == "About Spokesman")
                {
                    await Navigation.PushAsync(new InfoPage());
                }
            }
        }
    }
}
