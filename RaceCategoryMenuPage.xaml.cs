using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Spokesman
{
    public partial class RaceCategoryMenuPage : ContentPage
    {
        public RaceCategoryMenuPage()
        {
			InitializeComponent();

			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (s, e) =>
			{
				navigate();
			};
			btnClose.GestureRecognizers.Add(tapGestureRecognizer);

			async void navigate()
			{
				await Navigation.PopModalAsync();
			}

			listView.ItemsSource = new List<string>
			{ 
                "Overall", 
                "Category", 
                "Female", 
                "Male", 
                "Chainless" 
			};
        }
    }

}
