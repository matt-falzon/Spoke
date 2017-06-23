using System;
using System.Collections.Generic;
using FacebookLogin.Models;
using Xamarin.Forms;

namespace Spokesman
{
    public partial class HomePage 
    {
        private FacebookProfile _profile;  

        public HomePage()
        {
            InitializeComponent();

            var appData = Application.Current as App;
            _profile = appData.Profile;

            circleImage.Source = _profile.Picture.Data.Url;
            nameLabel.Text = _profile.FirstName + " " + _profile.LastName;

            //tap recognizer for image
			var tapGestureRecognizer = new TapGestureRecognizer();
			
            tapGestureRecognizer.Tapped += (s, e) =>
			{
                DisplayActionSheet(null, null, null, "Edit Profile", "Edit Bikes", "log out");
			};

            btnMenu.GestureRecognizers.Add(tapGestureRecognizer);


        }



    }
}
