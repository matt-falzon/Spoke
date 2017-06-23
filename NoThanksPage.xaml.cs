using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Spokesman
{
    public partial class NoThanksPage : ContentPage
    {
        public NoThanksPage()
        {
            InitializeComponent();

			var tapGestureRecognizer = new TapGestureRecognizer();

			tapGestureRecognizer.Tapped += (s, e) =>
			{
				ActionSheetResult(s, e);
			};

			changedMind.GestureRecognizers.Add(tapGestureRecognizer);

			async void ActionSheetResult(object sender, EventArgs e)
			{
                await Navigation.PopAsync();	
            }
        }


        void Handle_Clicked(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
